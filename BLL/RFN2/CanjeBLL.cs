using BE.RFN1;
using BE.RFN2;
using BLL.RFN1;
using DAL.RFN2;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.RFN2
{
    public class CanjeBLL
    {
        private const string MODULO = "Canjes";

        private readonly CanjeDAL _canjeDAL = new CanjeDAL();
        private readonly PremioDAL _premioDAL = new PremioDAL();
        private readonly LoteBLL _loteBLL = new LoteBLL();
        private readonly BitacoraBLL _bitacoraBLL = new BitacoraBLL();
        private readonly DigitoVerificadorBLL _digitoVerificadorBLL = new DigitoVerificadorBLL();

        public int SaldoVigente(Cliente c) => _loteBLL.ConsultarSaldo(c);

        public int PuntosComprometidos(Cliente c) => _canjeDAL.PuntosComprometidos(c.IdCliente);

        public int SaldoDisponible(Cliente c) => Math.Max(0, SaldoVigente(c) - PuntosComprometidos(c));

        public Canje RegistrarSolicitud(Cliente c, Premio p)
        {
            if (c == null || c.IdCliente == 0)
                throw new Exception("Busque un cliente inscripto antes de registrar el canje.");
            if (p == null || p.IdPremio == 0)
                throw new Exception("Seleccione un premio.");

            Premio? actual = _premioDAL.Obtener(p.IdPremio);
            if (actual == null)
                throw new Exception("El premio ya no existe.");
            if (actual.Stock <= 0)
                throw new Exception("No hay stock del premio " + actual.Nombre + ".");

            int disponible = SaldoDisponible(c);
            if (actual.PuntosRequeridos > disponible)
                throw new Exception($"El cliente no tiene saldo suficiente. Disponible: {disponible:N0} pts, requiere: {actual.PuntosRequeridos:N0} pts.");

            bool requiereAutorizacion = actual.ValorReferencia > ProgramaPuntosBLL.Obtener().UmbralAutorizacion;
            var canje = new Canje
            {
                Cliente = c,
                Premio = actual,
                PuntosRequeridos = actual.PuntosRequeridos,
                ValorReferencia = actual.ValorReferencia,
                FechaSolicitud = BitacoraBLL.AhoraSinMilisegundos(),
                Estado = requiereAutorizacion ? EstadoCanje.pendiente : EstadoCanje.autorizado,
                Vendedor = SessionManager.Instance.UsuarioActual()
            };

            _canjeDAL.Insertar(canje);
            _digitoVerificadorBLL.RecalcularDVV_Canje();

            RegistrarEvento($"Solicitud de canje {canje.NroCanje} cliente {c.Dni} premio {actual.Nombre} ({canje.Estado})", 1);
            return canje;
        }

        public List<Canje> ListarPendientes() => _canjeDAL.ListarPorEstado(EstadoCanje.pendiente, null);

        public void Resolver(Canje k, bool aprobar, string? motivo)
        {
            motivo = string.IsNullOrWhiteSpace(motivo) ? null : motivo!.Trim();
            if (k.Estado != EstadoCanje.pendiente)
                throw new Exception("El canje no está pendiente de autorización.");
            if (!aprobar && motivo == null)
                throw new Exception("Para rechazar el canje el motivo es obligatorio.");
            if (motivo != null && motivo.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");

            k.Estado = aprobar ? EstadoCanje.autorizado : EstadoCanje.rechazado;
            k.MotivoResolucion = motivo;
            k.Supervisor = SessionManager.Instance.UsuarioActual();
            k.FechaResolucion = BitacoraBLL.AhoraSinMilisegundos();

            try
            {
                _canjeDAL.Resolver(k);
            }
            catch
            {
                k.Estado = EstadoCanje.pendiente;
                k.Supervisor = null;
                k.MotivoResolucion = null;
                k.FechaResolucion = null;
                throw;
            }
            _digitoVerificadorBLL.RecalcularDVV_Canje();

            RegistrarEvento($"{(aprobar ? "Autorizar" : "Rechazar")} canje {k.NroCanje} ({k.PuntosRequeridos} pts)", aprobar ? 2 : 1);
        }

        public List<Canje> ListarAutorizados(string? dniCliente)
        {
            dniCliente = string.IsNullOrWhiteSpace(dniCliente) ? null : dniCliente!.Trim();
            return _canjeDAL.ListarPorEstado(EstadoCanje.autorizado, dniCliente);
        }

        public int Entregar(Canje k)
        {
            if (k.Estado != EstadoCanje.autorizado)
                throw new Exception("Solo se pueden entregar canjes autorizados.");

            List<LotePuntos> vigentes;
            int saldo = _loteBLL.ConsultarSaldo(k.Cliente, out vigentes);
            if (saldo < k.PuntosRequeridos)
                throw new Exception($"El cliente ya no tiene saldo suficiente. Saldo vigente: {saldo:N0} pts, requiere: {k.PuntosRequeridos:N0} pts.");

            var lotes = new List<(LotePuntos Lote, int Anterior)>();
            var detalle = new List<DetalleCanje>();
            int resta = k.PuntosRequeridos;
            foreach (LotePuntos lote in vigentes.OrderBy(l => l.FechaVencimiento).ThenBy(l => l.IdLote))
            {
                if (resta == 0) break;
                int descuento = Math.Min(resta, lote.PuntosDisponibles);
                if (descuento <= 0) continue;
                lotes.Add((lote, lote.PuntosDisponibles));
                lote.PuntosDisponibles -= descuento;
                detalle.Add(new DetalleCanje { Lote = lote, PuntosDescontados = descuento });
                resta -= descuento;
            }

            k.Detalle = detalle;
            k.Estado = EstadoCanje.entregado;
            k.FechaEntrega = BitacoraBLL.AhoraSinMilisegundos();

            try
            {
                _canjeDAL.Entregar(k, lotes);
            }
            catch
            {
                foreach (var item in lotes) item.Lote.PuntosDisponibles = item.Anterior;
                k.Detalle = new List<DetalleCanje>();
                k.Estado = EstadoCanje.autorizado;
                k.FechaEntrega = null;
                throw;
            }

            _digitoVerificadorBLL.RecalcularDVV_LotePuntos();
            _digitoVerificadorBLL.RecalcularDVV_DetalleCanje();
            _digitoVerificadorBLL.RecalcularDVV_Canje();

            RegistrarEvento($"Entregar premio canje {k.NroCanje} cliente {k.Cliente.Dni} ({k.PuntosRequeridos} pts)", 2);
            return saldo - k.PuntosRequeridos;
        }

        public Canje? ObtenerPorNro(string nro)
        {
            nro = (nro ?? "").Trim().ToUpperInvariant();
            if (nro.Length == 0) return null;
            return _canjeDAL.ObtenerPorNro(nro);
        }

        public bool DentroDelPlazoDeAnulacion(Canje k) =>
            k.FechaEntrega.HasValue &&
            (DateTime.Today - k.FechaEntrega.Value.Date).TotalDays <= ProgramaPuntosBLL.Obtener().PlazoAnulacionDias;

        public int Anular(Canje k, string? motivo)
        {
            motivo = string.IsNullOrWhiteSpace(motivo) ? null : motivo!.Trim();
            if (k.Estado != EstadoCanje.entregado)
                throw new Exception("Solo se pueden anular canjes entregados.");
            if (!DentroDelPlazoDeAnulacion(k))
                throw new Exception($"El canje está fuera del plazo de anulación ({ProgramaPuntosBLL.Obtener().PlazoAnulacionDias} días).");
            if (motivo == null)
                throw new Exception("Ingrese el motivo de la anulación.");
            if (motivo.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");

            var lotes = new List<(LotePuntos Lote, int Anterior)>();
            int reintegrados = 0;
            foreach (DetalleCanje d in k.Detalle)
            {
                LotePuntos lote = d.Lote;
                int anterior = lote.PuntosDisponibles;
                lote.PuntosDisponibles = Math.Min(lote.PuntosOriginales, lote.PuntosDisponibles + d.PuntosDescontados);
                lotes.Add((lote, anterior));
                reintegrados += lote.PuntosDisponibles - anterior;
            }

            k.Estado = EstadoCanje.anulado;
            k.SupervisorAnulacion = SessionManager.Instance.UsuarioActual();
            k.MotivoAnulacion = motivo;
            k.FechaAnulacion = BitacoraBLL.AhoraSinMilisegundos();

            try
            {
                _canjeDAL.Anular(k, lotes);
            }
            catch
            {
                foreach (var item in lotes) item.Lote.PuntosDisponibles = item.Anterior;
                k.Estado = EstadoCanje.entregado;
                k.SupervisorAnulacion = null;
                k.MotivoAnulacion = null;
                k.FechaAnulacion = null;
                throw;
            }

            _digitoVerificadorBLL.RecalcularDVV_LotePuntos();
            _digitoVerificadorBLL.RecalcularDVV_Canje();

            RegistrarEvento($"Anular canje {k.NroCanje} cliente {k.Cliente.Dni} ({reintegrados} pts reintegrados)", 2);
            return reintegrados;
        }

        private void RegistrarEvento(string evento, int criticidad)
        {
            try
            {
                _bitacoraBLL.RegistrarEvento(new Bitacora
                {
                    Login = SessionManager.Instance.UsuarioActual().Username,
                    Modulo = MODULO,
                    Evento = VentaBLL.Recortar(evento, 100),
                    Criticidad = criticidad
                });
            }
            catch { }
        }
    }
}

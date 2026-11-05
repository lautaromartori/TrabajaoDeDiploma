using LM830BE.LM830RFN1;
using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN1;
using LM830DAL.LM830RFN2;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LM830BLL.LM830RFN2
{
    public class LM830CanjeBLL
    {
        private const string LM830MODULO = "Canjes";

        private readonly LM830CanjeDAL LM830_canjeDAL = new LM830CanjeDAL();
        private readonly LM830PremioDAL LM830_premioDAL = new LM830PremioDAL();
        private readonly LM830LoteBLL LM830_loteBLL = new LM830LoteBLL();
        private readonly LM830DigitoVerificadorBLL LM830_digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

        public int LM830SaldoVigente(LM830Cliente LM830c) => LM830_loteBLL.LM830ConsultarSaldo(LM830c);

        public int LM830PuntosComprometidos(LM830Cliente LM830c) => LM830_canjeDAL.LM830PuntosComprometidos(LM830c.LM830IdCliente);

        public int LM830SaldoDisponible(LM830Cliente LM830c) => Math.Max(0, LM830SaldoVigente(LM830c) - LM830PuntosComprometidos(LM830c));

        public LM830Canje LM830RegistrarSolicitud(LM830Cliente LM830c, LM830Premio LM830p)
        {
            if (LM830c == null || LM830c.LM830IdCliente == 0)
                throw new Exception("Busque un cliente inscripto antes de registrar el canje.");
            if (LM830p == null || LM830p.LM830IdPremio == 0)
                throw new Exception("Seleccione un premio.");

            LM830Premio? LM830actual = LM830_premioDAL.LM830Obtener(LM830p.LM830IdPremio);
            if (LM830actual == null)
                throw new Exception("El premio ya no existe.");
            if (LM830actual.LM830Stock <= 0)
                throw new Exception("No hay stock del premio " + LM830actual.LM830Nombre + ".");

            int LM830disponible = LM830SaldoDisponible(LM830c);
            if (LM830actual.LM830PuntosRequeridos > LM830disponible)
                throw new Exception($"El cliente no tiene saldo suficiente. Disponible: {LM830disponible:N0} pts, requiere: {LM830actual.LM830PuntosRequeridos:N0} pts.");

            bool LM830requiereAutorizacion = LM830actual.LM830ValorReferencia > LM830ProgramaPuntosBLL.LM830Obtener().LM830UmbralAutorizacion;
            var LM830canje = new LM830Canje
            {
                LM830Cliente = LM830c,
                LM830Premio = LM830actual,
                LM830PuntosRequeridos = LM830actual.LM830PuntosRequeridos,
                LM830ValorReferencia = LM830actual.LM830ValorReferencia,
                LM830FechaSolicitud = LM830BitacoraBLL.LM830AhoraSinMilisegundos(),
                LM830Estado = LM830requiereAutorizacion ? LM830EstadoCanje.LM830pendiente : LM830EstadoCanje.LM830autorizado,
                LM830Vendedor = LM830SessionManager.LM830Instance.LM830UsuarioActual()
            };

            LM830_canjeDAL.LM830Insertar(LM830canje);
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Canje();

            return LM830canje;
        }

        public List<LM830Canje> LM830ListarPendientes() => LM830_canjeDAL.LM830ListarPorEstado(LM830EstadoCanje.LM830pendiente, null);

        public void LM830Resolver(LM830Canje LM830k, bool LM830aprobar, string? LM830motivo)
        {
            LM830motivo = string.IsNullOrWhiteSpace(LM830motivo) ? null : LM830motivo!.Trim();
            if (LM830k.LM830Estado != LM830EstadoCanje.LM830pendiente)
                throw new Exception("El canje no está pendiente de autorización.");
            if (!LM830aprobar && LM830motivo == null)
                throw new Exception("Para rechazar el canje el motivo es obligatorio.");
            if (LM830motivo != null && LM830motivo.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");

            LM830k.LM830Estado = LM830aprobar ? LM830EstadoCanje.LM830autorizado : LM830EstadoCanje.LM830rechazado;
            LM830k.LM830MotivoResolucion = LM830motivo;
            LM830k.LM830Supervisor = LM830SessionManager.LM830Instance.LM830UsuarioActual();
            LM830k.LM830FechaResolucion = LM830BitacoraBLL.LM830AhoraSinMilisegundos();

            try
            {
                LM830_canjeDAL.LM830Resolver(LM830k);
            }
            catch
            {
                LM830k.LM830Estado = LM830EstadoCanje.LM830pendiente;
                LM830k.LM830Supervisor = null;
                LM830k.LM830MotivoResolucion = null;
                LM830k.LM830FechaResolucion = null;
                throw;
            }
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Canje();
        }

        public List<LM830Canje> LM830ListarAutorizados(string? LM830dniCliente)
        {
            LM830dniCliente = string.IsNullOrWhiteSpace(LM830dniCliente) ? null : LM830dniCliente!.Trim();
            return LM830_canjeDAL.LM830ListarPorEstado(LM830EstadoCanje.LM830autorizado, LM830dniCliente);
        }

        public int LM830Entregar(LM830Canje LM830k)
        {
            if (LM830k.LM830Estado != LM830EstadoCanje.LM830autorizado)
                throw new Exception("Solo se pueden entregar canjes autorizados.");

            List<LM830LotePuntos> LM830vigentes;
            int LM830saldo = LM830_loteBLL.LM830ConsultarSaldo(LM830k.LM830Cliente, out LM830vigentes);
            if (LM830saldo < LM830k.LM830PuntosRequeridos)
                throw new Exception($"El cliente ya no tiene saldo suficiente. Saldo vigente: {LM830saldo:N0} pts, requiere: {LM830k.LM830PuntosRequeridos:N0} pts.");

            var LM830lotes = new List<(LM830LotePuntos LM830Lote, int LM830Anterior)>();
            var LM830detalle = new List<LM830DetalleCanje>();
            int LM830resta = LM830k.LM830PuntosRequeridos;
            foreach (LM830LotePuntos LM830lote in LM830vigentes.OrderBy(LM830l => LM830l.LM830FechaVencimiento).ThenBy(LM830l => LM830l.LM830IdLote))
            {
                if (LM830resta == 0) break;
                int LM830descuento = Math.Min(LM830resta, LM830lote.LM830PuntosDisponibles);
                if (LM830descuento <= 0) continue;
                LM830lotes.Add((LM830lote, LM830lote.LM830PuntosDisponibles));
                LM830lote.LM830PuntosDisponibles -= LM830descuento;
                LM830detalle.Add(new LM830DetalleCanje { LM830Lote = LM830lote, LM830PuntosDescontados = LM830descuento });
                LM830resta -= LM830descuento;
            }

            LM830k.LM830Detalle = LM830detalle;
            LM830k.LM830Estado = LM830EstadoCanje.LM830entregado;
            LM830k.LM830FechaEntrega = LM830BitacoraBLL.LM830AhoraSinMilisegundos();

            try
            {
                LM830_canjeDAL.LM830Entregar(LM830k, LM830lotes);
            }
            catch
            {
                foreach (var LM830item in LM830lotes) LM830item.LM830Lote.LM830PuntosDisponibles = LM830item.LM830Anterior;
                LM830k.LM830Detalle = new List<LM830DetalleCanje>();
                LM830k.LM830Estado = LM830EstadoCanje.LM830autorizado;
                LM830k.LM830FechaEntrega = null;
                throw;
            }

            LM830_digitoVerificadorBLL.LM830RecalcularDVV_LotePuntos();
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_DetalleCanje();
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Canje();

            return LM830saldo - LM830k.LM830PuntosRequeridos;
        }

        public LM830Canje? LM830ObtenerPorNro(string LM830nro)
        {
            LM830nro = (LM830nro ?? "").Trim().ToUpperInvariant();
            if (LM830nro.Length == 0) return null;
            return LM830_canjeDAL.LM830ObtenerPorNro(LM830nro);
        }

        public bool LM830DentroDelPlazoDeAnulacion(LM830Canje LM830k) =>
            LM830k.LM830FechaEntrega.HasValue &&
            (DateTime.Today - LM830k.LM830FechaEntrega.Value.Date).TotalDays <= LM830ProgramaPuntosBLL.LM830Obtener().LM830PlazoAnulacionDias;

        public int LM830Anular(LM830Canje LM830k, string? LM830motivo)
        {
            LM830motivo = string.IsNullOrWhiteSpace(LM830motivo) ? null : LM830motivo!.Trim();
            if (LM830k.LM830Estado != LM830EstadoCanje.LM830entregado)
                throw new Exception("Solo se pueden anular canjes entregados.");
            if (!LM830DentroDelPlazoDeAnulacion(LM830k))
                throw new Exception($"El canje está fuera del plazo de anulación ({LM830ProgramaPuntosBLL.LM830Obtener().LM830PlazoAnulacionDias} días).");
            if (LM830motivo == null)
                throw new Exception("Ingrese el motivo de la anulación.");
            if (LM830motivo.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");

            var LM830lotes = new List<(LM830LotePuntos LM830Lote, int LM830Anterior)>();
            int LM830reintegrados = 0;
            foreach (LM830DetalleCanje LM830d in LM830k.LM830Detalle)
            {
                LM830LotePuntos LM830lote = LM830d.LM830Lote;
                int LM830anterior = LM830lote.LM830PuntosDisponibles;
                LM830lote.LM830PuntosDisponibles = Math.Min(LM830lote.LM830PuntosOriginales, LM830lote.LM830PuntosDisponibles + LM830d.LM830PuntosDescontados);
                LM830lotes.Add((LM830lote, LM830anterior));
                LM830reintegrados += LM830lote.LM830PuntosDisponibles - LM830anterior;
            }

            LM830k.LM830Estado = LM830EstadoCanje.LM830anulado;
            LM830k.LM830SupervisorAnulacion = LM830SessionManager.LM830Instance.LM830UsuarioActual();
            LM830k.LM830MotivoAnulacion = LM830motivo;
            LM830k.LM830FechaAnulacion = LM830BitacoraBLL.LM830AhoraSinMilisegundos();

            try
            {
                LM830_canjeDAL.LM830Anular(LM830k, LM830lotes);
            }
            catch
            {
                foreach (var LM830item in LM830lotes) LM830item.LM830Lote.LM830PuntosDisponibles = LM830item.LM830Anterior;
                LM830k.LM830Estado = LM830EstadoCanje.LM830entregado;
                LM830k.LM830SupervisorAnulacion = null;
                LM830k.LM830MotivoAnulacion = null;
                LM830k.LM830FechaAnulacion = null;
                throw;
            }

            LM830_digitoVerificadorBLL.LM830RecalcularDVV_LotePuntos();
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Canje();

            return LM830reintegrados;
        }
    }
}

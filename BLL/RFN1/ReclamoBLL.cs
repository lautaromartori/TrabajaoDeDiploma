using BE.RFN1;
using DAL.RFN1;
using Servicios;
using System;
using System.Collections.Generic;

namespace BLL.RFN1
{
    public class ReclamoBLL
    {
        private const string MODULO = "Reclamos";

        private readonly ReclamoDAL _reclamoDAL = new ReclamoDAL();
        private readonly VentaBLL _ventaBLL = new VentaBLL();
        private readonly NivelBLL _nivelBLL = new NivelBLL();
        private readonly BitacoraBLL _bitacoraBLL = new BitacoraBLL();
        private readonly DigitoVerificadorBLL _digitoVerificadorBLL = new DigitoVerificadorBLL();

        public string MensajeValidacion { get; private set; } = "";

        public bool Validar(Venta v)
        {
            MensajeValidacion = "";
            if (!ValidarSinPuntos(v))
            {
                MensajeValidacion = "La venta ya tiene puntos acreditados. No corresponde el reclamo.";
                return false;
            }
            if (!ValidarPlazo(v))
            {
                MensajeValidacion = $"La compra está fuera de plazo: el reclamo vence a los {ProgramaPuntosBLL.Obtener().PlazoReclamoDias} días.";
                return false;
            }
            if (_reclamoDAL.ExistePendiente(v))
            {
                MensajeValidacion = "Ya hay un reclamo pendiente por esa venta.";
                return false;
            }
            return true;
        }

        public bool ValidarSinPuntos(Venta v) => !v.TieneLote;

        public bool ValidarPlazo(Venta v) =>
            (DateTime.Today - v.Fecha.Date).TotalDays <= ProgramaPuntosBLL.Obtener().PlazoReclamoDias;

        public int CalcularPuntosReclamo(Venta v, Cliente c) => _ventaBLL.CalcularPuntos(v, c);

        public void Registrar(Reclamo r)
        {
            r.Motivo = (r.Motivo ?? "").Trim();
            if (r.Motivo.Length == 0)
                throw new Exception("Ingrese el motivo del reclamo.");
            if (r.Motivo.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");
            if (r.Venta.Cliente != null && r.Venta.Cliente.IdCliente != r.Cliente.IdCliente)
                throw new Exception("La venta está registrada a nombre de otro cliente.");
            if (!Validar(r.Venta))
                throw new Exception(MensajeValidacion);

            r.PuntosReclamados = CalcularPuntosReclamo(r.Venta, r.Cliente);
            if (r.PuntosReclamados <= 0)
                throw new Exception("El monto de la compra no alcanza para generar puntos.");

            r.FechaReclamo = BitacoraBLL.AhoraSinMilisegundos();
            r.Estado = EstadoReclamo.pendiente;
            r.Vendedor = SessionManager.Instance.UsuarioActual();

            _reclamoDAL.Insertar(r);
            _digitoVerificadorBLL.RecalcularDVV_Reclamo();

            RegistrarEvento($"Registrar reclamo {r.IdReclamo} venta {r.Venta.NroComprobante} cliente {r.Cliente.Dni}", 1);
        }

        public List<Reclamo> ListarPendientes() => _reclamoDAL.ListarPendientes();

        public void Resolver(Reclamo r)
        {
            r.MotivoResolucion = string.IsNullOrWhiteSpace(r.MotivoResolucion) ? null : r.MotivoResolucion!.Trim();

            if (r.Estado == EstadoReclamo.pendiente)
                throw new Exception("Elija aprobar o rechazar el reclamo.");
            if (r.Estado == EstadoReclamo.rechazado && r.MotivoResolucion == null)
                throw new Exception("Para rechazar el reclamo el motivo es obligatorio.");
            if (r.MotivoResolucion != null && r.MotivoResolucion.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");

            r.Supervisor = SessionManager.Instance.UsuarioActual();
            r.FechaResolucion = BitacoraBLL.AhoraSinMilisegundos();

            LotePuntos? lote = null;
            if (r.Estado == EstadoReclamo.aprobado)
            {
                lote = ArmarLote(r);
                r.Cliente.Nivel = _nivelBLL.CalcularNivel(r.Cliente, lote.PuntosOriginales);
                r.Cliente.DVH = DigitoVerificador.CalcularDVH(r.Cliente.CadenaDVH());
            }

            _reclamoDAL.Resolver(r, lote);

            _digitoVerificadorBLL.RecalcularDVV_Reclamo();
            if (lote != null)
            {
                _digitoVerificadorBLL.RecalcularDVV_LotePuntos();
                _digitoVerificadorBLL.RecalcularDVV_Cliente();
            }

            string accion = r.Estado == EstadoReclamo.aprobado ? $"Aprobar reclamo {r.IdReclamo} ({r.PuntosReclamados} pts)" : $"Rechazar reclamo {r.IdReclamo}";
            RegistrarEvento(accion, r.Estado == EstadoReclamo.aprobado ? 2 : 1);
        }

        public LotePuntos ArmarLote(Reclamo r)
        {
            ProgramaPuntos programa = ProgramaPuntosBLL.Obtener();
            DateTime hoy = DateTime.Today;
            return new LotePuntos
            {
                IdCliente = r.Cliente.IdCliente,
                IdVenta = null,
                Reclamo = r,
                PuntosOriginales = r.PuntosReclamados,
                PuntosDisponibles = r.PuntosReclamados,
                FechaAcreditacion = hoy,
                FechaVencimiento = hoy.AddMonths(programa.MesesVencimiento),
                Origen = OrigenPuntos.reclamo
            };
        }

        public Nivel CalcularNivel(Cliente c) => _nivelBLL.CalcularNivel(c, 0);

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

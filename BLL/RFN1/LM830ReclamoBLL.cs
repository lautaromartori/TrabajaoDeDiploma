using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830BLL.LM830RFN1
{
    public class LM830ReclamoBLL
    {
        private const string LM830MODULO = "Reclamos";

        private readonly LM830ReclamoDAL LM830_reclamoDAL = new LM830ReclamoDAL();
        private readonly LM830VentaBLL LM830_ventaBLL = new LM830VentaBLL();
        private readonly LM830NivelBLL LM830_nivelBLL = new LM830NivelBLL();
        private readonly LM830DigitoVerificadorBLL LM830_digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

        public string LM830MensajeValidacion { get; private set; } = "";

        public bool LM830Validar(LM830Venta LM830v)
        {
            LM830MensajeValidacion = "";
            if (!LM830ValidarSinPuntos(LM830v))
            {
                LM830MensajeValidacion = "La venta ya tiene puntos acreditados. No corresponde el reclamo.";
                return false;
            }
            if (!LM830ValidarPlazo(LM830v))
            {
                LM830MensajeValidacion = $"La compra está fuera de plazo: el reclamo vence a los {LM830ProgramaPuntosBLL.LM830Obtener().LM830PlazoReclamoDias} días.";
                return false;
            }
            if (LM830_reclamoDAL.LM830ExistePendiente(LM830v))
            {
                LM830MensajeValidacion = "Ya hay un reclamo pendiente por esa venta.";
                return false;
            }
            return true;
        }

        public bool LM830ValidarSinPuntos(LM830Venta LM830v) => !LM830v.LM830TieneLote;

        public bool LM830ValidarPlazo(LM830Venta LM830v) =>
            (DateTime.Today - LM830v.LM830Fecha.Date).TotalDays <= LM830ProgramaPuntosBLL.LM830Obtener().LM830PlazoReclamoDias;

        public int LM830CalcularPuntosReclamo(LM830Venta LM830v, LM830Cliente LM830c) => LM830_ventaBLL.LM830CalcularPuntos(LM830v, LM830c);

        public void LM830Registrar(LM830Reclamo LM830r)
        {
            LM830r.LM830Motivo = (LM830r.LM830Motivo ?? "").Trim();
            if (LM830r.LM830Motivo.Length == 0)
                throw new Exception("Ingrese el motivo del reclamo.");
            if (LM830r.LM830Motivo.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");
            if (LM830r.LM830Venta.LM830Cliente != null && LM830r.LM830Venta.LM830Cliente.LM830IdCliente != LM830r.LM830Cliente.LM830IdCliente)
                throw new Exception("La venta está registrada a nombre de otro cliente.");
            if (!LM830Validar(LM830r.LM830Venta))
                throw new Exception(LM830MensajeValidacion);

            LM830r.LM830PuntosReclamados = LM830CalcularPuntosReclamo(LM830r.LM830Venta, LM830r.LM830Cliente);
            if (LM830r.LM830PuntosReclamados <= 0)
                throw new Exception("El monto de la compra no alcanza para generar puntos.");

            LM830r.LM830FechaReclamo = LM830BitacoraBLL.LM830AhoraSinMilisegundos();
            LM830r.LM830Estado = LM830EstadoReclamo.LM830pendiente;
            LM830r.LM830Vendedor = LM830SessionManager.LM830Instance.LM830UsuarioActual();

            LM830_reclamoDAL.LM830Insertar(LM830r);
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Reclamo();
        }

        public List<LM830Reclamo> LM830ListarPendientes() => LM830_reclamoDAL.LM830ListarPendientes();

        public void LM830Resolver(LM830Reclamo LM830r)
        {
            LM830r.LM830MotivoResolucion = string.IsNullOrWhiteSpace(LM830r.LM830MotivoResolucion) ? null : LM830r.LM830MotivoResolucion!.Trim();

            if (LM830r.LM830Estado == LM830EstadoReclamo.LM830pendiente)
                throw new Exception("Elija aprobar o rechazar el reclamo.");
            if (LM830r.LM830Estado == LM830EstadoReclamo.LM830rechazado && LM830r.LM830MotivoResolucion == null)
                throw new Exception("Para rechazar el reclamo el motivo es obligatorio.");
            if (LM830r.LM830MotivoResolucion != null && LM830r.LM830MotivoResolucion.Length > 200)
                throw new Exception("El motivo no puede superar los 200 caracteres.");

            LM830r.LM830Supervisor = LM830SessionManager.LM830Instance.LM830UsuarioActual();
            LM830r.LM830FechaResolucion = LM830BitacoraBLL.LM830AhoraSinMilisegundos();

            LM830LotePuntos? LM830lote = null;
            if (LM830r.LM830Estado == LM830EstadoReclamo.LM830aprobado)
            {
                LM830lote = LM830ArmarLote(LM830r);
                LM830r.LM830Cliente.LM830Nivel = LM830_nivelBLL.LM830CalcularNivel(LM830r.LM830Cliente, LM830lote.LM830PuntosOriginales);
                LM830r.LM830Cliente.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830r.LM830Cliente.LM830CadenaDVH());
            }

            LM830_reclamoDAL.LM830Resolver(LM830r, LM830lote);

            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Reclamo();
            if (LM830lote != null)
            {
                LM830_digitoVerificadorBLL.LM830RecalcularDVV_LotePuntos();
                LM830_digitoVerificadorBLL.LM830RecalcularDVV_Cliente();
            }
        }

        public LM830LotePuntos LM830ArmarLote(LM830Reclamo LM830r)
        {
            LM830ProgramaPuntos LM830programa = LM830ProgramaPuntosBLL.LM830Obtener();
            DateTime LM830hoy = DateTime.Today;
            return new LM830LotePuntos
            {
                LM830IdCliente = LM830r.LM830Cliente.LM830IdCliente,
                LM830IdVenta = null,
                LM830Reclamo = LM830r,
                LM830PuntosOriginales = LM830r.LM830PuntosReclamados,
                LM830PuntosDisponibles = LM830r.LM830PuntosReclamados,
                LM830FechaAcreditacion = LM830hoy,
                LM830FechaVencimiento = LM830hoy.AddMonths(LM830programa.LM830MesesVencimiento),
                LM830Origen = LM830OrigenPuntos.LM830reclamo
            };
        }

        public LM830Nivel LM830CalcularNivel(LM830Cliente LM830c) => LM830_nivelBLL.LM830CalcularNivel(LM830c, 0);
    }
}

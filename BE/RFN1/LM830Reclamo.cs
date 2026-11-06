using LM830Servicios;
using System;

namespace LM830BE.LM830RFN1
{
    public class LM830Reclamo
    {
        private int LM830idReclamo;
        private LM830Cliente LM830cliente = new LM830Cliente();
        private LM830Venta LM830venta = new LM830Venta();
        private DateTime LM830fechaReclamo;
        private int LM830puntosReclamados;
        private string LM830motivo = "";
        private LM830EstadoReclamo LM830estado = LM830EstadoReclamo.LM830pendiente;
        private LM830Usuario LM830vendedor = new LM830Usuario();
        private LM830Usuario? LM830supervisor;
        private string? LM830motivoResolucion;
        private DateTime? LM830fechaResolucion;
        private string LM830dvh = "";

        public int LM830IdReclamo { get => LM830idReclamo; set => LM830idReclamo = value; }
        public LM830Cliente LM830Cliente { get => LM830cliente; set => LM830cliente = value; }
        public LM830Venta LM830Venta { get => LM830venta; set => LM830venta = value; }
        public DateTime LM830FechaReclamo { get => LM830fechaReclamo; set => LM830fechaReclamo = value; }
        public int LM830PuntosReclamados { get => LM830puntosReclamados; set => LM830puntosReclamados = value; }
        public string LM830Motivo { get => LM830motivo; set => LM830motivo = value; }
        public LM830EstadoReclamo LM830Estado { get => LM830estado; set => LM830estado = value; }
        public LM830Usuario LM830Vendedor { get => LM830vendedor; set => LM830vendedor = value; }
        public LM830Usuario? LM830Supervisor { get => LM830supervisor; set => LM830supervisor = value; }
        public string? LM830MotivoResolucion { get => LM830motivoResolucion; set => LM830motivoResolucion = value; }
        public DateTime? LM830FechaResolucion { get => LM830fechaResolucion; set => LM830fechaResolucion = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdReclamo) + LM830FormatoDV.LM830Entero(LM830Cliente.LM830IdCliente) + LM830FormatoDV.LM830Entero(LM830Venta.LM830IdVenta) +
            LM830FormatoDV.LM830FechaHora(LM830FechaReclamo) + LM830FormatoDV.LM830Entero(LM830PuntosReclamados) + LM830Motivo + LM830Estado.LM830ATexto() +
            LM830FormatoDV.LM830Texto(LM830Vendedor?.LM830DNI) + LM830FormatoDV.LM830Texto(LM830Supervisor?.LM830DNI) + LM830FormatoDV.LM830Texto(LM830MotivoResolucion) +
            LM830FormatoDV.LM830FechaHora(LM830FechaResolucion);
    }
}

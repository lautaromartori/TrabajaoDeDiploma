using Servicios;
using System;

namespace BE.RFN1
{
    public class Reclamo
    {
        private int idReclamo;
        private Cliente cliente = new Cliente();
        private Venta venta = new Venta();
        private DateTime fechaReclamo;
        private int puntosReclamados;
        private string motivo = "";
        private EstadoReclamo estado = EstadoReclamo.pendiente;
        private Usuario vendedor = new Usuario();
        private Usuario? supervisor;
        private string? motivoResolucion;
        private DateTime? fechaResolucion;
        private string dvh = "";

        public int IdReclamo { get => idReclamo; set => idReclamo = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Venta Venta { get => venta; set => venta = value; }
        public DateTime FechaReclamo { get => fechaReclamo; set => fechaReclamo = value; }
        public int PuntosReclamados { get => puntosReclamados; set => puntosReclamados = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public EstadoReclamo Estado { get => estado; set => estado = value; }
        public Usuario Vendedor { get => vendedor; set => vendedor = value; }
        public Usuario? Supervisor { get => supervisor; set => supervisor = value; }
        public string? MotivoResolucion { get => motivoResolucion; set => motivoResolucion = value; }
        public DateTime? FechaResolucion { get => fechaResolucion; set => fechaResolucion = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public string CadenaDVH() =>
            FormatoDV.Entero(IdReclamo) + FormatoDV.Entero(Cliente.IdCliente) + FormatoDV.Entero(Venta.IdVenta) +
            FormatoDV.FechaHora(FechaReclamo) + FormatoDV.Entero(PuntosReclamados) + Motivo + Estado.ToString() +
            FormatoDV.Texto(Vendedor?.DNI) + FormatoDV.Texto(Supervisor?.DNI) + FormatoDV.Texto(MotivoResolucion) +
            FormatoDV.FechaHora(FechaResolucion);
    }
}

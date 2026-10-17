using Servicios;
using System;
using System.Collections.Generic;

namespace BE.RFN1
{
    public class Venta
    {
        private int idVenta;
        private string nroComprobante = "";
        private DateTime fecha;
        private Cliente? cliente;
        private Usuario vendedor = new Usuario();
        private decimal total;
        private int puntosAcreditados;
        private List<DetalleVenta> detalle = new List<DetalleVenta>();
        private bool tieneLote;
        private LotePuntos? lote;
        private string dvh = "";

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string NroComprobante { get => nroComprobante; set => nroComprobante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Cliente? Cliente { get => cliente; set => cliente = value; }
        public Usuario Vendedor { get => vendedor; set => vendedor = value; }
        public decimal Total { get => total; set => total = value; }
        public int PuntosAcreditados { get => puntosAcreditados; set => puntosAcreditados = value; }
        public List<DetalleVenta> Detalle { get => detalle; set => detalle = value; }
        public bool TieneLote { get => tieneLote; set => tieneLote = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public LotePuntos? Lote { get => lote; set => lote = value; }

        public string CadenaDVH() =>
            FormatoDV.Entero(IdVenta) + NroComprobante + FormatoDV.FechaHora(Fecha) +
            FormatoDV.Entero(Cliente?.IdCliente) + FormatoDV.Texto(Vendedor?.DNI) +
            FormatoDV.Importe(Total) + FormatoDV.Entero(PuntosAcreditados);
    }
}

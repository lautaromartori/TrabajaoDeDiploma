using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830BE.LM830RFN1
{
    public class LM830Venta
    {
        private int LM830idVenta;
        private string LM830nroComprobante = "";
        private DateTime LM830fecha;
        private LM830Cliente? LM830cliente;
        private LM830Usuario LM830vendedor = new LM830Usuario();
        private decimal LM830total;
        private int LM830puntosAcreditados;
        private List<LM830DetalleVenta> LM830detalle = new List<LM830DetalleVenta>();
        private bool LM830tieneLote;
        private LM830LotePuntos? LM830lote;
        private string LM830dvh = "";

        public int LM830IdVenta { get => LM830idVenta; set => LM830idVenta = value; }
        public string LM830NroComprobante { get => LM830nroComprobante; set => LM830nroComprobante = value; }
        public DateTime LM830Fecha { get => LM830fecha; set => LM830fecha = value; }
        public LM830Cliente? LM830Cliente { get => LM830cliente; set => LM830cliente = value; }
        public LM830Usuario LM830Vendedor { get => LM830vendedor; set => LM830vendedor = value; }
        public decimal LM830Total { get => LM830total; set => LM830total = value; }
        public int LM830PuntosAcreditados { get => LM830puntosAcreditados; set => LM830puntosAcreditados = value; }
        public List<LM830DetalleVenta> LM830Detalle { get => LM830detalle; set => LM830detalle = value; }
        public bool LM830TieneLote { get => LM830tieneLote; set => LM830tieneLote = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public LM830LotePuntos? LM830Lote { get => LM830lote; set => LM830lote = value; }

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdVenta) + LM830NroComprobante + LM830FormatoDV.LM830FechaHora(LM830Fecha) +
            LM830FormatoDV.LM830Entero(LM830Cliente?.LM830IdCliente) + LM830FormatoDV.LM830Texto(LM830Vendedor?.LM830DNI) +
            LM830FormatoDV.LM830Importe(LM830Total) + LM830FormatoDV.LM830Entero(LM830PuntosAcreditados);
    }
}

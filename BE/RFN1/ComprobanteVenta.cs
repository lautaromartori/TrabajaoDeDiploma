using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BE.RFN1
{
    [Serializable]
    [XmlRoot("ComprobanteVenta")]
    public class ComprobanteVenta
    {
        public string Comercio { get; set; } = "";
        public string NroComprobante { get; set; } = "";
        public DateTime Fecha { get; set; }
        public string Vendedor { get; set; } = "";
        public string DniCliente { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string Nivel { get; set; } = "";
        public decimal Total { get; set; }
        public int PuntosAcreditados { get; set; }
        public int SaldoVigente { get; set; }
        public DateTime FechaEmision { get; set; }

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<ItemComprobante> Items { get; set; } = new List<ItemComprobante>();

        public bool TieneCliente() => DniCliente.Length > 0;
    }

    [Serializable]
    public class ItemComprobante
    {
        public string Producto { get; set; } = "";
        public string Categoria { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Puntos { get; set; }
    }
}

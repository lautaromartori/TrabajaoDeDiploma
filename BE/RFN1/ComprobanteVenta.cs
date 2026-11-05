using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LM830BE.LM830RFN1
{
    [Serializable]
    [XmlRoot("ComprobanteVenta")]
    public class LM830ComprobanteVenta
    {
        public string LM830Comercio { get; set; } = "";
        public string LM830NroComprobante { get; set; } = "";
        public DateTime LM830Fecha { get; set; }
        public string LM830Vendedor { get; set; } = "";
        public string LM830DniCliente { get; set; } = "";
        public string LM830Cliente { get; set; } = "";
        public string LM830Nivel { get; set; } = "";
        public decimal LM830Total { get; set; }
        public int LM830PuntosAcreditados { get; set; }
        public int LM830SaldoVigente { get; set; }
        public DateTime LM830FechaEmision { get; set; }

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<LM830ItemComprobante> LM830Items { get; set; } = new List<LM830ItemComprobante>();

        public bool LM830TieneCliente() => LM830DniCliente.Length > 0;
    }

    [Serializable]
    public class LM830ItemComprobante
    {
        public string LM830Producto { get; set; } = "";
        public string LM830Categoria { get; set; } = "";
        public int LM830Cantidad { get; set; }
        public decimal LM830PrecioUnitario { get; set; }
        public decimal LM830Subtotal { get; set; }
        public int LM830Puntos { get; set; }
    }
}

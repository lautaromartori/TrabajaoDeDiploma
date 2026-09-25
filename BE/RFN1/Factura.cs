using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE.RFN1
{
    public class Factura
    {
        public int Id { get; set; }
        public Proveedor Proveedor { get; set; } = new Proveedor();
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string TipoComprobante { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}

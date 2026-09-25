using System;
using System.Collections.Generic;
using System.Text;

namespace BE.RFN1
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public Producto Producto { get; set; } = new Producto();
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Subtotal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BE.RFN1
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal ImpuestoPorcentaje { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BE.RFN1
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}

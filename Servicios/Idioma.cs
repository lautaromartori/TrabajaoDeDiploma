using System;
using System.Collections.Generic;
using System.Text;

namespace LM830Servicios
{
    public class LM830Idioma
    {
        public string LM830DNI { get; set; }
        public string LM830UserName { get; set; }
        public string LM830CodigoIdioma { get; set; }
        public string LM830DVH { get; set; }

        public LM830Idioma()
        {
        }
        public LM830Idioma(string LM830userName, string LM830codIdioma, string LM830dVH)
        {
            LM830UserName = LM830userName;
            LM830CodigoIdioma = LM830codIdioma;
            LM830DVH = LM830dVH;
        }
    }
}

using LM830DAL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LM830BLL
{
    public class LM830IdiomaBLL
    {
        private readonly LM830IdiomaDAL LM830_idiomaDAL;
        private readonly LM830BitacoraBLL LM830bll;
        private readonly LM830DigitoVerificadorBLL LM830digitoVerificadorBLL = new LM830DigitoVerificadorBLL();
        private const string LM830MODULO_BITACORA = "Idioma";

        public LM830IdiomaBLL()
        {
            LM830_idiomaDAL = new LM830IdiomaDAL();
            LM830bll = new LM830BitacoraBLL();
        }

        public string LM830ObtenerIdioma(string LM830userName)
        {
            return LM830_idiomaDAL.LM830ObtenerIdioma(LM830userName);
        }

        public void LM830GuardarIdioma(string LM830userName, string LM830idioma)
        {
            string LM830cadenaDHV = $"{LM830userName}{LM830idioma}";

            LM830_idiomaDAL.LM830GuardarIdioma(LM830userName, LM830idioma, LM830DigitoVerificador.LM830CalcularDVH(LM830cadenaDHV));
            LM830digitoVerificadorBLL.LM830RecalcularDVV_Idioma();
            LM830Bitacora LM830bita = new LM830Bitacora();
            LM830bita.LM830Criticidad = 5;
            LM830bita.LM830Modulo = LM830MODULO_BITACORA;
            LM830bita.LM830Evento = $"Se guardo el idioma {LM830idioma}";
            LM830bita.LM830Login = LM830userName;
            LM830bll.LM830RegistrarEvento(LM830bita);
        }
    }
}

using LM830DAL;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830BLL
{
    public class LM830BitacoraBLL
    {
        LM830BitacoraDAL LM830DAL;
        LM830DigitoVerificadorBLL LM830digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

        public LM830BitacoraBLL()
        {
            LM830DAL = new LM830BitacoraDAL();
        }

        public void LM830RegistrarEvento(LM830Bitacora LM830unEvento)
        {
            try
            {
                LM830unEvento.LM830Fecha = LM830AhoraSinMilisegundos();
                string LM830cadenaDVH = LM830DigitoVerificadorBLL.LM830CadenaDVH_Bitacora(LM830unEvento);

                LM830DAL.LM830RegistrarEvento(LM830unEvento, LM830DigitoVerificador.LM830CalcularDVH(LM830cadenaDVH));
                LM830digitoVerificadorBLL.LM830RecalcularDVV_Bitacora();
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitBlltext1"), LM830ex);
            }
        }

        public static DateTime LM830AhoraSinMilisegundos()
        {
            DateTime LM830ahora = DateTime.Now;
            return new DateTime(LM830ahora.Ticks - (LM830ahora.Ticks % TimeSpan.TicksPerSecond), LM830ahora.Kind);
        }

        public List<LM830Bitacora> LM830FiltrarEventos(string LM830nombre, string LM830apellido, string LM830login, string LM830modulo, string LM830evento, DateTime LM830desde, DateTime LM830hasta, int? LM830criticidad)
        {
            try
            {
                if (LM830desde > LM830hasta)
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitBlltext2"));

                if (LM830modulo == "Todos") LM830modulo = null;

                return LM830DAL.LM830FiltrarEventos(LM830nombre, LM830apellido, LM830login, LM830modulo, LM830evento, LM830desde, LM830hasta, LM830criticidad);
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitBlltext3"), LM830ex);
            }
        }

        public List<string> LM830ObtenerLogins()
        {
            try
            {
                return LM830DAL.LM830ObtenerLogins();
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitBlltext4"), LM830ex);
            }
        }

        public LM830Usuario LM830ObtenerUsuarioPorLogin(string LM830login)
        {
            try
            {
                return LM830DAL.LM830ObtenerUsuarioPorLogin(LM830login);
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitBlltext5"), LM830ex);
            }
        }
    }
}

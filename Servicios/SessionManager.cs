namespace LM830Servicios
{
    public class LM830SessionManager
    {
        private static LM830SessionManager LM830_instance;

        private LM830Usuario LM830_usuarioLogueado;

        private LM830SessionManager()
        {
            LM830_usuarioLogueado = null;
        }

        public static LM830SessionManager LM830Instance
        {
            get
            {
                if (LM830_instance == null)
                {
                    LM830_instance = new LM830SessionManager();
                }
                return LM830_instance;
            }
        }

        public void LM830Loguear(LM830Usuario LM830usuario)
        {
            if (LM830Logueado())
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserLogueado"));
            }
            LM830_usuarioLogueado = LM830usuario;
        }

        public void LM830Desloguear()
        {
            if (!LM830Logueado())
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserNoLogueado"));
            }
            LM830_usuarioLogueado = null;
        }

        public bool LM830Logueado()
        {
            return LM830_usuarioLogueado != null;
        }

        public LM830Usuario LM830UsuarioActual()
        {
            if (!LM830Logueado())
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserNoLogueado"));
            }
            return LM830_usuarioLogueado;
        }
    }
}

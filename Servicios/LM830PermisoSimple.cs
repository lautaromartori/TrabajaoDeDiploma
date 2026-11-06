using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830Servicios
{
    public class LM830PermisoSimple : LM830ComponentePermiso
    {
        public override void LM830AgregarHijo(LM830ComponentePermiso LM830hijo)
        {
            throw new NotImplementedException(LM830LanguageManager.LM830Instance.LM830GetTraduction("PerSimText1"));
        }

        public override void LM830QuitarHijo(LM830ComponentePermiso LM830hijo)
        {
            throw new NotImplementedException(LM830LanguageManager.LM830Instance.LM830GetTraduction("PerSimText2"));
        }

        public override List<LM830ComponentePermiso> LM830ObtenerHijos()
        {
            return new List<LM830ComponentePermiso>();
        }
        public override bool LM830TienePermiso(string LM830nombrePermiso)
        {
            return this.LM830Nombre != null && this.LM830Nombre.Equals(LM830nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }
    }
}

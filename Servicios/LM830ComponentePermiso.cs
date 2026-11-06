using System;
using System.Collections.Generic;

namespace LM830Servicios
{
    public abstract class LM830ComponentePermiso
    {
        public string LM830Nombre { get; set; }
        public string LM830DVH { get; set; }

        public abstract void LM830AgregarHijo(LM830ComponentePermiso LM830hijo);
        public abstract void LM830QuitarHijo(LM830ComponentePermiso LM830hijo);
        public abstract List<LM830ComponentePermiso> LM830ObtenerHijos();

        public abstract bool LM830TienePermiso(string LM830nombrePermiso);
    }
}

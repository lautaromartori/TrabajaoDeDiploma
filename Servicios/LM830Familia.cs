using System;
using System.Collections.Generic;

namespace LM830Servicios
{
    public class LM830Familia : LM830ComponentePermiso
    {
        public bool LM830EsRol { get; set; }
        private List<LM830ComponentePermiso> LM830_hijos = new List<LM830ComponentePermiso>();

        public List<LM830ComponentePermiso> LM830ListaHijos
        {
            get { return LM830_hijos; }
            set { LM830_hijos = value; }
        }

        public override void LM830AgregarHijo(LM830ComponentePermiso LM830hijo)
        {
            if (LM830hijo != null && !LM830_hijos.Contains(LM830hijo))
            {
                LM830_hijos.Add(LM830hijo);
            }
        }

        public override void LM830QuitarHijo(LM830ComponentePermiso LM830hijo)
        {
            if (LM830hijo != null && LM830_hijos.Contains(LM830hijo))
            {
                LM830_hijos.Remove(LM830hijo);
            }
        }

        public override List<LM830ComponentePermiso> LM830ObtenerHijos()
        {
            return LM830_hijos;
        }

        public override bool LM830TienePermiso(string LM830nombrePermiso)
        {
            if (this.LM830Nombre != null && this.LM830Nombre.Equals(LM830nombrePermiso, StringComparison.OrdinalIgnoreCase))
                return true;

            foreach (var LM830hijo in LM830_hijos)
            {
                if (LM830hijo.LM830TienePermiso(LM830nombrePermiso))
                    return true;
            }

            return false;
        }
    }
}

using Servicios;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class PermisoSimple : ComponentePermiso
    {
        public override void AgregarHijo(ComponentePermiso hijo)
        {
            throw new NotImplementedException(LanguageManager.Instance.GetTraduction("PerSimText1"));
        }

        public override void QuitarHijo(ComponentePermiso hijo)
        {
            throw new NotImplementedException(LanguageManager.Instance.GetTraduction("PerSimText2"));
        }

        public override List<ComponentePermiso> ObtenerHijos()
        {
            return new List<ComponentePermiso>();
        }
        public override bool TienePermiso(string nombrePermiso)
        {
            return this.Nombre != null && this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }
    }
}

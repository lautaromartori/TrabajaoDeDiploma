using System;
using System.Collections.Generic;
using System.Text;

namespace LM830Servicios
{
    public enum LM830EstadoAsignacion
    {
        LM830Ok,
        LM830ConflictoPermisos
    }

    public class LM830ResultadoAsignacion
    {
        public LM830EstadoAsignacion LM830Estado { get; set; }

        public List<string> LM830PermisosConflictivos { get; set; } = new List<string>();

        public Dictionary<string, string> LM830OrigenConflicto { get; set; }
            = new Dictionary<string, string>();
    }
}

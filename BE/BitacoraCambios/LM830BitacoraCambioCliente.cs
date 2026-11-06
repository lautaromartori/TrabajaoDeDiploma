using System;

namespace LM830BE.LM830BitacoraCambios
{
    
    public class LM830BitacoraCambioCliente
    {
        public int LM830IdCambio { get; set; }
        public int LM830IdCliente { get; set; }
        public string LM830Dni { get; set; } = "";
        public string LM830Nombre { get; set; } = "";
        public string LM830Apellido { get; set; } = "";
        public string LM830Email { get; set; } = "";
        public string LM830Telefono { get; set; } = "";
        public DateTime LM830FechaInscripcion { get; set; }
        public int LM830IdNivel { get; set; }
        public DateTime LM830FechaCambio { get; set; }
        public string LM830Operacion { get; set; } = "";
        public string LM830Usuario { get; set; } = "";
        public bool LM830Activo { get; set; }
    }
}

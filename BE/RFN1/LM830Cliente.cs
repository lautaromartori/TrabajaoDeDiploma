using System;

namespace LM830BE.LM830RFN1
{
    public class LM830Cliente
    {
        private int LM830idCliente;
        private string LM830dni = "";
        private string LM830nombre = "";
        private string LM830apellido = "";
        private string LM830email = "";
        private string LM830telefono = "";
        private DateTime LM830fechaInscripcion;
        private LM830Nivel LM830nivel = new LM830Nivel();
        private string LM830dvh = "";

        public int LM830IdCliente { get => LM830idCliente; set => LM830idCliente = value; }
        public string LM830Dni { get => LM830dni; set => LM830dni = value; }
        public string LM830Nombre { get => LM830nombre; set => LM830nombre = value; }
        public string LM830Apellido { get => LM830apellido; set => LM830apellido = value; }
        public string LM830Email { get => LM830email; set => LM830email = value; }
        public string LM830Telefono { get => LM830telefono; set => LM830telefono = value; }
        public DateTime LM830FechaInscripcion { get => LM830fechaInscripcion; set => LM830fechaInscripcion = value; }
        public LM830Nivel LM830Nivel { get => LM830nivel; set => LM830nivel = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public string LM830NombreCompleto => $"{LM830Apellido}, {LM830Nombre}";

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdCliente) + LM830Dni + LM830Nombre + LM830Apellido + LM830Email + LM830Telefono +
            LM830FormatoDV.LM830Fecha(LM830FechaInscripcion) + LM830FormatoDV.LM830Entero(LM830Nivel.LM830IdNivel);

        public override string ToString() => $"{LM830Dni} - {LM830NombreCompleto}";
    }
}

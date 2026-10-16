using System;

namespace BE.RFN1
{
    public class Cliente
    {
        private int idCliente;
        private string dni = "";
        private string nombre = "";
        private string apellido = "";
        private string email = "";
        private string telefono = "";
        private DateTime fechaInscripcion;
        private Nivel nivel = new Nivel();
        private string dvh = "";

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public Nivel Nivel { get => nivel; set => nivel = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public string NombreCompleto => $"{Apellido}, {Nombre}";

        // Columnas que entran en el DVH.
        public string CadenaDVH() =>
            FormatoDV.Entero(IdCliente) + Dni + Nombre + Apellido + Email + Telefono +
            FormatoDV.Fecha(FechaInscripcion) + FormatoDV.Entero(Nivel.IdNivel);

        public override string ToString() => $"{Dni} - {NombreCompleto}";
    }
}

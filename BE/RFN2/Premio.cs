namespace BE.RFN2
{
    public class Premio
    {
        private int idPremio;
        private string nombre = "";
        private string descripcion = "";
        private int puntosRequeridos;
        private int stock;
        private decimal valorReferencia;

        public int IdPremio { get => idPremio; set => idPremio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int PuntosRequeridos { get => puntosRequeridos; set => puntosRequeridos = value; }
        public int Stock { get => stock; set => stock = value; }
        public decimal ValorReferencia { get => valorReferencia; set => valorReferencia = value; }

        public override string ToString() => Nombre;
    }
}

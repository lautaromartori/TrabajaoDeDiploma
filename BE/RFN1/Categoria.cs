namespace BE.RFN1
{
    public class Categoria
    {
        private int idCategoria;
        private string nombre = "";
        private decimal multiplicador;

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Multiplicador { get => multiplicador; set => multiplicador = value; }

        public override string ToString() => Nombre;
    }
}

namespace LM830BE.LM830RFN1
{
    public class LM830Categoria
    {
        private int LM830idCategoria;
        private string LM830nombre = "";
        private decimal LM830multiplicador;

        public int LM830IdCategoria { get => LM830idCategoria; set => LM830idCategoria = value; }
        public string LM830Nombre { get => LM830nombre; set => LM830nombre = value; }
        public decimal LM830Multiplicador { get => LM830multiplicador; set => LM830multiplicador = value; }

        public override string ToString() => LM830Nombre;
    }
}

namespace BE.RFN1
{
    public class Producto
    {
        private int idProducto;
        private string nombre = "";
        private decimal precio;
        private Categoria categoria = new Categoria();

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }

        public override string ToString() => Nombre;
    }
}

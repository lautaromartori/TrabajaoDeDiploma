namespace LM830BE.LM830RFN1
{
    public class LM830Producto
    {
        private int LM830idProducto;
        private string LM830nombre = "";
        private decimal LM830precio;
        private LM830Categoria LM830categoria = new LM830Categoria();

        public int LM830IdProducto { get => LM830idProducto; set => LM830idProducto = value; }
        public string LM830Nombre { get => LM830nombre; set => LM830nombre = value; }
        public decimal LM830Precio { get => LM830precio; set => LM830precio = value; }
        public LM830Categoria LM830Categoria { get => LM830categoria; set => LM830categoria = value; }

        public override string ToString() => LM830Nombre;
    }
}

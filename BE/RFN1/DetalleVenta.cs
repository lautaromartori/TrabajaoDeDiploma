namespace LM830BE.LM830RFN1
{
    public class LM830DetalleVenta
    {
        private int LM830idDetalle;
        private int LM830idVenta;
        private LM830Producto LM830producto = new LM830Producto();
        private int LM830cantidad;
        private decimal LM830precioUnitario;
        private decimal LM830subtotal;
        private int LM830puntosCalculados;
        private string LM830dvh = "";

        public int LM830IdDetalle { get => LM830idDetalle; set => LM830idDetalle = value; }
        public int LM830IdVenta { get => LM830idVenta; set => LM830idVenta = value; }
        public LM830Producto LM830Producto { get => LM830producto; set => LM830producto = value; }
        public int LM830Cantidad { get => LM830cantidad; set => LM830cantidad = value; }
        public decimal LM830PrecioUnitario { get => LM830precioUnitario; set => LM830precioUnitario = value; }
        public decimal LM830Subtotal { get => LM830subtotal; set => LM830subtotal = value; }
        public int LM830PuntosCalculados { get => LM830puntosCalculados; set => LM830puntosCalculados = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdDetalle) + LM830FormatoDV.LM830Entero(LM830IdVenta) + LM830FormatoDV.LM830Entero(LM830Producto.LM830IdProducto) +
            LM830FormatoDV.LM830Entero(LM830Cantidad) + LM830FormatoDV.LM830Importe(LM830PrecioUnitario) + LM830FormatoDV.LM830Importe(LM830Subtotal) +
            LM830FormatoDV.LM830Entero(LM830PuntosCalculados);
    }
}

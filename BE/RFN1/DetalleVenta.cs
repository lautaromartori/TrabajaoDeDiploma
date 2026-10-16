namespace BE.RFN1
{
    public class DetalleVenta
    {
        private int idDetalle;
        private int idVenta;
        private Producto producto = new Producto();
        private int cantidad;
        private decimal precioUnitario;
        private decimal subtotal;
        private int puntosCalculados;
        private string dvh = "";

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public int PuntosCalculados { get => puntosCalculados; set => puntosCalculados = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public string CadenaDVH() =>
            FormatoDV.Entero(IdDetalle) + FormatoDV.Entero(IdVenta) + FormatoDV.Entero(Producto.IdProducto) +
            FormatoDV.Entero(Cantidad) + FormatoDV.Importe(PrecioUnitario) + FormatoDV.Importe(Subtotal) +
            FormatoDV.Entero(PuntosCalculados);
    }
}

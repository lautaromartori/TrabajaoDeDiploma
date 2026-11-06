using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;
using LM830Servicios;
using System;
using System.Linq;

namespace LM830BLL.LM830RFN1
{
    public class LM830VentaBLL
    {
        private const string LM830MODULO = "Ventas";

        private readonly LM830VentaDAL LM830_ventaDAL = new LM830VentaDAL();
        private readonly LM830NivelBLL LM830_nivelBLL = new LM830NivelBLL();
        private readonly LM830DigitoVerificadorBLL LM830_digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

        public LM830Venta LM830VentaActual { get; private set; } = new LM830Venta();

        public LM830Nivel? LM830NivelAnterior { get; private set; }

        public void LM830NuevaVenta(LM830Cliente? LM830cliente)
        {
            LM830VentaActual = new LM830Venta { LM830Cliente = LM830cliente };
            LM830NivelAnterior = null;
        }

        public void LM830AsignarCliente(LM830Cliente? LM830cliente)
        {
            LM830VentaActual.LM830Cliente = LM830cliente;
        }

        public void LM830AgregarItem(LM830DetalleVenta LM830i)
        {
            if (LM830i.LM830Producto == null || LM830i.LM830Producto.LM830IdProducto == 0)
                throw new Exception("Busque un producto existente antes de agregarlo.");
            if (LM830i.LM830Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            LM830DetalleVenta? LM830existente = LM830VentaActual.LM830Detalle.FirstOrDefault(LM830d => LM830d.LM830Producto.LM830IdProducto == LM830i.LM830Producto.LM830IdProducto);
            if (LM830existente != null)
            {
                LM830existente.LM830Cantidad += LM830i.LM830Cantidad;
                LM830existente.LM830Subtotal = LM830existente.LM830PrecioUnitario * LM830existente.LM830Cantidad;
            }
            else
            {
                LM830i.LM830PrecioUnitario = LM830i.LM830Producto.LM830Precio;
                LM830i.LM830Subtotal = LM830i.LM830PrecioUnitario * LM830i.LM830Cantidad;
                LM830VentaActual.LM830Detalle.Add(LM830i);
            }
            LM830RecalcularTotal(LM830VentaActual);
        }

        public void LM830QuitarItem(LM830DetalleVenta LM830i)
        {
            LM830VentaActual.LM830Detalle.Remove(LM830i);
            LM830RecalcularTotal(LM830VentaActual);
        }

        private static void LM830RecalcularTotal(LM830Venta LM830v)
        {
            LM830v.LM830Total = LM830v.LM830Detalle.Sum(LM830d => LM830d.LM830Subtotal);
        }

        public int LM830CalcularPuntos(LM830Venta LM830v, LM830Cliente? LM830c)
        {
            if (LM830c == null)
            {
                foreach (LM830DetalleVenta LM830d in LM830v.LM830Detalle) LM830d.LM830PuntosCalculados = 0;
                return 0;
            }

            decimal LM830total = 0;
            foreach (LM830DetalleVenta LM830d in LM830v.LM830Detalle)
            {
                decimal LM830puntosItem = LM830AplicarReglas(LM830d, LM830c);
                LM830d.LM830PuntosCalculados = (int)Math.Floor(LM830puntosItem);
                LM830total += LM830puntosItem;
            }
            return (int)Math.Floor(LM830total);
        }

        private static decimal LM830AplicarReglas(LM830DetalleVenta LM830d, LM830Cliente LM830c)
        {
            LM830ProgramaPuntos LM830programa = LM830ProgramaPuntosBLL.LM830Obtener();
            if (LM830programa.LM830MontoPorPunto <= 0) return 0;
            return LM830d.LM830Subtotal / LM830programa.LM830MontoPorPunto * LM830d.LM830Producto.LM830Categoria.LM830Multiplicador * LM830c.LM830Nivel.LM830Multiplicador;
        }

        public LM830Nivel LM830CalcularNivel(LM830Cliente LM830c) => LM830_nivelBLL.LM830CalcularNivel(LM830c, 0);

        public void LM830RegistrarVenta(LM830Venta LM830v)
        {
            if (LM830v.LM830Detalle.Count == 0)
                throw new Exception("La venta no tiene ítems.");

            LM830Usuario LM830vendedor = LM830SessionManager.LM830Instance.LM830UsuarioActual();
            LM830v.LM830Vendedor = LM830vendedor;
            LM830v.LM830Fecha = LM830BitacoraBLL.LM830AhoraSinMilisegundos();
            LM830v.LM830PuntosAcreditados = LM830CalcularPuntos(LM830v, LM830v.LM830Cliente);
            LM830v.LM830Lote = null;
            LM830NivelAnterior = null;

            if (LM830v.LM830Cliente != null)
            {
                if (LM830v.LM830PuntosAcreditados > 0)
                {
                    LM830v.LM830Lote = LM830ArmarLote(LM830v);
                }

                LM830Nivel LM830nivelActual = LM830v.LM830Cliente.LM830Nivel;
                LM830Nivel LM830nivelNuevo = LM830_nivelBLL.LM830CalcularNivel(LM830v.LM830Cliente, LM830v.LM830PuntosAcreditados);
                if (LM830nivelNuevo.LM830IdNivel != LM830nivelActual.LM830IdNivel)
                {
                    LM830NivelAnterior = LM830nivelActual;
                }
                LM830v.LM830Cliente.LM830Nivel = LM830nivelNuevo;
                LM830v.LM830Cliente.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830v.LM830Cliente.LM830CadenaDVH());
            }

            try
            {
                LM830_ventaDAL.LM830Guardar(LM830v);
            }
            catch (Exception LM830ex)
            {
                if (LM830NivelAnterior != null && LM830v.LM830Cliente != null) LM830v.LM830Cliente.LM830Nivel = LM830NivelAnterior;
                LM830NivelAnterior = null;
                throw new Exception("No se pudo grabar la venta. No se acreditaron puntos. " + LM830ex.Message, LM830ex);
            }

            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Venta();
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_DetalleVenta();
            if (LM830v.LM830Cliente != null)
            {
                LM830_digitoVerificadorBLL.LM830RecalcularDVV_LotePuntos();
                LM830_digitoVerificadorBLL.LM830RecalcularDVV_Cliente();
            }
        }

        private static LM830LotePuntos LM830ArmarLote(LM830Venta LM830v)
        {
            LM830ProgramaPuntos LM830programa = LM830ProgramaPuntosBLL.LM830Obtener();
            return new LM830LotePuntos
            {
                LM830IdCliente = LM830v.LM830Cliente!.LM830IdCliente,
                LM830PuntosOriginales = LM830v.LM830PuntosAcreditados,
                LM830PuntosDisponibles = LM830v.LM830PuntosAcreditados,
                LM830FechaAcreditacion = LM830v.LM830Fecha.Date,
                LM830FechaVencimiento = LM830v.LM830Fecha.Date.AddMonths(LM830programa.LM830MesesVencimiento),
                LM830Origen = LM830OrigenPuntos.LM830venta
            };
        }

        public LM830Venta? LM830ObtenerPorNro(string LM830nro)
        {
            LM830nro = (LM830nro ?? "").Trim().ToUpperInvariant();
            if (LM830nro.Length == 0) return null;
            return LM830_ventaDAL.LM830ObtenerPorNro(LM830nro);
        }


        internal static string LM830Recortar(string LM830texto, int LM830largo) =>
            LM830texto.Length <= LM830largo ? LM830texto : LM830texto.Substring(0, LM830largo);
    }
}

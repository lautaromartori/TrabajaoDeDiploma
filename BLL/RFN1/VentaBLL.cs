using BE.RFN1;
using DAL.RFN1;
using Servicios;
using System;
using System.Linq;

namespace BLL.RFN1
{
    public class VentaBLL
    {
        private const string MODULO = "Ventas";

        private readonly VentaDAL _ventaDAL = new VentaDAL();
        private readonly NivelBLL _nivelBLL = new NivelBLL();
        private readonly BitacoraBLL _bitacoraBLL = new BitacoraBLL();
        private readonly DigitoVerificadorBLL _digitoVerificadorBLL = new DigitoVerificadorBLL();

        public Venta VentaActual { get; private set; } = new Venta();

        public Nivel? NivelAnterior { get; private set; }

        public void NuevaVenta(Cliente? cliente)
        {
            VentaActual = new Venta { Cliente = cliente };
            NivelAnterior = null;
        }

        public void AsignarCliente(Cliente? cliente)
        {
            VentaActual.Cliente = cliente;
        }

        public void AgregarItem(DetalleVenta i)
        {
            if (i.Producto == null || i.Producto.IdProducto == 0)
                throw new Exception("Busque un producto existente antes de agregarlo.");
            if (i.Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            DetalleVenta? existente = VentaActual.Detalle.FirstOrDefault(d => d.Producto.IdProducto == i.Producto.IdProducto);
            if (existente != null)
            {
                existente.Cantidad += i.Cantidad;
                existente.Subtotal = existente.PrecioUnitario * existente.Cantidad;
            }
            else
            {
                i.PrecioUnitario = i.Producto.Precio;
                i.Subtotal = i.PrecioUnitario * i.Cantidad;
                VentaActual.Detalle.Add(i);
            }
            RecalcularTotal(VentaActual);
        }

        public void QuitarItem(DetalleVenta i)
        {
            VentaActual.Detalle.Remove(i);
            RecalcularTotal(VentaActual);
        }

        private static void RecalcularTotal(Venta v)
        {
            v.Total = v.Detalle.Sum(d => d.Subtotal);
        }

        public int CalcularPuntos(Venta v, Cliente? c)
        {
            if (c == null)
            {
                foreach (DetalleVenta d in v.Detalle) d.PuntosCalculados = 0;
                return 0;
            }

            decimal total = 0;
            foreach (DetalleVenta d in v.Detalle)
            {
                decimal puntosItem = AplicarReglas(d, c);
                d.PuntosCalculados = (int)Math.Floor(puntosItem);
                total += puntosItem;
            }
            return (int)Math.Floor(total);
        }

        private static decimal AplicarReglas(DetalleVenta d, Cliente c)
        {
            ProgramaPuntos programa = ProgramaPuntosBLL.Obtener();
            if (programa.MontoPorPunto <= 0) return 0;
            return d.Subtotal / programa.MontoPorPunto * d.Producto.Categoria.Multiplicador * c.Nivel.Multiplicador;
        }

        public Nivel CalcularNivel(Cliente c) => _nivelBLL.CalcularNivel(c, 0);

        public void RegistrarVenta(Venta v)
        {
            if (v.Detalle.Count == 0)
                throw new Exception("La venta no tiene ítems.");

            Usuario vendedor = SessionManager.Instance.UsuarioActual();
            v.Vendedor = vendedor;
            v.Fecha = BitacoraBLL.AhoraSinMilisegundos();
            v.PuntosAcreditados = CalcularPuntos(v, v.Cliente);
            v.Lote = null;
            NivelAnterior = null;

            if (v.Cliente != null)
            {
                if (v.PuntosAcreditados > 0)
                {
                    v.Lote = ArmarLote(v);
                }

                Nivel nivelActual = v.Cliente.Nivel;
                Nivel nivelNuevo = _nivelBLL.CalcularNivel(v.Cliente, v.PuntosAcreditados);
                if (nivelNuevo.IdNivel != nivelActual.IdNivel)
                {
                    NivelAnterior = nivelActual;
                }
                v.Cliente.Nivel = nivelNuevo;
                v.Cliente.DVH = DigitoVerificador.CalcularDVH(v.Cliente.CadenaDVH());
            }

            try
            {
                _ventaDAL.Guardar(v);
            }
            catch (Exception ex)
            {
                if (NivelAnterior != null && v.Cliente != null) v.Cliente.Nivel = NivelAnterior;
                NivelAnterior = null;
                RegistrarEvento("Error al grabar venta: " + Recortar(ex.Message, 60), 3);
                throw new Exception("No se pudo grabar la venta. No se acreditaron puntos. " + ex.Message, ex);
            }

            _digitoVerificadorBLL.RecalcularDVV_Venta();
            _digitoVerificadorBLL.RecalcularDVV_DetalleVenta();
            if (v.Cliente != null)
            {
                _digitoVerificadorBLL.RecalcularDVV_LotePuntos();
                _digitoVerificadorBLL.RecalcularDVV_Cliente();
            }

            string conCliente = v.Cliente != null ? $" cliente {v.Cliente.Dni}, {v.PuntosAcreditados} pts" : " sin cliente";
            RegistrarEvento($"Registrar venta {v.NroComprobante}{conCliente}", 1);
        }

        private static LotePuntos ArmarLote(Venta v)
        {
            ProgramaPuntos programa = ProgramaPuntosBLL.Obtener();
            return new LotePuntos
            {
                IdCliente = v.Cliente!.IdCliente,
                PuntosOriginales = v.PuntosAcreditados,
                PuntosDisponibles = v.PuntosAcreditados,
                FechaAcreditacion = v.Fecha.Date,
                FechaVencimiento = v.Fecha.Date.AddMonths(programa.MesesVencimiento),
                Origen = OrigenPuntos.venta
            };
        }

        public Venta? ObtenerPorNro(string nro)
        {
            nro = (nro ?? "").Trim().ToUpperInvariant();
            if (nro.Length == 0) return null;
            return _ventaDAL.ObtenerPorNro(nro);
        }

        private void RegistrarEvento(string evento, int criticidad)
        {
            try
            {
                _bitacoraBLL.RegistrarEvento(new Bitacora
                {
                    Login = SessionManager.Instance.UsuarioActual().Username,
                    Modulo = MODULO,
                    Evento = Recortar(evento, 100),
                    Criticidad = criticidad
                });
            }
            catch { }
        }

        internal static string Recortar(string texto, int largo) =>
            texto.Length <= largo ? texto : texto.Substring(0, largo);
    }
}

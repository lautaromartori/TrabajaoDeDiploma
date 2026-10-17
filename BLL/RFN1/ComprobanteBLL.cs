using BE.RFN1;
using Servicios;
using System;
using System.IO;
using System.Linq;

namespace BLL.RFN1
{
    public class ComprobanteBLL
    {
        public const string COMERCIO = "Le Marchant";
        private const string MODULO = "Comprobantes";

        private readonly VentaBLL _ventaBLL = new VentaBLL();
        private readonly LoteBLL _loteBLL = new LoteBLL();
        private readonly BitacoraBLL _bitacoraBLL = new BitacoraBLL();

        public ComprobanteVenta? Buscar(string nro)
        {
            Venta? venta = _ventaBLL.ObtenerPorNro(nro);
            return venta == null ? null : Armar(venta);
        }

        public ComprobanteVenta Armar(Venta v)
        {
            int saldo = 0;
            if (v.Cliente != null)
            {
                try { saldo = _loteBLL.ConsultarSaldo(v.Cliente); } catch { }
            }

            string vendedor = $"{v.Vendedor?.Nombre} {v.Vendedor?.Apellido}".Trim();
            if (vendedor.Length == 0) vendedor = v.Vendedor?.Username ?? v.Vendedor?.DNI ?? "";

            return new ComprobanteVenta
            {
                Comercio = COMERCIO,
                NroComprobante = v.NroComprobante,
                Fecha = v.Fecha,
                Vendedor = vendedor,
                DniCliente = v.Cliente?.Dni ?? "",
                Cliente = v.Cliente?.NombreCompleto ?? "",
                Nivel = v.Cliente?.Nivel?.Nombre ?? "",
                Total = v.Total,
                PuntosAcreditados = v.PuntosAcreditados,
                SaldoVigente = saldo,
                FechaEmision = BitacoraBLL.AhoraSinMilisegundos(),
                Items = v.Detalle.Select(d => new ItemComprobante
                {
                    Producto = d.Producto.Nombre,
                    Categoria = d.Producto.Categoria.Nombre,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal,
                    Puntos = d.PuntosCalculados
                }).ToList()
            };
        }

        public void Exportar(ComprobanteVenta c, string ruta)
        {
            if (c == null) throw new Exception("No hay un comprobante para exportar.");
            Serializador.Serializar(c, ruta);
            RegistrarEvento($"Serializar comprobante {c.NroComprobante} ({Serializador.FormatoDe(ruta)})", 1);
        }

        public ComprobanteVenta Importar(string ruta)
        {
            ComprobanteVenta c = Serializador.Deserializar<ComprobanteVenta>(ruta);
            if (string.IsNullOrWhiteSpace(c.NroComprobante) || c.Items == null)
                throw new Exception("El archivo no contiene un comprobante de venta válido.");
            RegistrarEvento($"Deserializar comprobante {c.NroComprobante} desde {Path.GetFileName(ruta)}", 1);
            return c;
        }

        public void RegistrarImpresion(string nro, string ruta)
        {
            RegistrarEvento($"Generar PDF comprobante {nro} ({Path.GetFileName(ruta)})", 1);
        }

        private void RegistrarEvento(string evento, int criticidad)
        {
            try
            {
                _bitacoraBLL.RegistrarEvento(new Bitacora
                {
                    Login = SessionManager.Instance.UsuarioActual().Username,
                    Modulo = MODULO,
                    Evento = VentaBLL.Recortar(evento, 100),
                    Criticidad = criticidad
                });
            }
            catch { }
        }
    }
}

using LM830BE.LM830RFN1;
using LM830Servicios;
using System;
using System.IO;
using System.Linq;

namespace LM830BLL.LM830RFN1
{
    public class LM830ComprobanteBLL
    {
        public const string LM830COMERCIO = "Le Marchant";
        private const string LM830MODULO = "Comprobantes";

        private readonly LM830VentaBLL LM830_ventaBLL = new LM830VentaBLL();
        private readonly LM830LoteBLL LM830_loteBLL = new LM830LoteBLL();
        private readonly LM830BitacoraBLL LM830_bitacoraBLL = new LM830BitacoraBLL();

        public LM830ComprobanteVenta? LM830Buscar(string LM830nro)
        {
            LM830Venta? LM830venta = LM830_ventaBLL.LM830ObtenerPorNro(LM830nro);
            return LM830venta == null ? null : LM830Armar(LM830venta);
        }

        public LM830ComprobanteVenta LM830Armar(LM830Venta LM830v)
        {
            int LM830saldo = 0;
            if (LM830v.LM830Cliente != null)
            {
                try { LM830saldo = LM830_loteBLL.LM830ConsultarSaldo(LM830v.LM830Cliente); } catch { }
            }

            string LM830vendedor = $"{LM830v.LM830Vendedor?.LM830Nombre} {LM830v.LM830Vendedor?.LM830Apellido}".Trim();
            if (LM830vendedor.Length == 0) LM830vendedor = LM830v.LM830Vendedor?.LM830Username ?? LM830v.LM830Vendedor?.LM830DNI ?? "";

            return new LM830ComprobanteVenta
            {
                LM830Comercio = LM830COMERCIO,
                LM830NroComprobante = LM830v.LM830NroComprobante,
                LM830Fecha = LM830v.LM830Fecha,
                LM830Vendedor = LM830vendedor,
                LM830DniCliente = LM830v.LM830Cliente?.LM830Dni ?? "",
                LM830Cliente = LM830v.LM830Cliente?.LM830NombreCompleto ?? "",
                LM830Nivel = LM830v.LM830Cliente?.LM830Nivel?.LM830Nombre ?? "",
                LM830Total = LM830v.LM830Total,
                LM830PuntosAcreditados = LM830v.LM830PuntosAcreditados,
                LM830SaldoVigente = LM830saldo,
                LM830FechaEmision = LM830BitacoraBLL.LM830AhoraSinMilisegundos(),
                LM830Items = LM830v.LM830Detalle.Select(LM830d => new LM830ItemComprobante
                {
                    LM830Producto = LM830d.LM830Producto.LM830Nombre,
                    LM830Categoria = LM830d.LM830Producto.LM830Categoria.LM830Nombre,
                    LM830Cantidad = LM830d.LM830Cantidad,
                    LM830PrecioUnitario = LM830d.LM830PrecioUnitario,
                    LM830Subtotal = LM830d.LM830Subtotal,
                    LM830Puntos = LM830d.LM830PuntosCalculados
                }).ToList()
            };
        }

        public void LM830Exportar(LM830ComprobanteVenta LM830c, string LM830ruta)
        {
            if (LM830c == null) throw new Exception("No hay un comprobante para exportar.");
            LM830Serializador.LM830Serializar(LM830c, LM830ruta);
            LM830RegistrarEvento($"Serializar comprobante {LM830c.LM830NroComprobante} ({LM830Serializador.LM830FormatoDe(LM830ruta).LM830ATexto()})", 1);
        }

        public LM830ComprobanteVenta LM830Importar(string LM830ruta)
        {
            LM830ComprobanteVenta LM830c = LM830Serializador.LM830Deserializar<LM830ComprobanteVenta>(LM830ruta);
            if (string.IsNullOrWhiteSpace(LM830c.LM830NroComprobante) || LM830c.LM830Items == null)
                throw new Exception("El archivo no contiene un comprobante de venta válido.");
            LM830RegistrarEvento($"Deserializar comprobante {LM830c.LM830NroComprobante} desde {Path.GetFileName(LM830ruta)}", 1);
            return LM830c;
        }

        public void LM830RegistrarImpresion(string LM830nro, string LM830ruta)
        {
            LM830RegistrarEvento($"Generar PDF comprobante {LM830nro} ({Path.GetFileName(LM830ruta)})", 1);
        }

        private void LM830RegistrarEvento(string LM830evento, int LM830criticidad)
        {
            try
            {
                LM830_bitacoraBLL.LM830RegistrarEvento(new LM830Bitacora
                {
                    LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username,
                    LM830Modulo = LM830MODULO,
                    LM830Evento = LM830VentaBLL.LM830Recortar(LM830evento, 100),
                    LM830Criticidad = LM830criticidad
                });
            }
            catch { }
        }
    }
}

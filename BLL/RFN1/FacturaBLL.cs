using BE;
using BE.RFN1;
using DAL;
using DAL.RFN1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.RFN1
{
    public class FacturaBLL
    {
        private readonly FacturaDAL _facturaDAL;

        public FacturaBLL()
        {
            _facturaDAL = new FacturaDAL();
        }

        public bool RegistrarFactura(Factura factura)
        {
            // Validaciones de Cabecera
            if (factura == null)
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");

            if (factura.Proveedor == null || factura.Proveedor.Id <= 0)
                throw new Exception("Debe seleccionar un proveedor válido.");

            if (string.IsNullOrWhiteSpace(factura.NumeroFactura))
                throw new Exception("El número de factura es obligatorio.");

            if (string.IsNullOrWhiteSpace(factura.TipoComprobante))
                throw new Exception("El tipo de comprobante es obligatorio.");

            if (factura.Detalles == null || !factura.Detalles.Any())
                throw new Exception("La factura debe contener al menos un ítem en el detalle.");

            // Recálculo y Validación de Líneas de Detalle
            decimal totalFactura = 0;
            decimal totalImpuestosFactura = 0;

            foreach (var detalle in factura.Detalles)
            {
                if (detalle.Producto == null || detalle.Producto.Id <= 0)
                    throw new Exception("Cada línea de detalle debe asociarse a un producto válido.");

                if (detalle.Cantidad <= 0)
                    throw new Exception($"La cantidad para el producto '{detalle.Producto.Nombre}' debe ser mayor a cero.");

                if (detalle.PrecioUnitario < 0)
                    throw new Exception($"El precio unitario para el producto '{detalle.Producto.Nombre}' no es válido.");

                // Cálculo automático del ítem
                decimal baseImponible = detalle.Cantidad * detalle.PrecioUnitario;
                detalle.Impuestos = baseImponible * (detalle.Producto.ImpuestoPorcentaje / 100m);
                detalle.Subtotal = baseImponible + detalle.Impuestos;

                totalImpuestosFactura += detalle.Impuestos;
                totalFactura += detalle.Subtotal;
            }

            // Asignación de totales consolidados a la cabecera
            factura.Impuestos = totalImpuestosFactura;
            factura.Total = totalFactura;

            // Persistencia en la base de datos
            return _facturaDAL.RegistrarFacturaConDetalles(factura);
        }
    }
}
using BE;
using BE.RFN1;
using DAL;
using DAL.RFN1;
using System;
using System.Collections.Generic;

namespace BLL.RFN1
{
    public class ProductoBLL
    {
        private readonly ProductoDAL _productoDAL;

        public ProductoBLL()
        {
            _productoDAL = new ProductoDAL();
        }

        public List<Producto> Listar()
        {
            return _productoDAL.Listar();
        }

        public int Guardar(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto es obligatorio.");

            if (producto.PrecioCosto < 0)
                throw new Exception("El precio de costo no puede ser negativo.");

            if (producto.ImpuestoPorcentaje < 0)
                throw new Exception("El porcentaje de impuesto no puede ser negativo.");

            return _productoDAL.Guardar(producto);
        }
    }
}
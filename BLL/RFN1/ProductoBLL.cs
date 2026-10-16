using BE.RFN1;
using DAL.RFN1;
using System.Collections.Generic;

namespace BLL.RFN1
{
    public class ProductoBLL
    {
        private readonly ProductoDAL _productoDAL = new ProductoDAL();

        // null = el producto no existe.
        public Producto? Buscar(string nombre)
        {
            nombre = (nombre ?? "").Trim();
            if (nombre.Length == 0) return null;
            return _productoDAL.Buscar(nombre);
        }

        public List<Producto> Listar() => _productoDAL.Listar();
    }
}

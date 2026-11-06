using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;
using System;
using System.Collections.Generic;

namespace LM830BLL.LM830RFN1
{
    public class LM830ProductoBLL
    {
        private readonly LM830ProductoDAL LM830_productoDAL = new LM830ProductoDAL();

        public LM830Producto? LM830Buscar(string LM830nombre)
        {
            LM830nombre = (LM830nombre ?? "").Trim();
            if (LM830nombre.Length == 0) return null;
            return LM830_productoDAL.LM830Buscar(LM830nombre);
        }

        public List<LM830Producto> LM830Listar() => LM830_productoDAL.LM830Listar();

        public List<LM830Categoria> LM830ListarCategorias() => LM830_productoDAL.LM830ListarCategorias();

        public void LM830Agregar(LM830Producto LM830p)
        {
            LM830Validar(LM830p);
            LM830_productoDAL.LM830Insertar(LM830p);
        }

        public void LM830Modificar(LM830Producto LM830p)
        {
            LM830Validar(LM830p);
            LM830_productoDAL.LM830Modificar(LM830p);
        }

        public void LM830Eliminar(LM830Producto LM830p) => LM830_productoDAL.LM830Eliminar(LM830p.LM830IdProducto);

        private static void LM830Validar(LM830Producto LM830p)
        {
            LM830p.LM830Nombre = (LM830p.LM830Nombre ?? "").Trim();
            if (LM830p.LM830Nombre.Length == 0)
                throw new Exception("Complete el nombre del producto.");
            if (LM830p.LM830Nombre.Length > 100)
                throw new Exception("El nombre no puede superar los 100 caracteres.");
            if (LM830p.LM830Precio <= 0)
                throw new Exception("El precio tiene que ser mayor a cero.");
            if (LM830p.LM830Categoria.LM830IdCategoria <= 0)
                throw new Exception("Elija una categoría.");
        }
    }
}

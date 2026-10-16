using BE.RFN1;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.RFN1
{
    public class ProductoDAL : AbstractDAL<Producto>
    {
        private const string SELECT_PRODUCTO = @"SELECT p.idProducto, p.nombre, p.precio,
                                                        c.idCategoria, c.nombre, c.multiplicador
                                                 FROM Producto p
                                                 INNER JOIN Categoria c ON c.idCategoria = p.idCategoria";

        // Busca por nombre exacto; si no hay, devuelve el primero que lo contenga. null = no existe.
        public Producto? Buscar(string nombre)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_PRODUCTO + @"
                    WHERE p.nombre LIKE @patron
                    ORDER BY CASE WHEN p.nombre = @nombre THEN 0 ELSE 1 END, p.nombre";
                _sqlcommand.Parameters.AddWithValue("@nombre", nombre);
                _sqlcommand.Parameters.AddWithValue("@patron", "%" + nombre + "%");
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    if (r.Read()) return Mapear(r);
                }
                return null;
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
        }

        // Se usa solo para el autocompletado del buscador de frmVenta.
        public List<Producto> Listar()
        {
            var lista = new List<Producto>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_PRODUCTO + " ORDER BY p.nombre";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Mapear(r));
                }
            }
            finally
            {
                _sqlserver.Close();
            }
            return lista;
        }

        private static Producto Mapear(SqlDataReader r) => new Producto
        {
            IdProducto = r.GetInt32(0),
            Nombre = r.GetString(1),
            Precio = r.GetDecimal(2),
            Categoria = new Categoria
            {
                IdCategoria = r.GetInt32(3),
                Nombre = r.GetString(4),
                Multiplicador = r.GetDecimal(5)
            }
        };
    }
}

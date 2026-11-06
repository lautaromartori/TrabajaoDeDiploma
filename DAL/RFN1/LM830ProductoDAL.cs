using LM830BE.LM830RFN1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN1
{
    public class LM830ProductoDAL : LM830AbstractDAL<LM830Producto>
    {
        private const string LM830SELECT_PRODUCTO = @"SELECT p.idProducto, p.nombre, p.precio,
                                                        c.idCategoria, c.nombre, c.multiplicador
                                                 FROM Producto p
                                                 INNER JOIN Categoria c ON c.idCategoria = p.idCategoria";

        public LM830Producto? LM830Buscar(string LM830nombre)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_PRODUCTO + @"
                    WHERE p.nombre LIKE @patron
                    ORDER BY CASE WHEN p.nombre = @nombre THEN 0 ELSE 1 END, p.nombre";
                LM830_sqlcommand.Parameters.AddWithValue("@nombre", LM830nombre);
                LM830_sqlcommand.Parameters.AddWithValue("@patron", "%" + LM830nombre + "%");
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830r.Read()) return LM830Mapear(LM830r);
                }
                return null;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Producto> LM830Listar()
        {
            var LM830lista = new List<LM830Producto>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_PRODUCTO + " ORDER BY p.nombre";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read()) LM830lista.Add(LM830Mapear(LM830r));
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public List<LM830Categoria> LM830ListarCategorias()
        {
            var LM830lista = new List<LM830Categoria>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = "SELECT idCategoria, nombre, multiplicador FROM Categoria ORDER BY nombre";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read())
                        LM830lista.Add(new LM830Categoria
                        {
                            LM830IdCategoria = LM830r.GetInt32(0),
                            LM830Nombre = LM830r.GetString(1),
                            LM830Multiplicador = LM830r.GetDecimal(2)
                        });
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public void LM830Insertar(LM830Producto LM830p) =>
            LM830Grabar("INSERT INTO Producto (nombre, precio, idCategoria) VALUES (@nombre, @precio, @idCategoria)", LM830p);

        public void LM830Modificar(LM830Producto LM830p) =>
            LM830Grabar("UPDATE Producto SET nombre = @nombre, precio = @precio, idCategoria = @idCategoria WHERE idProducto = @id", LM830p);

        public void LM830Eliminar(int LM830idProducto)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = "DELETE FROM Producto WHERE idProducto = @id";
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830idProducto);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException LM830ex) when (LM830ex.Number == 547)
            {
                throw new Exception("No se puede eliminar el producto porque ya se usó en ventas.");
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        private void LM830Grabar(string LM830sql, LM830Producto LM830p)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830sql;
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830p.LM830IdProducto);
                LM830_sqlcommand.Parameters.AddWithValue("@nombre", LM830p.LM830Nombre);
                LM830_sqlcommand.Parameters.AddWithValue("@precio", LM830p.LM830Precio);
                LM830_sqlcommand.Parameters.AddWithValue("@idCategoria", LM830p.LM830Categoria.LM830IdCategoria);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException LM830ex) when (LM830ex.Number == 2627 || LM830ex.Number == 2601)
            {
                throw new Exception("Ya existe un producto con ese nombre.");
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        private static LM830Producto LM830Mapear(SqlDataReader LM830r) => new LM830Producto
        {
            LM830IdProducto = LM830r.GetInt32(0),
            LM830Nombre = LM830r.GetString(1),
            LM830Precio = LM830r.GetDecimal(2),
            LM830Categoria = new LM830Categoria
            {
                LM830IdCategoria = LM830r.GetInt32(3),
                LM830Nombre = LM830r.GetString(4),
                LM830Multiplicador = LM830r.GetDecimal(5)
            }
        };
    }
}

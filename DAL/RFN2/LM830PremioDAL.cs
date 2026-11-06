using LM830BE.LM830RFN2;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN2
{
    public class LM830PremioDAL : LM830AbstractDAL<LM830Premio>
    {
        private const string LM830SELECT_PREMIO = @"SELECT idPremio, nombre, descripcion, puntosRequeridos, stock, valorReferencia
                                               FROM Premio";

        public List<LM830Premio> LM830Listar()
        {
            var LM830lista = new List<LM830Premio>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_PREMIO + " ORDER BY puntosRequeridos, nombre";
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

        public List<LM830Premio> LM830ListarCanjeables(int LM830saldo)
        {
            var LM830lista = new List<LM830Premio>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_PREMIO + @"
                    WHERE stock > 0 AND puntosRequeridos <= @saldo
                    ORDER BY puntosRequeridos, nombre";
                LM830_sqlcommand.Parameters.AddWithValue("@saldo", LM830saldo);
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read()) LM830lista.Add(LM830Mapear(LM830r));
                }
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public LM830Premio? LM830Obtener(int LM830idPremio)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_PREMIO + " WHERE idPremio = @id";
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830idPremio);
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

        public void LM830Insertar(LM830Premio LM830p) =>
            LM830Grabar(@"INSERT INTO Premio (nombre, descripcion, puntosRequeridos, stock, valorReferencia)
                          VALUES (@nombre, @descripcion, @puntos, @stock, @valor)", LM830p);

        public void LM830Modificar(LM830Premio LM830p) =>
            LM830Grabar(@"UPDATE Premio SET nombre = @nombre, descripcion = @descripcion, puntosRequeridos = @puntos,
                                 stock = @stock, valorReferencia = @valor
                          WHERE idPremio = @id", LM830p);

        public void LM830Eliminar(int LM830idPremio)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                using (var LM830cmd = new SqlCommand("DELETE FROM Premio WHERE idPremio = @id", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@id", LM830idPremio);
                    LM830cmd.ExecuteNonQuery();
                }
                LM830tx.Commit();
            }
            catch (SqlException LM830ex) when (LM830ex.Number == 547)
            {
                LM830tx.Rollback();
                throw new Exception("No se puede eliminar el premio porque ya tiene canjes.");
            }
            catch
            {
                LM830tx.Rollback();
                throw;
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        private void LM830Grabar(string LM830sql, LM830Premio LM830p)
        {
            try
            {
                LM830_sqlserver.Open();
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830sql;
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830p.LM830IdPremio);
                LM830_sqlcommand.Parameters.AddWithValue("@nombre", LM830p.LM830Nombre);
                LM830_sqlcommand.Parameters.AddWithValue("@descripcion", LM830p.LM830Descripcion);
                LM830_sqlcommand.Parameters.AddWithValue("@puntos", LM830p.LM830PuntosRequeridos);
                LM830_sqlcommand.Parameters.AddWithValue("@stock", LM830p.LM830Stock);
                LM830_sqlcommand.Parameters.AddWithValue("@valor", LM830p.LM830ValorReferencia);
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException LM830ex) when (LM830ex.Number == 2627 || LM830ex.Number == 2601)
            {
                throw new Exception("Ya existe un premio con ese nombre.");
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        internal static void LM830DescontarStock(LM830Premio LM830p, SqlConnection LM830cn, SqlTransaction LM830tx)
        {
            using (var LM830cmd = new SqlCommand("UPDATE Premio SET stock = stock - 1 WHERE idPremio = @id AND stock > 0", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@id", LM830p.LM830IdPremio);
                if (LM830cmd.ExecuteNonQuery() == 0)
                    throw new System.Exception("No hay stock del premio " + LM830p.LM830Nombre + ".");
            }
            LM830p.LM830Stock--;
        }

        internal static void LM830ReintegrarStock(LM830Premio LM830p, SqlConnection LM830cn, SqlTransaction LM830tx)
        {
            using (var LM830cmd = new SqlCommand("UPDATE Premio SET stock = stock + 1 WHERE idPremio = @id", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@id", LM830p.LM830IdPremio);
                LM830cmd.ExecuteNonQuery();
            }
            LM830p.LM830Stock++;
        }

        private static LM830Premio LM830Mapear(SqlDataReader LM830r) => new LM830Premio
        {
            LM830IdPremio = LM830r.GetInt32(0),
            LM830Nombre = LM830r.GetString(1),
            LM830Descripcion = LM830r.GetString(2),
            LM830PuntosRequeridos = LM830r.GetInt32(3),
            LM830Stock = LM830r.GetInt32(4),
            LM830ValorReferencia = LM830r.GetDecimal(5)
        };
    }
}

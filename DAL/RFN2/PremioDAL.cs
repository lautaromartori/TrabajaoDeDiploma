using BE.RFN2;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.RFN2
{
    public class PremioDAL : AbstractDAL<Premio>
    {
        private const string SELECT_PREMIO = @"SELECT idPremio, nombre, descripcion, puntosRequeridos, stock, valorReferencia
                                               FROM Premio";

        public List<Premio> Listar()
        {
            var lista = new List<Premio>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_PREMIO + " ORDER BY puntosRequeridos, nombre";
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

        public List<Premio> ListarCanjeables(int saldo)
        {
            var lista = new List<Premio>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_PREMIO + @"
                    WHERE stock > 0 AND puntosRequeridos <= @saldo
                    ORDER BY puntosRequeridos, nombre";
                _sqlcommand.Parameters.AddWithValue("@saldo", saldo);
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Mapear(r));
                }
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
            return lista;
        }

        public Premio? Obtener(int idPremio)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_PREMIO + " WHERE idPremio = @id";
                _sqlcommand.Parameters.AddWithValue("@id", idPremio);
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

        internal static void DescontarStock(Premio p, SqlConnection cn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand("UPDATE Premio SET stock = stock - 1 WHERE idPremio = @id AND stock > 0", cn, tx))
            {
                cmd.Parameters.AddWithValue("@id", p.IdPremio);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new System.Exception("No hay stock del premio " + p.Nombre + ".");
            }
            p.Stock--;
        }

        internal static void ReintegrarStock(Premio p, SqlConnection cn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand("UPDATE Premio SET stock = stock + 1 WHERE idPremio = @id", cn, tx))
            {
                cmd.Parameters.AddWithValue("@id", p.IdPremio);
                cmd.ExecuteNonQuery();
            }
            p.Stock++;
        }

        private static Premio Mapear(SqlDataReader r) => new Premio
        {
            IdPremio = r.GetInt32(0),
            Nombre = r.GetString(1),
            Descripcion = r.GetString(2),
            PuntosRequeridos = r.GetInt32(3),
            Stock = r.GetInt32(4),
            ValorReferencia = r.GetDecimal(5)
        };
    }
}

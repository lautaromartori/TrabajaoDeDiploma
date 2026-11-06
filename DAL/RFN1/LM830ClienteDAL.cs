using LM830BE.LM830RFN1;
using LM830DAL.LM830BitacoraCambios;
using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN1
{
    public class LM830ClienteDAL : LM830AbstractDAL<LM830Cliente>
    {
        private const string LM830SELECT_CLIENTE = @"SELECT c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono,
                                                       c.fechaInscripcion, c.DVH,
                                                       n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador
                                                FROM Cliente c
                                                INNER JOIN Nivel n ON n.idNivel = c.idNivel";

        public bool LM830ExisteDni(string LM830dni)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = "SELECT COUNT(1) FROM Cliente WHERE dni = @dni";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dni);
                LM830_sqlserver.Open();
                return Convert.ToInt32(LM830_sqlcommand.ExecuteScalar()) > 0;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830Insertar(LM830Cliente LM830c)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                LM830ContextoSesion.LM830AplicarUsuario(LM830_sqlserver, LM830tx);
                using (var LM830cmd = new SqlCommand(@"INSERT INTO Cliente (dni, nombre, apellido, email, telefono, fechaInscripcion, idNivel, DVH)
                                                  VALUES (@dni, @nombre, @apellido, @email, @telefono, @fecha, @idNivel, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@dni", LM830c.LM830Dni);
                    LM830cmd.Parameters.AddWithValue("@nombre", LM830c.LM830Nombre);
                    LM830cmd.Parameters.AddWithValue("@apellido", LM830c.LM830Apellido);
                    LM830cmd.Parameters.AddWithValue("@email", LM830c.LM830Email);
                    LM830cmd.Parameters.AddWithValue("@telefono", LM830c.LM830Telefono);
                    LM830cmd.Parameters.AddWithValue("@fecha", LM830c.LM830FechaInscripcion.Date);
                    LM830cmd.Parameters.AddWithValue("@idNivel", LM830c.LM830Nivel.LM830IdNivel);
                    LM830c.LM830IdCliente = (int)LM830cmd.ExecuteScalar();
                }

                LM830c.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830c.LM830CadenaDVH());
                LM830ActualizarDVH(LM830c.LM830IdCliente, LM830c.LM830DVH, LM830tx);

                LM830tx.Commit();
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

        public LM830Cliente? LM830Obtener(string LM830dni)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_CLIENTE + " WHERE c.dni = @dni";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dni);
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

        public List<LM830Cliente> LM830ListarParaDV()
        {
            var LM830lista = new List<LM830Cliente>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_CLIENTE + " ORDER BY c.idCliente";
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

        public void LM830ActualizarDVH(int LM830idCliente, string LM830dvh)
        {
            try
            {
                LM830_sqlserver.Open();
                LM830ActualizarDVH(LM830idCliente, LM830dvh, null);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        internal static void LM830ActualizarNivel(LM830Cliente LM830c, SqlConnection LM830cn, SqlTransaction LM830tx)
        {
            LM830ContextoSesion.LM830AplicarUsuario(LM830cn, LM830tx);
            using (var LM830cmd = new SqlCommand("UPDATE Cliente SET idNivel = @idNivel, DVH = @dvh WHERE idCliente = @id", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@idNivel", LM830c.LM830Nivel.LM830IdNivel);
                LM830cmd.Parameters.AddWithValue("@dvh", LM830c.LM830DVH);
                LM830cmd.Parameters.AddWithValue("@id", LM830c.LM830IdCliente);
                LM830cmd.ExecuteNonQuery();
            }
        }

        private void LM830ActualizarDVH(int LM830idCliente, string LM830dvh, SqlTransaction? LM830tx)
        {
            using (var LM830cmd = new SqlCommand("UPDATE Cliente SET DVH = @dvh WHERE idCliente = @id", LM830_sqlserver, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@dvh", LM830dvh);
                LM830cmd.Parameters.AddWithValue("@id", LM830idCliente);
                LM830cmd.ExecuteNonQuery();
            }
        }

        internal static LM830Cliente LM830Mapear(SqlDataReader LM830r) => new LM830Cliente
        {
            LM830IdCliente = LM830r.GetInt32(0),
            LM830Dni = LM830r.GetString(1),
            LM830Nombre = LM830r.GetString(2),
            LM830Apellido = LM830r.GetString(3),
            LM830Email = LM830r.GetString(4),
            LM830Telefono = LM830r.GetString(5),
            LM830FechaInscripcion = LM830r.GetDateTime(6),
            LM830DVH = LM830r.GetString(7),
            LM830Nivel = new LM830Nivel
            {
                LM830IdNivel = LM830r.GetInt32(8),
                LM830Nombre = LM830r.GetString(9),
                LM830PuntosMinimos = LM830r.GetInt32(10),
                LM830Multiplicador = LM830r.GetDecimal(11)
            }
        };
    }
}

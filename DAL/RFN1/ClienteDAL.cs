using BE.RFN1;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;

namespace DAL.RFN1
{
    public class ClienteDAL : AbstractDAL<Cliente>
    {
        private const string SELECT_CLIENTE = @"SELECT c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono,
                                                       c.fechaInscripcion, c.DVH,
                                                       n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador
                                                FROM Cliente c
                                                INNER JOIN Nivel n ON n.idNivel = c.idNivel";

        public bool ExisteDni(string dni)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = "SELECT COUNT(1) FROM Cliente WHERE dni = @dni";
                _sqlcommand.Parameters.AddWithValue("@dni", dni);
                _sqlserver.Open();
                return Convert.ToInt32(_sqlcommand.ExecuteScalar()) > 0;
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
        }

        public void Insertar(Cliente c)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                using (var cmd = new SqlCommand(@"INSERT INTO Cliente (dni, nombre, apellido, email, telefono, fechaInscripcion, idNivel, DVH)
                                                  VALUES (@dni, @nombre, @apellido, @email, @telefono, @fecha, @idNivel, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@dni", c.Dni);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@fecha", c.FechaInscripcion.Date);
                    cmd.Parameters.AddWithValue("@idNivel", c.Nivel.IdNivel);
                    c.IdCliente = (int)cmd.ExecuteScalar();
                }

                c.DVH = DigitoVerificador.CalcularDVH(c.CadenaDVH());
                ActualizarDVH(c.IdCliente, c.DVH, tx);

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        public Cliente? Obtener(string dni)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_CLIENTE + " WHERE c.dni = @dni";
                _sqlcommand.Parameters.AddWithValue("@dni", dni);
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

        public List<Cliente> ListarParaDV()
        {
            var lista = new List<Cliente>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_CLIENTE + " ORDER BY c.idCliente";
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

        public void ActualizarDVH(int idCliente, string dvh)
        {
            try
            {
                _sqlserver.Open();
                ActualizarDVH(idCliente, dvh, null);
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        internal static void ActualizarNivel(Cliente c, SqlConnection cn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand("UPDATE Cliente SET idNivel = @idNivel, DVH = @dvh WHERE idCliente = @id", cn, tx))
            {
                cmd.Parameters.AddWithValue("@idNivel", c.Nivel.IdNivel);
                cmd.Parameters.AddWithValue("@dvh", c.DVH);
                cmd.Parameters.AddWithValue("@id", c.IdCliente);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarDVH(int idCliente, string dvh, SqlTransaction? tx)
        {
            using (var cmd = new SqlCommand("UPDATE Cliente SET DVH = @dvh WHERE idCliente = @id", _sqlserver, tx))
            {
                cmd.Parameters.AddWithValue("@dvh", dvh);
                cmd.Parameters.AddWithValue("@id", idCliente);
                cmd.ExecuteNonQuery();
            }
        }

        internal static Cliente Mapear(SqlDataReader r) => new Cliente
        {
            IdCliente = r.GetInt32(0),
            Dni = r.GetString(1),
            Nombre = r.GetString(2),
            Apellido = r.GetString(3),
            Email = r.GetString(4),
            Telefono = r.GetString(5),
            FechaInscripcion = r.GetDateTime(6),
            DVH = r.GetString(7),
            Nivel = new Nivel
            {
                IdNivel = r.GetInt32(8),
                Nombre = r.GetString(9),
                PuntosMinimos = r.GetInt32(10),
                Multiplicador = r.GetDecimal(11)
            }
        };
    }
}

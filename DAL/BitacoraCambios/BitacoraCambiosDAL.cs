using LM830BE.LM830BitacoraCambios;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830BitacoraCambios
{
    // Lee las versiones que guardaron los triggers y restaura una versión anterior.
    public class LM830BitacoraCambiosDAL : LM830AbstractDAL<LM830BitacoraCambioCliente>
    {
        public List<LM830BitacoraCambioCliente> LM830ListarClientes(string? LM830dni, DateTime LM830desde, DateTime LM830hasta)
        {
            var LM830lista = new List<LM830BitacoraCambioCliente>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idCambio, idCliente, dni, nombre, apellido, email, telefono, fechaInscripcion, idNivel,
                                                        fechaCambio, operacion, usuario, activo
                                                 FROM BitacoraCambiosCliente
                                                 WHERE (@dni IS NULL OR dni = @dni)
                                                   AND fechaCambio >= @desde AND fechaCambio < @hasta
                                                 ORDER BY dni, fechaCambio DESC, idCambio DESC";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(LM830dni) ? (object)DBNull.Value : LM830dni!.Trim());
                LM830_sqlcommand.Parameters.AddWithValue("@desde", LM830desde.Date);
                LM830_sqlcommand.Parameters.AddWithValue("@hasta", LM830hasta.Date.AddDays(1));
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830BitacoraCambioCliente
                        {
                            LM830IdCambio = LM830r.GetInt32(0),
                            LM830IdCliente = LM830r.GetInt32(1),
                            LM830Dni = LM830r.GetString(2),
                            LM830Nombre = LM830r.GetString(3),
                            LM830Apellido = LM830r.GetString(4),
                            LM830Email = LM830r.GetString(5),
                            LM830Telefono = LM830r.GetString(6),
                            LM830FechaInscripcion = LM830r.GetDateTime(7),
                            LM830IdNivel = LM830r.GetInt32(8),
                            LM830FechaCambio = LM830r.GetDateTime(9),
                            LM830Operacion = LM830r.GetString(10),
                            LM830Usuario = LM830r.GetString(11),
                            LM830Activo = LM830r.GetBoolean(12)
                        });
                    }
                }
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        // Vuelve el cliente a la versión elegida: actualiza Cliente con esos datos (y su DVH),
        // desactiva la versión vigente y marca como activa la restaurada. Todo en una transacción.
        public void LM830RestaurarCliente(LM830BitacoraCambioCliente LM830version, string LM830dvh)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830transaccion = LM830_sqlserver.BeginTransaction();
            try
            {
                LM830ContextoSesion.LM830Restaurando(LM830_sqlserver, LM830transaccion, true);
                using (var LM830cmd = new SqlCommand(@"UPDATE Cliente SET dni = @dni, nombre = @nombre, apellido = @apellido, email = @email,
                                                         telefono = @telefono, fechaInscripcion = @fecha, idNivel = @idNivel, DVH = @dvh
                                                  WHERE idCliente = @id", LM830_sqlserver, LM830transaccion))
                {
                    LM830cmd.Parameters.AddWithValue("@dni", LM830version.LM830Dni);
                    LM830cmd.Parameters.AddWithValue("@nombre", LM830version.LM830Nombre);
                    LM830cmd.Parameters.AddWithValue("@apellido", LM830version.LM830Apellido);
                    LM830cmd.Parameters.AddWithValue("@email", LM830version.LM830Email);
                    LM830cmd.Parameters.AddWithValue("@telefono", LM830version.LM830Telefono);
                    LM830cmd.Parameters.AddWithValue("@fecha", LM830version.LM830FechaInscripcion.Date);
                    LM830cmd.Parameters.AddWithValue("@idNivel", LM830version.LM830IdNivel);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830dvh);
                    LM830cmd.Parameters.AddWithValue("@id", LM830version.LM830IdCliente);
                    if (LM830cmd.ExecuteNonQuery() == 0) throw new Exception("El cliente ya no existe.");
                }
                LM830MarcarActiva("BitacoraCambiosCliente", "idCliente", LM830version.LM830IdCliente, LM830version.LM830IdCambio, LM830transaccion);
                LM830ContextoSesion.LM830Restaurando(LM830_sqlserver, LM830transaccion, false);
                LM830transaccion.Commit();
            }
            catch
            {
                LM830transaccion.Rollback();
                throw;
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        private void LM830MarcarActiva(string LM830tabla, string LM830columnaId, int LM830id, int LM830idCambio, SqlTransaction LM830transaccion)
        {
            using (var LM830cmd = new SqlCommand($@"UPDATE {LM830tabla} SET activo = 0 WHERE {LM830columnaId} = @id AND activo = 1;
                                                    UPDATE {LM830tabla} SET activo = 1 WHERE idCambio = @idCambio;", LM830_sqlserver, LM830transaccion))
            {
                LM830cmd.Parameters.AddWithValue("@id", LM830id);
                LM830cmd.Parameters.AddWithValue("@idCambio", LM830idCambio);
                LM830cmd.ExecuteNonQuery();
            }
        }
    }
}

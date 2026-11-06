using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830DAL
{
    public class LM830BitacoraDAL : LM830AbstractDAL<LM830Bitacora>
    {
        public LM830BitacoraDAL() { }

        public void LM830RegistrarEvento(LM830Bitacora LM830unEvento, string LM830DVH)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"INSERT INTO Bitacora (Login, Fecha, Modulo, Evento, Criticidad, DVH)
                           VALUES (@Login, @Fecha, @Modulo, @Evento, @Criticidad, @dvh)";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@Login", LM830unEvento.LM830Login);
                LM830_sqlcommand.Parameters.AddWithValue("@Fecha", LM830unEvento.LM830Fecha);
                LM830_sqlcommand.Parameters.AddWithValue("@Modulo", LM830unEvento.LM830Modulo);
                LM830_sqlcommand.Parameters.AddWithValue("@Evento", LM830unEvento.LM830Evento);
                LM830_sqlcommand.Parameters.AddWithValue("@Criticidad", LM830unEvento.LM830Criticidad);
                LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830DVH);

                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitText1"), LM830ex);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Bitacora> LM830FiltrarEventos(string LM830nombre, string LM830apellido, string LM830login, string LM830modulo, string LM830evento, DateTime LM830desde, DateTime LM830hasta, int? LM830criticidad)
        {
            List<LM830Bitacora> LM830lista = new List<LM830Bitacora>();
            try
            {
                string LM830query = @"SELECT b.Id_Evento, b.Login, b.Fecha, b.Modulo,
                                 b.Evento, b.Criticidad
                                 FROM Bitacora b
                                 LEFT JOIN Usuario u ON b.Login = u.UserName
                                 WHERE 1=1";

                LM830_sqlcommand.Parameters.Clear();

                if (!string.IsNullOrEmpty(LM830nombre))
                {
                    LM830query += " AND u.Nombre LIKE @Nombre";
                    LM830_sqlcommand.Parameters.AddWithValue("@Nombre", "%" + LM830nombre + "%");
                }
                if (!string.IsNullOrEmpty(LM830apellido))
                {
                    LM830query += " AND u.Apellido LIKE @Apellido";
                    LM830_sqlcommand.Parameters.AddWithValue("@Apellido", "%" + LM830apellido + "%");
                }
                if (!string.IsNullOrEmpty(LM830login))
                {
                    LM830query += " AND b.Login = @Login";
                    LM830_sqlcommand.Parameters.AddWithValue("@Login", LM830login);
                }
                if (!string.IsNullOrEmpty(LM830modulo))
                {
                    LM830query += " AND b.Modulo = @Modulo";
                    LM830_sqlcommand.Parameters.AddWithValue("@Modulo", LM830modulo);
                }
                if (!string.IsNullOrEmpty(LM830evento))
                {
                    LM830query += " AND b.Evento LIKE @Evento";
                    LM830_sqlcommand.Parameters.AddWithValue("@Evento", "%" + LM830evento + "%");
                }
                if (LM830criticidad.HasValue)
                {
                    LM830query += " AND b.Criticidad = @Criticidad";
                    LM830_sqlcommand.Parameters.AddWithValue("@Criticidad", LM830criticidad.Value);
                }

                LM830query += " AND b.Fecha BETWEEN @Desde AND @Hasta";
                LM830_sqlcommand.Parameters.AddWithValue("@Desde", LM830desde.Date);
                LM830_sqlcommand.Parameters.AddWithValue("@Hasta", LM830hasta.Date.AddDays(1).AddTicks(-1));

                LM830query += " ORDER BY b.Fecha DESC, b.Id_Evento DESC";

                LM830_sqlcommand.CommandText = LM830query;
                LM830_sqlserver.Open();

                using (SqlDataReader LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830reader.Read())
                    {
                        LM830lista.Add(new LM830Bitacora
                        {
                            LM830Id_Evento = LM830reader.GetInt32(0),
                            LM830Login = LM830reader.GetString(1),
                            LM830Fecha = LM830reader.GetDateTime(2),
                            LM830Modulo = LM830reader.GetString(3),
                            LM830Evento = LM830reader.GetString(4),
                            LM830Criticidad = LM830reader.GetInt32(5)
                        });
                    }
                }
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitText2"), LM830ex);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public List<string> LM830ObtenerLogins()
        {
            List<string> LM830logins = new List<string>();
            try
            {
                LM830_sqlcommand.CommandText = "SELECT DISTINCT UserName FROM Usuario ORDER BY UserName";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Open();

                using (SqlDataReader LM830reader = LM830_sqlcommand.ExecuteReader())
                    while (LM830reader.Read())
                        LM830logins.Add(LM830reader.GetString(0));
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitText3"), LM830ex);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830logins;
        }

        public LM830Usuario LM830ObtenerUsuarioPorLogin(string LM830login)
        {
            LM830Usuario LM830usuario = null;
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT DNI, Nombre, Apellido, UserName
                                            FROM Usuario
                                            WHERE UserName = @Login";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@Login", LM830login);
                LM830_sqlserver.Open();

                using (SqlDataReader LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830reader.Read())
                    {
                        LM830usuario = new LM830Usuario
                        {
                            LM830DNI = LM830reader.GetString(0),
                            LM830Nombre = LM830reader.GetString(1),
                            LM830Apellido = LM830reader.GetString(2),
                            LM830Username = LM830reader.GetString(3)
                        };
                    }
                }
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitText4"), LM830ex);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830usuario;
        }

        public List<LM830Bitacora> LM830listarTodosLosEventos()
        {
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT Id_Evento, Login, Fecha, Modulo, Evento, Criticidad, DVH FROM Bitacora";
                LM830_sqlserver.Open();
                var LM830reader = LM830_sqlcommand.ExecuteReader();
                var LM830Bitacoralst = new List<LM830Bitacora>();
                while (LM830reader.Read())
                {
                    LM830Bitacoralst.Add(new LM830Bitacora(LM830reader.GetInt32(0), LM830reader.GetString(1), LM830reader.GetDateTime(2), LM830reader.GetString(3), LM830reader.GetString(4),
                           LM830reader.GetInt32(5), LM830reader.GetString(6)));
                }
                return LM830Bitacoralst;
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830ActualizarDVH(string LM830v, string LM830dvhCalculado)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"UPDATE Bitacora SET DVH = @DVH WHERE Id_Evento = @IdEvento";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@DVH", LM830dvhCalculado);
                LM830_sqlcommand.Parameters.AddWithValue("@IdEvento", LM830v);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }
    }
}

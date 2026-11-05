using LM830DAL;
using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LM830DAL
{
    public class LM830UsuarioDAL : LM830AbstractDAL<LM830Usuario>
    {
        public LM830UsuarioDAL() : base() { }

        public void LM830Registrar(LM830Usuario LM830entity, string LM830DVH)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"INSERT INTO Usuario
                    (DNI, Nombre, Apellido, UserName, Password, Email, Bloqueado, Activo, Rol, DVH, Intentos)
                    VALUES (@dni, @nombre, @apellido, @username, @password, @email, 0, 1, @rol, @dvh, 0);";

                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830entity.LM830DNI);
                LM830_sqlcommand.Parameters.AddWithValue("@nombre", LM830entity.LM830Nombre);
                LM830_sqlcommand.Parameters.AddWithValue("@apellido", LM830entity.LM830Apellido);
                LM830_sqlcommand.Parameters.AddWithValue("@username", LM830entity.LM830Username);
                LM830_sqlcommand.Parameters.AddWithValue("@password", LM830entity.LM830Password);
                LM830_sqlcommand.Parameters.AddWithValue("@email", LM830entity.LM830Email);
                LM830_sqlcommand.Parameters.AddWithValue("@Rol", LM830entity.LM830Rol);
                LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830DVH);

                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830BloquearUsuario(string LM830username)
        {
            try
            {
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET Bloqueado = 1 WHERE UserName = @user;";
                LM830_sqlcommand.Parameters.AddWithValue("@user", LM830username);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public int LM830ObtenerIntentosFallidos(string LM830dNI)
        {
            try
            {
                LM830_sqlcommand.CommandText = "SELECT Intentos FROM Usuario WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dNI);
                LM830_sqlserver.Open();
                using (var LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830reader.Read()) return LM830reader.GetInt32(0);
                }
                throw new Exception($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("UserDalText1")} {LM830dNI}");
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public LM830Usuario LM830ObtenerPorUserName(string LM830usuario)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT DNI, Nombre, Apellido, UserName, Password, Email,
                    Bloqueado, Activo, Rol FROM Usuario WHERE UserName = @username;";
                LM830_sqlcommand.Parameters.AddWithValue("@username", LM830usuario);
                LM830_sqlserver.Open();
                using (var LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830reader.Read())
                        return new LM830Usuario(LM830reader.GetString(0), LM830reader.GetString(1), LM830reader.GetString(2),
                            LM830reader.GetString(3), LM830reader.GetString(4), LM830reader.GetString(5),
                            LM830reader.GetBoolean(6), LM830reader.GetBoolean(7), LM830reader.GetString(8));
                }
                return null;
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830ResetearIntentos(LM830Usuario LM830usuario)
        {
            try
            {
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET Intentos = 0 WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830usuario.LM830DNI);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830SumarIntentoFallido(LM830Usuario LM830usuario)
        {
            try
            {
                int LM830intentos = LM830ObtenerIntentosFallidos(LM830usuario.LM830DNI);
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET Intentos = @intentos WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830usuario.LM830DNI);
                LM830_sqlcommand.Parameters.AddWithValue("@intentos", LM830intentos + 1);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public LM830Usuario LM830BuscarUsuarioPorDNI(string LM830dNI)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT DNI, Nombre, Apellido, UserName, Password, Email,
                    Bloqueado, Activo, Rol FROM Usuario WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dNI);
                LM830_sqlserver.Open();
                using (var LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830reader.Read())
                        return new LM830Usuario(LM830reader.GetString(0), LM830reader.GetString(1), LM830reader.GetString(2),
                            LM830reader.GetString(3), LM830reader.GetString(4), LM830reader.GetString(5),
                            LM830reader.GetBoolean(6), LM830reader.GetBoolean(7), LM830reader.GetString(8));
                }
                return null;
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Usuario> LM830ListarTodosLosUsuarios()
        {
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT DNI, Nombre, Apellido, UserName, Password, Email,
                    Bloqueado, Activo, Rol FROM Usuario;";
                LM830_sqlserver.Open();
                var LM830reader = LM830_sqlcommand.ExecuteReader();
                var LM830lista = new List<LM830Usuario>();
                while (LM830reader.Read())
                    LM830lista.Add(new LM830Usuario(LM830reader.GetString(0), LM830reader.GetString(1), LM830reader.GetString(2),
                        LM830reader.GetString(3), LM830reader.GetString(4), LM830reader.GetString(5),
                        LM830reader.GetBoolean(6), LM830reader.GetBoolean(7), LM830reader.GetString(8)));
                return LM830lista;
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Usuario> LM830ListarTodosLosUsuariosDVH()
        {
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT DNI, Nombre, Apellido, UserName, Password, Email,
                    Bloqueado, Activo, Rol, Intentos, DVH FROM Usuario;";
                LM830_sqlserver.Open();
                var LM830reader = LM830_sqlcommand.ExecuteReader();
                var LM830lista = new List<LM830Usuario>();
                while (LM830reader.Read())
                    LM830lista.Add(new LM830Usuario(
                        LM830reader.GetString(0), LM830reader.GetString(1), LM830reader.GetString(2),
                        LM830reader.GetString(3), LM830reader.GetString(4), LM830reader.GetString(5),
                        LM830reader.GetBoolean(6), LM830reader.GetBoolean(7), LM830reader.GetString(8),
                        LM830reader.GetInt32(9), LM830reader.GetString(10)));
                return LM830lista;
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830EliminarLogico(string LM830_dni)
        {
            try
            {
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET Activo = 0 WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830_dni);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830Modificar(object LM830dni, LM830Usuario LM830UserNew)
        {
            try
            {
                string LM830cadenaDV =
                    LM830UserNew.LM830DNI +
                    LM830UserNew.LM830Nombre +
                    LM830UserNew.LM830Apellido +
                    LM830UserNew.LM830Username +
                    LM830UserNew.LM830Password +
                    LM830UserNew.LM830Email +
                    LM830UserNew.LM830Bloqueado +
                    LM830UserNew.LM830Activo +
                    LM830UserNew.LM830Rol;

                string LM830nuevoDVH = LM830DigitoVerificador.LM830CalcularDVH(LM830cadenaDV);

                LM830_sqlcommand.CommandText = @"UPDATE Usuario
                    SET DNI = @dninuevo, Nombre = @nombre, Apellido = @apellido,
                        UserName = @username, Email = @email, Rol = @rol, DVH = @dvh
                    WHERE DNI = @dni;";

                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dni);
                LM830_sqlcommand.Parameters.AddWithValue("@dninuevo", LM830UserNew.LM830DNI);
                LM830_sqlcommand.Parameters.AddWithValue("@nombre", LM830UserNew.LM830Nombre);
                LM830_sqlcommand.Parameters.AddWithValue("@apellido", LM830UserNew.LM830Apellido);
                LM830_sqlcommand.Parameters.AddWithValue("@username", LM830UserNew.LM830Username);
                LM830_sqlcommand.Parameters.AddWithValue("@email", LM830UserNew.LM830Email);
                LM830_sqlcommand.Parameters.AddWithValue("@rol", LM830UserNew.LM830Rol);
                LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830nuevoDVH);

                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw new Exception(LM830ex.Message, LM830ex); }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830DesbloquearUsuario(string LM830dNI, string LM830nuevaClave)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"UPDATE Usuario
                    SET Bloqueado = 0, Password = @password, Intentos = 0
                    WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dNI);
                LM830_sqlcommand.Parameters.AddWithValue("@password", LM830nuevaClave);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830CambiarClave(string LM830usuario, string LM830nuevaContra)
        {
            try
            {
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET Password = @nuevaPassword WHERE UserName = @usuario;";
                LM830_sqlcommand.Parameters.AddWithValue("@usuario", LM830usuario);
                LM830_sqlcommand.Parameters.AddWithValue("@nuevaPassword", LM830nuevaContra);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830ActivarUsuario(string LM830dNI)
        {
            try
            {
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET Activo = 1 WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dNI);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830ActualizarDVH(string LM830dNI, string LM830dvhCalculado)
        {
            try
            {
                LM830_sqlcommand.CommandText = "UPDATE Usuario SET DVH = @dvh WHERE DNI = @dni;";
                LM830_sqlcommand.Parameters.AddWithValue("@dni", LM830dNI);
                LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvhCalculado);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex) { throw LM830ex; }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }
    }
}

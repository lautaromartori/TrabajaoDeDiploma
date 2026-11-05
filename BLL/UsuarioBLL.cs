using LM830DAL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LM830BLL
{
    public class LM830UsuarioBLL
    {
        private readonly LM830UsuarioDAL LM830usuarioDAL;
        private readonly LM830BitacoraBLL LM830bitacoraBLL;
        private readonly LM830DigitoVerificadorBLL LM830digitoVerificadorBLL;

        public LM830UsuarioBLL()
        {
            LM830usuarioDAL = new LM830UsuarioDAL();
            LM830bitacoraBLL = new LM830BitacoraBLL();
            LM830digitoVerificadorBLL = new LM830DigitoVerificadorBLL();
        }

        public LM830LoginResultado LM830Login(string LM830usuario, string LM830contraseña)
        {
            try
            {
                if (LM830SessionManager.LM830Instance.LM830Logueado())
                {
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText1"));
                }

                if (LM830usuarioDAL == null)
                {
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText2"));
                }

                LM830Usuario LM830usuarioBE = LM830usuarioDAL.LM830ObtenerPorUserName(LM830usuario);
                if (LM830usuarioBE != null)
                {
                    if (!LM830usuarioBE.LM830Activo) return LM830LoginResultado.LM830Inactivo;
                    if (LM830usuarioBE.LM830Bloqueado) return LM830LoginResultado.LM830Bloqueado;

                    if (LM830usuarioBE.LM830Password != LM830Encriptador.LM830GetHash256(LM830contraseña))
                    {
                        LM830usuarioDAL.LM830SumarIntentoFallido(LM830usuarioBE);
                        bool LM830bloquear = LM830usuarioDAL.LM830ObtenerIntentosFallidos(LM830usuarioBE.LM830DNI) >= 3;
                        if (LM830bloquear)
                        {
                            LM830usuarioDAL.LM830BloquearUsuario(LM830usuarioBE.LM830Username);
                        }

                        LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830usuarioBE.LM830DNI);
                        LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                        LM830RegistrarEventoLogin(LM830usuarioBE.LM830Username, LM830bloquear ? "Usuario bloqueado por intentos fallidos" : "Login fallido", LM830bloquear ? 3 : 2);

                        return LM830bloquear ? LM830LoginResultado.LM830Bloqueado : LM830LoginResultado.LM830ContraseñaIncorrecta;
                    }
                    else
                    {
                        if (LM830usuarioDAL.LM830ObtenerIntentosFallidos(LM830usuarioBE.LM830DNI) > 0)
                        {
                            LM830usuarioDAL.LM830ResetearIntentos(LM830usuarioBE);
                            LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830usuarioBE.LM830DNI);
                            LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                        }

                        LM830BLL.LM830PerfilBLL LM830perfilBLL = new LM830BLL.LM830PerfilBLL();
                        var LM830todosLosPerfiles = LM830perfilBLL.LM830ObtenerPerfiles();
                        var LM830perfilUsuario = LM830todosLosPerfiles.FirstOrDefault(LM830p => LM830p.LM830Nombre == LM830usuarioBE.LM830Rol);

                        if (LM830perfilUsuario != null)
                        {
                            LM830usuarioBE.LM830Permisos.Add(LM830perfilUsuario);
                        }

                        LM830SessionManager.LM830Instance.LM830Loguear(LM830usuarioBE);

                        return LM830LoginResultado.LM830Valido;
                    }
                }
                return LM830LoginResultado.LM830UsuarioNoEncontrado;
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830ex.Message);
            }
        }

        private void LM830RegistrarEventoLogin(string LM830login, string LM830evento, int LM830criticidad)
        {
            try
            {
                LM830bitacoraBLL.LM830RegistrarEvento(new LM830Bitacora { LM830Login = LM830login, LM830Modulo = "Usuarios", LM830Evento = LM830evento, LM830Criticidad = LM830criticidad });
            }
            catch { }
        }

        public void LM830Desloguear()
        {
            try
            {
                LM830Bitacora LM830bitacora = new LM830Bitacora();
                LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;

                LM830SessionManager.LM830Instance.LM830Desloguear();

                LM830bitacora.LM830Modulo = "Usuarios";
                LM830bitacora.LM830Evento = "Desloguear usuario";
                LM830bitacora.LM830Criticidad = 1;
                LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830ex.Message);
            }
        }

        public void LM830RegistrarUsuario(LM830Usuario LM830usuarioBE)
        {
            try
            {
                LM830ValidarCaracteresUsuario(LM830usuarioBE);
                if (LM830usuarioDAL.LM830BuscarUsuarioPorDNI(LM830usuarioBE.LM830DNI) == null)
                {
                    LM830usuarioBE.LM830Bloqueado = false;
                    LM830usuarioBE.LM830Activo = true;
                    LM830usuarioBE.LM830Intentos = 0;
                    string LM830cadenaDV = LM830DigitoVerificadorBLL.LM830CadenaDVH_Usuario(LM830usuarioBE);

                    LM830usuarioDAL.LM830Registrar(LM830usuarioBE, LM830DigitoVerificador.LM830CalcularDVH(LM830cadenaDV));
                    LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                    LM830Bitacora LM830bitacora = new LM830Bitacora();
                    LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                    LM830bitacora.LM830Modulo = "Usuarios";
                    LM830bitacora.LM830Evento = "Crear usuario exitoso";
                    LM830bitacora.LM830Criticidad = 1;
                    LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);
                }
                else
                {
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText3"));
                }
            }
            catch (Exception LM830ex)
            {
                throw new Exception(LM830ex.Message, LM830ex);
            }
        }

        private void LM830ValidarCaracteresUsuario(LM830Usuario LM830usuario)
        {
            if (!Regex.IsMatch(LM830usuario.LM830Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText4"));
            if (!Regex.IsMatch(LM830usuario.LM830DNI, @"^\d{8}$")) throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText5"));
            if (!Regex.IsMatch(LM830usuario.LM830Nombre, @"^.{3,}$") || !Regex.IsMatch(LM830usuario.LM830Apellido, @"^.{3,}$"))
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText6"));
        }

        public List<LM830Usuario> LM830ListarUsuariosActivos()
        {
            var LM830todos = LM830usuarioDAL.LM830ListarTodosLosUsuarios();
            var LM830activos = LM830todos.Where(LM830u => LM830u.LM830Activo).ToList();
            return LM830activos;
        }

        public void LM830EliminarLogico(string LM830dNI)
        {
            try
            {
                LM830Usuario LM830user = LM830usuarioDAL.LM830BuscarUsuarioPorDNI(LM830dNI);

                if (LM830user.LM830Activo)
                {
                    LM830usuarioDAL.LM830EliminarLogico(LM830dNI);
                    LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830dNI);
                    LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();

                    LM830Bitacora LM830bitacora = new LM830Bitacora();
                    LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                    LM830bitacora.LM830Modulo = "Usuarios";
                    LM830bitacora.LM830Evento = "Eliminar Usuario (Baja lógica) exitoso";
                    LM830bitacora.LM830Criticidad = 1;
                    LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);
                }
                else
                {
                    LM830usuarioDAL.LM830ActivarUsuario(LM830dNI);
                    LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830dNI);
                    LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                    LM830Bitacora LM830bitacora = new LM830Bitacora();
                    LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                    LM830bitacora.LM830Modulo = "Usuarios";
                    LM830bitacora.LM830Evento = "Activar Usuario (Baja lógica) exitoso";
                    LM830bitacora.LM830Criticidad = 1;
                    LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);
                }
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
        }

        public LM830LoginResultado LM830CambiarClave(string LM830usuario, string LM830contraActual, string LM830nuevaContra)
        {
            try
            {
                LM830Usuario LM830user = LM830usuarioDAL.LM830ObtenerPorUserName(LM830usuario);

                if (LM830user == null) return LM830LoginResultado.LM830UsuarioNoEncontrado;
                if (LM830user.LM830Password == LM830Encriptador.LM830GetHash256(LM830nuevaContra)) return LM830LoginResultado.LM830ContraseñaIguales;
                if (LM830user.LM830Password != LM830Encriptador.LM830GetHash256(LM830contraActual)) return LM830LoginResultado.LM830ContraseñaIncorrecta;
                if (LM830user.LM830Bloqueado) return LM830LoginResultado.LM830Bloqueado;

                LM830usuarioDAL.LM830CambiarClave(LM830usuario, LM830Encriptador.LM830GetHash256(LM830nuevaContra));
                LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830user.LM830DNI);
                LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                LM830Bitacora LM830bitacora = new LM830Bitacora();
                LM830bitacora.LM830Login = LM830usuario;
                LM830bitacora.LM830Modulo = "Usuarios";
                LM830bitacora.LM830Evento = "Cambiar Clave exitoso";
                LM830bitacora.LM830Criticidad = 1;
                LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);

                return LM830LoginResultado.LM830Valido;
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
        }

        public void LM830Modificar(string LM830dNI, LM830Usuario LM830usuarioBE)
        {
            LM830Usuario LM830existente = LM830usuarioDAL.LM830BuscarUsuarioPorDNI(LM830usuarioBE.LM830DNI);
            if (LM830existente != null && LM830existente.LM830DNI != LM830dNI)
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText7"));
            else
            {
                LM830Usuario LM830repetido = LM830usuarioDAL.LM830ObtenerPorUserName(LM830usuarioBE.LM830Username);
                if (LM830repetido != null && LM830repetido.LM830DNI != LM830dNI)
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText8"));
                else
                {
                    LM830usuarioDAL.LM830Modificar(LM830dNI, LM830usuarioBE);
                    LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830usuarioBE.LM830DNI);
                    LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                    LM830Bitacora LM830bitacora = new LM830Bitacora();
                    LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                    LM830bitacora.LM830Modulo = "Usuarios";
                    LM830bitacora.LM830Evento = "Modificar Usuario exitoso";
                    LM830bitacora.LM830Criticidad = 1;
                    LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);
                }
            }
        }

        public void LM830DesbloquearUsuario(LM830Usuario LM830usuarioBE)
        {
            try
            {
                LM830Usuario LM830user = LM830usuarioDAL.LM830BuscarUsuarioPorDNI(LM830usuarioBE.LM830DNI);

                if (LM830user.LM830Bloqueado)
                {
                    string LM830nuevaClave = LM830Encriptador.LM830GetHash256(LM830user.LM830DNI + LM830user.LM830Nombre);

                    LM830usuarioDAL.LM830DesbloquearUsuario(LM830user.LM830DNI, LM830nuevaClave);
                    LM830digitoVerificadorBLL.LM830RecalcularDVH_Usuario(LM830user.LM830DNI);
                    LM830digitoVerificadorBLL.LM830RecalcularDVV_Usuario();
                    LM830Bitacora LM830bitacora = new LM830Bitacora();
                    LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                    LM830bitacora.LM830Modulo = "Usuarios";
                    LM830bitacora.LM830Evento = "Desbloquear Usuario exitoso";
                    LM830bitacora.LM830Criticidad = 1;
                    LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);
                }
                else
                {
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserBLLText9"));
                }
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
        }

        public List<LM830Usuario> LM830ListarTodosUsuarios() => LM830usuarioDAL.LM830ListarTodosLosUsuarios();
        public LM830Usuario LM830BuscarUsuarioPorDNI(string LM830v) => LM830usuarioDAL.LM830BuscarUsuarioPorDNI(LM830v);
        public LM830Usuario LM830BuscarUsuarioPorUserName(string LM830user) => LM830usuarioDAL.LM830ObtenerPorUserName(LM830user);

        public bool LM830ValidarNuevoUsuario(string LM830user, string LM830contra)
        {
            LM830Usuario LM830usuario = LM830usuarioDAL.LM830ObtenerPorUserName(LM830user);
            if (LM830usuario != null)
            {
                if (LM830usuario.LM830Password == LM830Encriptador.LM830GetHash256(LM830usuario.LM830DNI + LM830usuario.LM830Nombre))
                {
                    if (LM830Encriptador.LM830GetHash256(LM830contra) == LM830usuario.LM830Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string LM830RetornarRol(string LM830username)
        {
            LM830Usuario LM830usuario = LM830BuscarUsuarioPorUserName(LM830username);
            return LM830usuario.LM830Rol;
        }
    }
}

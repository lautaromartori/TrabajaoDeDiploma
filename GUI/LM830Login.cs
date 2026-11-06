using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM830BLL;
using LM830Servicios;

namespace LM830GUI
{
    public partial class LM830Login : Form, LM830IObserver
    {
        LM830BitacoraBLL LM830bitacoraBLL = new LM830BitacoraBLL();
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        public LM830Login()
        {
            InitializeComponent();
            LM830IniciarControles();
        }

        private void LM830IniciarControles()
        {
            LM830txtContraseña.UseSystemPasswordChar = false;
            LM830MostrarClave(false);
        }

        private void LM830MostrarClave(bool LM830mostrar)
        {
            if (LM830mostrar)
            {
                LM830pbMostrarClave.Image = Properties.Resources.OjoAbierto;
            }
            else
            {
                LM830pbMostrarClave.Image = Properties.Resources.OjoCerrado;
            }
        }

        private void LM830btnCerrar_Click(object LM830sender, EventArgs LM830e)
        {
            Application.Exit();
        }

        private void LM830btnMinimizar_Click(object LM830sender, EventArgs LM830e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LM830panel1_MouseUp(object LM830sender, MouseEventArgs LM830e)
        {
            LM830arrastrando = false;
        }

        private void LM830panel1_MouseMove(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830arrastrando)
            {
                this.Location = new Point(this.Location.X + (LM830e.X - LM830posX), this.Location.Y + (LM830e.Y - LM830posY));
            }
        }

        private void LM830pbMostrarClave_Click(object LM830sender, EventArgs LM830e)
        {
            bool LM830mostrar = LM830txtContraseña.UseSystemPasswordChar;
            if (LM830mostrar)
            {
                LM830MostrarClave(false);
                LM830txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                LM830MostrarClave(true);
                LM830txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void LM830btnLogin_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830ValidarCamposVacios();
                LM830UsuarioBLL LM830usuarioBLL = new LM830UsuarioBLL();

                if (LM830usuarioBLL.LM830ValidarNuevoUsuario(LM830txtUsuario.Text, LM830txtContraseña.Text))
                {
                    MessageBox.Show("Debes crear una nueva contrasenia", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    LM830CambiarContraseña LM830cambioContraseña = new LM830CambiarContraseña();
                    LM830cambioContraseña.ShowDialog();
                    return;
                }

                switch (LM830usuarioBLL.LM830Login(LM830txtUsuario.Text, LM830txtContraseña.Text))
                {
                    case LM830LoginResultado.LM830ContraseñaIncorrecta:
                        throw new Exception("Contraseña Incorrecta, vuelva a intentar.");

                    case LM830LoginResultado.LM830UsuarioNoEncontrado:
                        throw new Exception("Usuario Incorrecto, vuelva a intentar.");
                    case LM830LoginResultado.LM830Valido:
                        LM830IdiomaBLL LM830idiomaBLL = new LM830IdiomaBLL();
                        LM830DigitoVerificadorBLL LM830digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

                        string LM830username = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                        string LM830idioma = LM830idiomaBLL.LM830ObtenerIdioma(LM830username);
                        var LM830Auditoria = LM830digitoVerificadorBLL.LM830EjecutarAuditoriaDetalladaCompleta();

                        LM830LanguageManager.LM830Instance.LM830CargarIdioma(LM830idioma);

                        if (LM830Auditoria.Count > 0)
                        {
                            if (LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Gestionar DigitoVerificadores"))
                            {
                                this.Hide();
                                LM830frmReparacionDV LM830frmRep = new LM830frmReparacionDV();
                                LM830frmRep.Show();
                                break;
                            }

                            string LM830mensaje = "Se han detectado inconsistencias en la base de datos, por favor contacte al administrador.";
                            MessageBox.Show(LM830mensaje, "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LM830SessionManager.LM830Instance.LM830Desloguear();
                            Application.Exit();
                            return;
                        }

                        LM830Bitacora LM830bitacora = new LM830Bitacora();
                        LM830bitacora.LM830Login = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                        LM830bitacora.LM830Modulo = "Usuarios";
                        LM830bitacora.LM830Evento = "Login exitoso";
                        LM830bitacora.LM830Criticidad = 1;
                        LM830bitacoraBLL.LM830RegistrarEvento(LM830bitacora);

                        this.Hide();
                        LM830Menu LM830menu = new LM830Menu();
                        LM830menu.ShowDialog();
                        break;
                    case LM830LoginResultado.LM830Inactivo:
                        throw new Exception("El usuario está dado de baja. Pedile a un administrador que lo active desde Usuarios.");
                    case LM830LoginResultado.LM830Bloqueado:
                        throw new Exception("Usuario Bloqueado, contacte al administrador.");
                    case LM830LoginResultado.LM830Error:
                        throw new Exception("Error al intentar iniciar sesión, vuelva a intentar.");
                    default:
                        throw new Exception("Error desconocido, vuelva a intentar.");
                }
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830ValidarCamposVacios()
        {
            if (LM830txtUsuario.Text == "")
            {
                throw new Exception("Ingrese un Usuario!");
            }
            if (LM830txtContraseña.Text == "")
            {
                throw new Exception("Ingrese una Contraseña!");
            }
        }

        private void LM830linkCambioContraseña_LinkClicked(object LM830sender, LinkLabelLinkClickedEventArgs LM830e)
        {
            this.Hide();
            LM830CambiarContraseña LM830cambioContraseña = new LM830CambiarContraseña();
            LM830cambioContraseña.ShowDialog();
        }

        private void LM830txtUsuario_KeyPress(object LM830sender, KeyPressEventArgs LM830e)
        {
            if (LM830e.KeyChar == (char)Keys.Enter)
            {
                LM830e.Handled = true;
            }
        }

        private void LM830txtContraseña_KeyPress(object LM830sender, KeyPressEventArgs LM830e)
        {
            if (LM830e.KeyChar == (char)Keys.Enter)
            {
                LM830e.Handled = true;
            }
        }
        private void LM830panel1_MouseDown(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830e.Button == MouseButtons.Left)
            {
                LM830arrastrando = true;
                LM830posX = LM830e.X;
                LM830posY = LM830e.Y;
            }
        }

        private void LM830Login_Load(object LM830sender, EventArgs LM830e)
        {
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            throw new NotImplementedException();
        }
    }
}

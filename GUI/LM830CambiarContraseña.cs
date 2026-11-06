using LM830BLL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830CambiarContraseña : Form,LM830IObserver
    {
        public LM830CambiarContraseña()
        {
            InitializeComponent();
        }

        private void LM830btnGuardarContra_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830ValidarCamposVacios();
                LM830UsuarioBLL LM830usuarioBLL = new LM830UsuarioBLL();

                switch (LM830usuarioBLL.LM830CambiarClave(LM830txtUsuario.Text, LM830txtContraseña.Text, LM830txtNuevaContraseña.Text))
                {
                    case LM830LoginResultado.LM830Valido:
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamClaMsj1"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(LM830SessionManager.LM830Instance.LM830Logueado())
                        {
                            LM830usuarioBLL.LM830Desloguear();
                        }

                        this.Close();
                        LM830Login LM830login = new LM830Login();
                        LM830login.Show();
                        break;
                    case LM830LoginResultado.LM830ContraseñaIguales:
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamClaMsj2"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LM830LoginResultado.LM830UsuarioNoEncontrado:
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamClaMsj3"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LM830LoginResultado.LM830ContraseñaIncorrecta:
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamClaMsj4"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LM830LoginResultado.LM830Bloqueado:
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamMsj5"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830ValidarCamposVacios()
        {
            if (LM830txtUsuario.Text == "")
            {
                LM830txtUsuario.Focus();
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamMsj6"));
            }
            if (LM830txtContraseña.Text == "")
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamMsj7"));
            }
            if (LM830txtNuevaContraseña.Text == "")
            {
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("CamMsj8"));
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

        private void LM830linkVolver_LinkClicked(object LM830sender, LinkLabelLinkClickedEventArgs LM830e)
        {
            if (LM830SessionManager.LM830Instance.LM830Logueado())
            {
                LM830Navegacion.LM830VolverAlMenu(this);
            }
            else
            {
                this.Close();
                LM830Login LM830login = new LM830Login();
                LM830login.Show();
            }
        }

        private void LM830pbMostrarClave_Click(object LM830sender, EventArgs LM830e)
        {
            bool LM830mostrar = LM830txtContraseña.UseSystemPasswordChar;
            if (LM830mostrar)
            {
                LM830MostrarClave(false);
                LM830txtContraseña.UseSystemPasswordChar = false;
                LM830txtNuevaContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                LM830MostrarClave(true);
                LM830txtContraseña.UseSystemPasswordChar = true;
                LM830txtNuevaContraseña.UseSystemPasswordChar = true;
            }
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

        private void LM830txtNuevaContraseña_KeyPress(object LM830sender, KeyPressEventArgs LM830e)
        {
            if (LM830e.KeyChar == (char)Keys.Enter)
            {
                LM830e.Handled = true;
            }
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830lblUsuarioFCC.Text = LM830lenguaje.LM830GetTraduction("lblUsuarioFCC");
            LM830lblContraseñaActual.Text = LM830lenguaje.LM830GetTraduction("lblContraseñaActual");
            LM830lblContraseñaFCC.Text = LM830lenguaje.LM830GetTraduction("lblContraseñaFCC");

            LM830btnGuardarContra.Text = LM830lenguaje.LM830GetTraduction("btnGuardarContra");
            LM830linkVolver.Text = LM830lenguaje.LM830GetTraduction("linkVolver");
        }

        private void LM830CambiarContraseña_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
        }
    }
}

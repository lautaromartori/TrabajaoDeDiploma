using BLL;
using GUI.RFN1;
using GUI.RFN2;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Menu : Form, IObserver
    {
        int posX, posY;
        bool arrastrando = false;
        public Menu()
        {
            InitializeComponent();
            customMenu();
        }
        private void customMenu()
        {
            panelAdminSubmenu.Visible = false;
            panelUsuarioSubmenu.Visible = false;
            panelGestionSubmenu.Visible = false;
            panelPremiosSubmenu.Visible = false;
        }
        private void esconderSubmenu()
        {
            if (panelAdminSubmenu.Visible == true)
                panelAdminSubmenu.Visible = false;
            if (panelUsuarioSubmenu.Visible == true)
                panelUsuarioSubmenu.Visible = false;
            if (panelGestionSubmenu.Visible == true)
                panelGestionSubmenu.Visible = false;
            if (panelPremiosSubmenu.Visible == true)
                panelPremiosSubmenu.Visible = false;
        }
        private void mostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                esconderSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(panelAdminSubmenu);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(panelUsuarioSubmenu);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            customMenu();
            LanguageManager.Instance.AgregarObservador(this);
            Actualizar(LanguageManager.Instance);
        }

        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
            mostrarSubmenu(panelAdminSubmenu);
        }

        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            mostrarSubmenu(panelUsuarioSubmenu);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastrando = true;
                posX = e.X;
                posY = e.Y;
            }
        }

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando)
            {
                this.Location = new Point(this.Location.X + (e.X - posX), this.Location.Y + (e.Y - posY));
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso("Ver Bitacora"))
            {
                MessageBox.Show("No tiene permisos para acceder a la Bitácora.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            FormBitacora formBitacora = new FormBitacora();
            formBitacora.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso("Ver Usuarios"))
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de usuarios.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
        }

        private void btnReLogin_Click(object sender, EventArgs e)
        {
            if(SessionManager.Instance != null )
            {
                MessageBox.Show(LanguageManager.Instance.GetTraduction("YaHaySesionActiva"), LanguageManager.Instance.GetTraduction("Informacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string Decision = MessageBox.Show(LanguageManager.Instance.GetTraduction("menumsj1"), LanguageManager.Instance.GetTraduction("menumsj2"), MessageBoxButtons.YesNo).ToString();
            if (Decision == "Yes")
            {
                IdiomaBLL idiomaBLL = new IdiomaBLL();

                string username = SessionManager.Instance.UsuarioActual().Username;
                idiomaBLL.GuardarIdioma(username, LanguageManager.Instance.CodigoIdiomaActual);

                new UsuarioBLL().Desloguear();

                Login login = new Login();
                login.Show();
                LanguageManager.Instance.EliminarObservador(this);
                this.Close();
            }
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            this.Hide();
            CambiarContraseña cambiarContraseña = new CambiarContraseña();
            cambiarContraseña.Show();
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso("Ver Perfiles"))
            {
                MessageBox.Show("No tiene permisos para acceder a Gestión de Perfiles.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmGestionPerfiles gestionPerfiles = new frmGestionPerfiles();
            this.Hide();
            gestionPerfiles.Show();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso("Ver Respaldos"))
            {
                MessageBox.Show("No tiene permisos para acceder a Backup.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            FormBackup formBackup = new FormBackup();
            formBackup.Show();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso("Ver Respaldos"))
            {
                MessageBox.Show("No tiene permisos para acceder a Restore.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            FormRestore formRestore = new FormRestore();
            formRestore.Show();
        }

        private void BarraTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }

        private void btnCambiarIdioma_Click(object sender, EventArgs e)
        {
            this.Hide();
            CambiarIdioma cambiarContraseña = new CambiarIdioma();
            cambiarContraseña.Show();
        }

        private void btnDigitoVerificador_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso("Gestionar DigitoVerificadores"))
            {
                MessageBox.Show("No tiene permisos para acceder a Digitos Verificadores.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            frmReparacionDV frmReparacionDV = new frmReparacionDV();
            frmReparacionDV.Show();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(panelGestionSubmenu);
        }

        private bool AbrirSiTienePermiso(string permiso, Func<Form> crear)
        {
            if (!SessionManager.Instance.UsuarioActual().TienePermiso(permiso))
            {
                MessageBox.Show($"No tiene permisos para acceder a {permiso}.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            this.Hide();
            crear().Show();
            return true;
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Registrar Cliente", () => new frmRegistrarCliente());

        private void btnConsultarSaldo_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Consultar Saldo", () => new frmSaldo());

        private void btnRegistrarVenta_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Registrar Venta", () => new frmVenta());

        private void btnRegistrarReclamo_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Registrar Reclamo", () => new frmReclamo());

        private void btnResolverReclamos_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Resolver Reclamo", () => new frmResolverReclamos());

        private void btnComprobantes_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Emitir Comprobante", () => new frmComprobantes());

        private void btnPremios_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(panelPremiosSubmenu);
        }

        private void btnPremiosCanjeables_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Consultar Premios", () => new frmPremios());

        private void btnAutorizarCanjes_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Autorizar Canje", () => new frmAutorizarCanjes());

        private void btnEntregarPremio_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Entregar Premio", () => new frmEntregarPremio());

        private void btnAnularCanje_Click(object sender, EventArgs e) =>
            AbrirSiTienePermiso("Anular Canje", () => new frmAnularCanje());

        public void Actualizar(LanguageManager lenguaje)
        {
            btnAdmin.Text = LanguageManager.Instance.GetTraduction("btnAdmin");
            btnUsuarios.Text = LanguageManager.Instance.GetTraduction("btnUsuarios");
            btnPerfiles.Text = LanguageManager.Instance.GetTraduction("btnPerfiles");
            btnBackUp.Text = LanguageManager.Instance.GetTraduction("btnBackUp");
            btnRestore.Text = LanguageManager.Instance.GetTraduction("btnRestore");
            btnBitacora.Text = LanguageManager.Instance.GetTraduction("btnBitacora");
            btnDigitoVerificador.Text = LanguageManager.Instance.GetTraduction("btnDigitoVerificador");
            btnUsuario.Text = LanguageManager.Instance.GetTraduction("btnUsuario");
            btnReLogin.Text = LanguageManager.Instance.GetTraduction("btnReLogin");
            btnCambiarClave.Text = LanguageManager.Instance.GetTraduction("btnCambiarClave");
            btnLogout.Text = LanguageManager.Instance.GetTraduction("btnLogout");
            btnCambiarIdioma.Text = LanguageManager.Instance.GetTraduction("btnCambiarIdioma");

            btnGestion.Text = LanguageManager.Instance.GetTraduction("btnGestion");
            btnRegistrarCliente.Text = LanguageManager.Instance.GetTraduction("RFN1_RegistrarCliente");
            btnConsultarSaldo.Text = LanguageManager.Instance.GetTraduction("RFN1_ConsultarSaldo");
            btnRegistrarVenta.Text = LanguageManager.Instance.GetTraduction("RFN1_RegistrarVenta");
            btnRegistrarReclamo.Text = LanguageManager.Instance.GetTraduction("RFN1_RegistrarReclamo");
            btnResolverReclamos.Text = LanguageManager.Instance.GetTraduction("RFN1_ResolverReclamos");
            btnComprobantes.Text = LanguageManager.Instance.GetTraduction("CMP_Comprobantes");

            btnPremios.Text = LanguageManager.Instance.GetTraduction("btnPremios");
            btnPremiosCanjeables.Text = LanguageManager.Instance.GetTraduction("RFN2_PremiosCanjeables");
            btnAutorizarCanjes.Text = LanguageManager.Instance.GetTraduction("RFN2_AutorizarCanjes");
            btnEntregarPremio.Text = LanguageManager.Instance.GetTraduction("RFN2_EntregarPremio");
            btnAnularCanje.Text = LanguageManager.Instance.GetTraduction("RFN2_AnularCanje");
        }
    }
}

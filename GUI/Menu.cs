using LM830BLL;
using LM830GUI.LM830RFN1;
using LM830GUI.LM830RFN2;
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
    public partial class LM830Menu : Form, LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        public LM830Menu()
        {
            InitializeComponent();
            LM830customMenu();
        }
        private void LM830customMenu()
        {
            LM830panelAdminSubmenu.Visible = false;
            LM830panelUsuarioSubmenu.Visible = false;
            LM830panelGestionSubmenu.Visible = false;
            LM830panelPremiosSubmenu.Visible = false;
        }
        private void LM830esconderSubmenu()
        {
            if (LM830panelAdminSubmenu.Visible == true)
                LM830panelAdminSubmenu.Visible = false;
            if (LM830panelUsuarioSubmenu.Visible == true)
                LM830panelUsuarioSubmenu.Visible = false;
            if (LM830panelGestionSubmenu.Visible == true)
                LM830panelGestionSubmenu.Visible = false;
            if (LM830panelPremiosSubmenu.Visible == true)
                LM830panelPremiosSubmenu.Visible = false;
        }
        private void LM830mostrarSubmenu(Panel LM830submenu)
        {
            if (LM830submenu.Visible == false)
            {
                LM830esconderSubmenu();
                LM830submenu.Visible = true;
            }
            else
                LM830submenu.Visible = false;
        }

        private void LM830btnAdmin_Click(object LM830sender, EventArgs LM830e)
        {
            LM830mostrarSubmenu(LM830panelAdminSubmenu);
        }

        private void LM830btnUsuario_Click(object LM830sender, EventArgs LM830e)
        {
            LM830mostrarSubmenu(LM830panelUsuarioSubmenu);
        }

        private void LM830button3_Click(object LM830sender, EventArgs LM830e)
        {
        }

        private void LM830panelContenedor_Paint(object LM830sender, PaintEventArgs LM830e)
        {
        }

        private void LM830Menu_Load(object LM830sender, EventArgs LM830e)
        {
            LM830customMenu();
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
        }

        private void LM830btnAdmin_Click_1(object LM830sender, EventArgs LM830e)
        {
            LM830mostrarSubmenu(LM830panelAdminSubmenu);
        }

        private void LM830btnUsuario_Click_1(object LM830sender, EventArgs LM830e)
        {
            LM830mostrarSubmenu(LM830panelUsuarioSubmenu);
        }

        private void LM830btnCerrar_Click(object LM830sender, EventArgs LM830e)
        {
            Application.Exit();
        }

        private void LM830btnMaximizar_Click(object LM830sender, EventArgs LM830e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void LM830btnMinimizar_Click(object LM830sender, EventArgs LM830e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LM830BarraTitulo_MouseDown(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830e.Button == MouseButtons.Left)
            {
                LM830arrastrando = true;
                LM830posX = LM830e.X;
                LM830posY = LM830e.Y;
            }
        }

        private void LM830BarraTitulo_MouseMove(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830arrastrando)
            {
                this.Location = new Point(this.Location.X + (LM830e.X - LM830posX), this.Location.Y + (LM830e.Y - LM830posY));
            }
        }

        private void LM830btnBitacora_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Ver Bitacora"))
            {
                MessageBox.Show("No tiene permisos para acceder a la Bitácora.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            LM830FormBitacora LM830formBitacora = new LM830FormBitacora();
            LM830formBitacora.Show();
        }

        private void LM830btnUsuarios_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Ver Usuarios"))
            {
                MessageBox.Show("No tiene permisos para acceder a la gestión de usuarios.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            LM830Usuarios LM830usuarios = new LM830Usuarios();
            LM830usuarios.Show();
        }

        private void LM830btnReLogin_Click(object LM830sender, EventArgs LM830e)
        {
            if(LM830SessionManager.LM830Instance != null )
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("YaHaySesionActiva"), LM830LanguageManager.LM830Instance.LM830GetTraduction("Informacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LM830btnLogout_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830Decision = MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("menumsj1"), LM830LanguageManager.LM830Instance.LM830GetTraduction("menumsj2"), MessageBoxButtons.YesNo).ToString();
            if (LM830Decision == "Yes")
            {
                LM830IdiomaBLL LM830idiomaBLL = new LM830IdiomaBLL();

                string LM830username = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username;
                LM830idiomaBLL.LM830GuardarIdioma(LM830username, LM830LanguageManager.LM830Instance.LM830CodigoIdiomaActual);

                new LM830UsuarioBLL().LM830Desloguear();

                LM830Login LM830login = new LM830Login();
                LM830login.Show();
                LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
                this.Close();
            }
        }

        private void LM830btnCambiarClave_Click(object LM830sender, EventArgs LM830e)
        {
            this.Hide();
            LM830CambiarContraseña LM830cambiarContraseña = new LM830CambiarContraseña();
            LM830cambiarContraseña.Show();
        }

        private void LM830btnPerfiles_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Ver Perfiles"))
            {
                MessageBox.Show("No tiene permisos para acceder a Gestión de Perfiles.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            LM830frmGestionPerfiles LM830gestionPerfiles = new LM830frmGestionPerfiles();
            this.Hide();
            LM830gestionPerfiles.Show();
        }

        private void LM830btnBackUp_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Ver Respaldos"))
            {
                MessageBox.Show("No tiene permisos para acceder a Backup.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            LM830FormBackup LM830formBackup = new LM830FormBackup();
            LM830formBackup.Show();
        }

        private void LM830btnRestore_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Ver Respaldos"))
            {
                MessageBox.Show("No tiene permisos para acceder a Restore.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            LM830FormRestore LM830formRestore = new LM830FormRestore();
            LM830formRestore.Show();
        }

        private void LM830BarraTitulo_MouseUp(object LM830sender, MouseEventArgs LM830e)
        {
            LM830arrastrando = false;
        }

        private void LM830btnCambiarIdioma_Click(object LM830sender, EventArgs LM830e)
        {
            this.Hide();
            LM830CambiarIdioma LM830cambiarContraseña = new LM830CambiarIdioma();
            LM830cambiarContraseña.Show();
        }

        private void LM830btnBitacoraCambios_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Bitacora de Cambios", () => new LM830BitacoraCambios.LM830frmBitacoraCambios());

        private void LM830btnDigitoVerificador_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Gestionar DigitoVerificadores"))
            {
                MessageBox.Show("No tiene permisos para acceder a Digitos Verificadores.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Hide();
            LM830frmReparacionDV LM830frmReparacionDV = new LM830frmReparacionDV();
            LM830frmReparacionDV.Show();
        }

        private void LM830btnGestion_Click(object LM830sender, EventArgs LM830e)
        {
            LM830mostrarSubmenu(LM830panelGestionSubmenu);
        }

        private bool LM830AbrirSiTienePermiso(string LM830permiso, Func<Form> LM830crear)
        {
            if (!LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso(LM830permiso))
            {
                MessageBox.Show($"No tiene permisos para acceder a {LM830permiso}.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            this.Hide();
            LM830crear().Show();
            return true;
        }

        private void LM830btnRegistrarCliente_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Registrar Cliente", () => new LM830frmRegistrarCliente());

        private void LM830btnConsultarSaldo_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Consultar Saldo", () => new LM830frmSaldo());

        private void LM830btnRegistrarVenta_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Registrar Venta", () => new LM830frmVenta());

        private void LM830btnRegistrarReclamo_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Registrar Reclamo", () => new LM830frmReclamo());

        private void LM830btnResolverReclamos_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Resolver Reclamo", () => new LM830frmResolverReclamos());

        private void LM830btnComprobantes_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Emitir Comprobante", () => new LM830frmComprobantes());

        private void LM830btnGestionProductos_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Gestionar Productos", () => new LM830frmGestionProductos());

        private void LM830btnPremios_Click(object LM830sender, EventArgs LM830e)
        {
            LM830mostrarSubmenu(LM830panelPremiosSubmenu);
        }

        private void LM830btnPremiosCanjeables_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Consultar Premios", () => new LM830frmPremios());

        private void LM830btnAutorizarCanjes_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Autorizar Canje", () => new LM830frmAutorizarCanjes());

        private void LM830btnEntregarPremio_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Entregar Premio", () => new LM830frmEntregarPremio());

        private void LM830btnAnularCanje_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Anular Canje", () => new LM830frmAnularCanje());

        private void LM830btnGestionPremios_Click(object LM830sender, EventArgs LM830e) =>
            LM830AbrirSiTienePermiso("Gestionar Premios", () => new LM830frmGestionPremios());

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830btnAdmin.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnAdmin");
            LM830btnUsuarios.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnUsuarios");
            LM830btnPerfiles.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnPerfiles");
            LM830btnBackUp.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnBackUp");
            LM830btnRestore.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnRestore");
            LM830btnBitacora.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnBitacora");
            LM830btnDigitoVerificador.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnDigitoVerificador");
            LM830btnBitacoraCambios.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnBitacoraCambios");
            LM830btnUsuario.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnUsuario");
            LM830btnReLogin.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnReLogin");
            LM830btnCambiarClave.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnCambiarClave");
            LM830btnLogout.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnLogout");
            LM830btnCambiarIdioma.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnCambiarIdioma");

            LM830btnGestion.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnGestion");
            LM830btnRegistrarCliente.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN1_RegistrarCliente");
            LM830btnConsultarSaldo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN1_ConsultarSaldo");
            LM830btnRegistrarVenta.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN1_RegistrarVenta");
            LM830btnRegistrarReclamo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN1_RegistrarReclamo");
            LM830btnResolverReclamos.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN1_ResolverReclamos");
            LM830btnComprobantes.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("CMP_Comprobantes");

            LM830btnPremios.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnPremios");
            LM830btnPremiosCanjeables.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN2_PremiosCanjeables");
            LM830btnAutorizarCanjes.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN2_AutorizarCanjes");
            LM830btnEntregarPremio.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN2_EntregarPremio");
            LM830btnAnularCanje.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN2_AnularCanje");
            LM830btnGestionProductos.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN1_GestionProductos");
            LM830btnGestionPremios.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RFN2_GestionPremios");
        }
    }
}

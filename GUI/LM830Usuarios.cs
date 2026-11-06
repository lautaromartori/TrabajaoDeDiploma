using LM830BLL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830Usuarios : Form, LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        private LM830UserAction LM830userAction;
        private LM830UsuarioBLL LM830usuarioBLL;
        private LM830PerfilBLL LM830perfilBLL;

        public LM830Usuarios()
        {
            InitializeComponent();
            LM830usuarioBLL = new LM830UsuarioBLL();
            LM830perfilBLL = new LM830PerfilBLL();
            LM830lblTextoTabla.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblTextoTablaUserActivos");
            LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarUsuariosActivos());
            LM830MostrarCantidadUsuarios();
            LM830ConfigurarGrillaSeleccionFila(LM830dataGridView1);
            LM830ReiniciarBotones();
        }

        private void LM830CargarPerfiles()
        {
            LM830cbRol.Items.Clear();
            foreach (var LM830perfil in LM830perfilBLL.LM830ObtenerPerfiles())
                LM830cbRol.Items.Add(LM830perfil.LM830Nombre);
        }

        private void LM830MostrarCantidadUsuarios()
        {
            if (LM830rbActivos.Checked)
            {
                LM830lblCantidadUsers.Text = $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("lblCantidadUser")}: {LM830usuarioBLL.LM830ListarUsuariosActivos().Count}";
            }
            else
            {
                LM830lblCantidadUsers.Text = $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("lblCantidadUser")}: {LM830usuarioBLL.LM830ListarTodosUsuarios().Count}";
            }
        }

        private void LM830radioButton1_CheckedChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830rbActivos.Checked)
            {
                LM830lblTextoTabla.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblTextoTablaUserActivos");
                LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarUsuariosActivos() as List<LM830Usuario>);
                LM830MostrarCantidadUsuarios();
            }
            else
            {
                LM830lblTextoTabla.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblTextoTablaUserTodos");
                LM830MostrarCantidadUsuarios();
            }
        }

        private void LM830btnCerrar_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Navegacion.LM830VolverAlMenu(this);
        }

        private void LM830panel1_MouseUp(object LM830sender, MouseEventArgs LM830e) => LM830arrastrando = false;

        private void LM830panel1_MouseMove(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830arrastrando)
                this.Location = new Point(this.Location.X + (LM830e.X - LM830posX), this.Location.Y + (LM830e.Y - LM830posY));
        }

        private void LM830btnMaximizar_Click(object LM830sender, EventArgs LM830e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void LM830btnMinimizar_Click(object LM830sender, EventArgs LM830e) =>
            this.WindowState = FormWindowState.Minimized;

        private void LM830panModificarUsuario_EnabledChanged(object LM830sender, EventArgs LM830e)
        {
            Color LM830color = LM830panModificarUsuario.Enabled ? Color.White : Color.Gray;
            LM830txtDni.BackColor = LM830color;
            LM830txtNom.BackColor = LM830color;
            LM830txtApe.BackColor = LM830color;
            LM830txtEmail.BackColor = LM830color;
            LM830txtUsuario.BackColor = LM830color;
            LM830cbRol.BackColor = LM830color;
        }

        private void LM830btnAplicar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                switch (LM830userAction)
                {
                    case LM830UserAction.LM830Add:
                        if (LM830ValidarCamposVacios(LM830txtDni, LM830txtApe, LM830txtNom, LM830txtEmail, LM830txtUsuario) && LM830ValidarComboBox(LM830cbRol))
                        {
                            LM830usuarioBLL.LM830RegistrarUsuario(new LM830Usuario(
                                LM830txtDni.Text, LM830txtNom.Text, LM830txtApe.Text, LM830txtUsuario.Text,
                                LM830Encriptador.LM830GetHash256(LM830txtDni.Text + LM830txtNom.Text),
                                LM830txtEmail.Text, false, true, LM830cbRol.SelectedItem.ToString()));
                            LM830ReiniciarBotones();
                            LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarUsuariosActivos());
                            LM830MostrarCantidadUsuarios();
                        }
                        break;

                    case LM830UserAction.LM830Delete:
                        LM830usuarioBLL.LM830EliminarLogico((LM830dataGridView1.SelectedRows[0].DataBoundItem as LM830Usuario).LM830DNI);
                        LM830ReiniciarBotones();
                        LM830MostrarUsuarios(LM830dataGridView1, LM830rbActivos.Checked
                            ? LM830usuarioBLL.LM830ListarUsuariosActivos()
                            : LM830usuarioBLL.LM830ListarTodosUsuarios());
                        LM830MostrarCantidadUsuarios();

                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserElimi"), LM830LanguageManager.LM830Instance.LM830GetTraduction("Alerta"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                            case LM830UserAction.LM830Modify:
                                if (LM830ValidarCamposVacios(LM830txtNom, LM830txtApe, LM830txtDni, LM830txtUsuario, LM830txtEmail) && LM830ValidarComboBox(LM830cbRol) && LM830ValidarEntradaUsuario())
                                {
                                    string LM830dniOriginal = (LM830dataGridView1.SelectedRows[0].DataBoundItem as LM830Usuario).LM830DNI;
                                    string LM830rolNuevo = LM830cbRol.SelectedItem.ToString();

                                    LM830usuarioBLL.LM830Modificar(LM830dniOriginal, new LM830Usuario(
                                        LM830dniOriginal,
                                        LM830txtNom.Text, LM830txtApe.Text, LM830txtUsuario.Text,
                                        string.Empty, LM830txtEmail.Text, default, default, LM830rolNuevo));

                                    LM830Usuario LM830usuarioEnSesion = LM830SessionManager.LM830Instance.LM830UsuarioActual();
                                    if (LM830usuarioEnSesion.LM830DNI == LM830dniOriginal)
                                    {
                                        var LM830perfiles = LM830perfilBLL.LM830ObtenerPerfiles();
                                        var LM830perfilNuevo = LM830perfiles.FirstOrDefault(LM830p => LM830p.LM830Nombre == LM830rolNuevo);
                                        LM830usuarioEnSesion.LM830Permisos.Clear();
                                        if (LM830perfilNuevo != null)
                                            LM830usuarioEnSesion.LM830Permisos.Add(LM830perfilNuevo);
                                    }

                                    LM830ReiniciarBotones();
                                    MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserModif"),
                                        LM830LanguageManager.LM830Instance.LM830GetTraduction("Alerta"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarUsuariosActivos());

                                    if (LM830usuarioEnSesion.LM830DNI == LM830dniOriginal && !LM830usuarioEnSesion.LM830TienePermiso("Ver Usuarios"))
                                    {
                                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserMsj2"),
                                            LM830LanguageManager.LM830Instance.LM830GetTraduction("UserMsj3"),
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        LM830btnCerrar_Click(LM830sender, LM830e);
                                        return;
                                    }
                                    LM830ValidarPermisos();
                                }
                                break;

                            case LM830UserAction.LM830UnBlock:
                        LM830ReiniciarBotones();
                        LM830usuarioBLL.LM830DesbloquearUsuario(LM830dataGridView1.SelectedRows[0].DataBoundItem as LM830Usuario);
                        LM830MostrarUsuarios(LM830dataGridView1, LM830rbActivos.Checked
                            ? LM830usuarioBLL.LM830ListarUsuariosActivos()
                            : LM830usuarioBLL.LM830ListarTodosUsuarios());
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserDesbloqueado"), LM830LanguageManager.LM830Instance.LM830GetTraduction("Alerta"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case LM830UserAction.LM830Activate:
                        LM830usuarioBLL.LM830EliminarLogico((LM830dataGridView1.SelectedRows[0].DataBoundItem as LM830Usuario).LM830DNI);
                        LM830ReiniciarBotones();
                        if (LM830rbActivos.Checked)
                        {
                            LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarUsuariosActivos());
                        }
                        else
                        {
                            LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarTodosUsuarios());
                        }
                        LM830MostrarUsuarios(LM830dataGridView1, LM830rbActivos.Checked
                            ? LM830usuarioBLL.LM830ListarUsuariosActivos()
                            : LM830usuarioBLL.LM830ListarTodosUsuarios());
                        MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserActi"), LM830LanguageManager.LM830Instance.LM830GetTraduction("Alerta"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;

                    case LM830UserAction.LM830Consult:
                        break;
                }
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message);
            }
        }

        public void LM830MostrarUsuarios(DataGridView LM830dgv, object LM830obj)
        {
            LM830dgv.DataSource = null;
            LM830dgv.DataSource = LM830obj;
        }

        private bool LM830ValidarCamposVacios(params Control[] LM830controles)
        {
            StringBuilder LM830mensaje = new StringBuilder();
            bool LM830hayVacios = false;
            Control LM830primerInvalido = null;

            foreach (Control LM830c in LM830controles)
            {
                string LM830nombreCampo = LM830c.Tag?.ToString() ?? LM830c.Name;
                if (LM830c is TextBox LM830txt && string.IsNullOrWhiteSpace(LM830txt.Text))
                {
                    LM830mensaje.AppendLine($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("ElCampo")} " + " " + LM830nombreCampo + " " + LM830LanguageManager.LM830Instance.LM830GetTraduction("EstaVacio"));
                    if (LM830primerInvalido == null) LM830primerInvalido = LM830txt;
                    LM830hayVacios = true;
                }
                else if (LM830c is ComboBox LM830cb && LM830cb.SelectedIndex == -1)
                {
                    LM830mensaje.AppendLine($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("ElCampo")}" + " " + LM830nombreCampo + " " + LM830LanguageManager.LM830Instance.LM830GetTraduction("NoFueSelecc"));
                    if (LM830primerInvalido == null) LM830primerInvalido = LM830cb;
                    LM830hayVacios = true;
                }
            }

            if (LM830hayVacios)
            {
                MessageBox.Show(LM830mensaje.ToString(), LM830LanguageManager.LM830Instance.LM830GetTraduction("FaltaCompl"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830primerInvalido?.Focus();
            }
            return !LM830hayVacios;
        }
        private bool LM830ValidarComboBox(ComboBox LM830cb)
        {
            if (LM830cb.SelectedIndex == -1)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserMsj1"), LM830LanguageManager.LM830Instance.LM830GetTraduction("FaltaCompl"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830cb.Focus();
                return false;
            }
            return true;
        }

        private bool LM830ValidarEntradaUsuario()
        {
            StringBuilder LM830errores = new StringBuilder();

            if (!Regex.IsMatch(LM830txtNom.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$"))
                LM830errores.AppendLine(LM830LanguageManager.LM830Instance.LM830GetTraduction("CampoNombre"));

            if (!Regex.IsMatch(LM830txtApe.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$"))
                LM830errores.AppendLine(LM830LanguageManager.LM830Instance.LM830GetTraduction("CampoApell"));

            if (!Regex.IsMatch(LM830txtDni.Text.Trim(), @"^\d{8}$"))
                LM830errores.AppendLine(LM830LanguageManager.LM830Instance.LM830GetTraduction("CampoDni"));

            if (!(LM830userAction == LM830UserAction.LM830Add))
            {
                if (string.IsNullOrWhiteSpace(LM830txtUsuario.Text) || LM830txtUsuario.Text.Length < 4)
                    LM830errores.AppendLine(LM830LanguageManager.LM830Instance.LM830GetTraduction("ElNombreUser"));
            }

            if (!Regex.IsMatch(LM830txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                LM830errores.AppendLine(LM830LanguageManager.LM830Instance.LM830GetTraduction("ElCorreoElec"));

            if (LM830errores.Length > 0)
            {
                MessageBox.Show(LM830errores.ToString(), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorEntradaDeDatos"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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

        private void LM830btnCancelar_Click(object LM830sender, EventArgs LM830e) => LM830ReiniciarBotones();

        private void LM830SetModoEdicion(bool LM830enEdicion)
        {
            LM830btnCrear.Enabled = !LM830enEdicion;
            LM830btnDesbloquear.Enabled = !LM830enEdicion;
            LM830btnModificar.Enabled = !LM830enEdicion;
            LM830btnActDes.Enabled = !LM830enEdicion;

            LM830btnCrear.BackColor = !LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;
            LM830btnDesbloquear.BackColor = !LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;
            LM830btnModificar.BackColor = !LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;
            LM830btnActDes.BackColor = !LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;

            LM830btnAplicar.Enabled = LM830enEdicion;
            LM830btnCancelar.Enabled = LM830enEdicion;
            LM830btnAplicar.BackColor = LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;
            LM830btnCancelar.BackColor = LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;
            LM830panel10.BackColor = LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;
            LM830panel11.BackColor = LM830enEdicion ? Color.FromArgb(46, 125, 50) : Color.DarkGray;

            LM830pnFiltrado.Enabled = !LM830enEdicion;
            LM830panel3.Enabled = !LM830enEdicion;
            LM830panModificarUsuario.Enabled = LM830enEdicion;
        }
        private void LM830ReiniciarBotones()
        {
            LM830txtNom.Clear();
            LM830txtApe.Clear();
            LM830txtDni.Clear();
            LM830txtEmail.Clear();
            LM830txtUsuario.Clear();
            LM830cbRol.SelectedIndex = -1;
            LM830txtDni.ReadOnly = false;

            LM830SetModoEdicion(false);

            LM830txtBoxModo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("txtBoxModoConsulta");
            LM830userAction = LM830UserAction.LM830Consult;

            if (LM830SessionManager.LM830Instance.LM830Logueado())
                LM830ValidarPermisos();
        }

        private void LM830radioButton2_CheckedChanged(object LM830sender, EventArgs LM830e) =>
            LM830MostrarUsuarios(LM830dataGridView1, LM830usuarioBLL.LM830ListarTodosUsuarios());

        private void LM830dataGridView1_SelectionChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830userAction == LM830UserAction.LM830Delete || LM830userAction == LM830UserAction.LM830Modify || LM830userAction == LM830UserAction.LM830UnBlock)
            {
                if (LM830dataGridView1.SelectedRows.Count > 0 && LM830dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    LM830Usuario LM830user = LM830usuarioBLL.LM830BuscarUsuarioPorDNI(
                        LM830dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    if (LM830user == null) return;

                    LM830txtDni.Text = LM830user.LM830DNI;
                    LM830txtDni.ReadOnly = (LM830userAction == LM830UserAction.LM830Modify);
                    LM830txtNom.Text = LM830user.LM830Nombre;
                    LM830txtApe.Text = LM830user.LM830Apellido;
                    LM830txtUsuario.Text = LM830user.LM830Username;
                    LM830txtEmail.Text = LM830user.LM830Email;
                    LM830cbRol.SelectedItem = LM830user.LM830Rol;
                }
            }
        }

        private void LM830dataGridView1_CellFormatting(object LM830sender, DataGridViewCellFormattingEventArgs LM830e)
        {
            if (LM830e.RowIndex >= 0 && LM830dataGridView1.Rows[LM830e.RowIndex].DataBoundItem is LM830Usuario LM830usuario)
                LM830e.CellStyle.ForeColor = LM830usuario.LM830Bloqueado ? Color.Red : Color.Black;
        }

        private void LM830btnCrear_Click(object LM830sender, EventArgs LM830e)
        {
            LM830userAction = LM830UserAction.LM830Add;
            LM830CargarPerfiles();
            LM830txtBoxModo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("txtBoxModoAnadir");
            LM830SetModoEdicion(true);
        }

        private void LM830btnDesbloquear_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dataGridView1.SelectedRows.Count > 0)
            {
                LM830userAction = LM830UserAction.LM830UnBlock;
                LM830txtBoxModo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("txtBoxModoDesbloquear");
                LM830SetModoEdicion(true);
                LM830panModificarUsuario.Enabled = false;
            }
        }

        private void LM830btnModificar_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dataGridView1.SelectedRows.Count == 0 || LM830dataGridView1.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("UserMsj4"));
                return;
            }

            LM830userAction = LM830UserAction.LM830Modify;
            LM830txtBoxModo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("txtBoxModoModificar");
            LM830CargarPerfiles();
            LM830SetModoEdicion(true);

            LM830Usuario LM830user = LM830usuarioBLL.LM830BuscarUsuarioPorDNI(
                LM830dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            if (LM830user == null) return;

            LM830txtDni.Text = LM830user.LM830DNI;
            LM830txtNom.Text = LM830user.LM830Nombre;
            LM830txtApe.Text = LM830user.LM830Apellido;
            LM830txtUsuario.Text = LM830user.LM830Username;
            LM830txtEmail.Text = LM830user.LM830Email;
            LM830cbRol.SelectedItem = LM830user.LM830Rol;
            LM830txtDni.ReadOnly = true;
        }

        private void LM830btnActDes_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dataGridView1.SelectedRows.Count > 0 && LM830dataGridView1.SelectedRows[0].Cells[0].Value != null)
            {
                LM830Usuario LM830us = LM830usuarioBLL.LM830BuscarUsuarioPorDNI(
                    LM830dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                if (LM830us == null) return;

                if (!LM830us.LM830Activo)
                {
                    LM830userAction = LM830UserAction.LM830Activate;
                    LM830txtBoxModo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("txtBoxModoActivar");
                }
                else
                {
                    LM830userAction = LM830UserAction.LM830Delete;
                    LM830txtBoxModo.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("txtBoxModoEliminar");
                }
                LM830SetModoEdicion(true);
                LM830panModificarUsuario.Enabled = false;
            }
        }

        private void LM830Usuarios_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830ValidarPermisos();
        }

        private void LM830ValidarPermisos()
        {
            LM830Usuario LM830usuarioActual = LM830SessionManager.LM830Instance.LM830UsuarioActual();

            LM830btnCrear.Enabled = LM830usuarioActual.LM830TienePermiso("Crear Usuario");
            LM830btnModificar.Enabled = LM830usuarioActual.LM830TienePermiso("Modificar Usuario");
            LM830btnActDes.Enabled = LM830usuarioActual.LM830TienePermiso("Activar Desactivar Usuario");
            LM830btnDesbloquear.Enabled = LM830usuarioActual.LM830TienePermiso("Desbloquear Usuario");
        }

        private void LM830ConfigurarGrillaSeleccionFila(DataGridView LM830dgv)
        {
            LM830dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LM830dgv.MultiSelect = false;
            LM830dgv.ReadOnly = true;
            LM830dgv.AllowUserToAddRows = false;
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830lblTextoTabla.Text = LM830lenguaje.LM830GetTraduction("lblTextoTabla");
            LM830txtDni.Text = LM830lenguaje.LM830GetTraduction("DNI");
            LM830lblApe.Text = LM830lenguaje.LM830GetTraduction("lblApe");
            LM830lblNombre.Text = LM830lenguaje.LM830GetTraduction("lblNombre");
            LM830lblEmail.Text = LM830lenguaje.LM830GetTraduction("lblEmail");
            LM830lblRol.Text = LM830lenguaje.LM830GetTraduction("lblRol");
            LM830lblUsuarioFU.Text = LM830lenguaje.LM830GetTraduction("lblUsuarioFU");
            LM830lblMsj.Text = LM830lenguaje.LM830GetTraduction("lblMsj");
            LM830lblOpciones.Text = LM830lenguaje.LM830GetTraduction("lblOpciones");

            LM830btnCrear.Text = LM830lenguaje.LM830GetTraduction("btnCrear");
            LM830btnDesbloquear.Text = LM830lenguaje.LM830GetTraduction("btnDesbloquear");
            LM830btnModificar.Text = LM830lenguaje.LM830GetTraduction("btnModificar");
            LM830btnActDes.Text = LM830lenguaje.LM830GetTraduction("btnActDes");
            LM830btnAplicar.Text = LM830lenguaje.LM830GetTraduction("btnAplicar");
            LM830btnCancelar.Text = LM830lenguaje.LM830GetTraduction("btnCancelar");
            LM830btnSalir.Text = LM830lenguaje.LM830GetTraduction("btnSalir");

            LM830rbTodos.Text = LM830lenguaje.LM830GetTraduction("rbTodos");
            LM830rbActivos.Text = LM830lenguaje.LM830GetTraduction("rbActivos");
        }
    }
}

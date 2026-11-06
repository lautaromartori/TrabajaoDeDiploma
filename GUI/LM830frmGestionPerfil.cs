using LM830BLL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830frmGestionPerfiles : Form, LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        private readonly LM830PerfilBLL LM830_bll;
        private readonly LM830Menu LM830_menuPadre;

        private List<LM830PermisoSimple> LM830_permisos = new List<LM830PermisoSimple>();
        private List<LM830Familia> LM830_familias = new List<LM830Familia>();
        private List<LM830Familia> LM830_perfiles = new List<LM830Familia>();

        private LM830Familia LM830_familiaSeleccionada = null;
        private LM830Familia LM830_perfilSeleccionado = null;

        public LM830frmGestionPerfiles()
        {
            InitializeComponent();
            LM830_bll = new LM830PerfilBLL();

            LM830ValidarPermisos();

            LM830RbFamilias.CheckedChanged += LM830RbFamilias_CheckedChanged_1;
            LM830RbPerfiles.CheckedChanged += LM830RbPerfiles_CheckedChanged;

            if (!this.Controls.Contains(LM830pnlFamilias)) this.Controls.Add(LM830pnlFamilias);
            if (!this.Controls.Contains(LM830pnlPerfiles)) this.Controls.Add(LM830pnlPerfiles);

            this.SizeChanged += LM830FrmGestionPerfiles_SizeChanged;

            LM830RbFamilias.Checked = true;
            LM830SincronizarVisibilidadPaneles();
            LM830CargarDatosFormulario();
        }

        private void LM830ValidarPermisos()
        {
            LM830Usuario LM830usuarioActual = LM830SessionManager.LM830Instance.LM830UsuarioActual();

            if (!LM830usuarioActual.LM830TienePermiso("Ver Perfiles"))
            {
                MessageBox.Show("No tiene permisos para acceder a Gestión de Perfiles.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                if (Application.OpenForms["LM830Menu"] != null)
                    Application.OpenForms["LM830Menu"].Show();
                else
                {
                    LM830Menu LM830menu = new LM830Menu();
                    LM830menu.Show();
                }

                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            LM830ActualizarEstadoBotonesSegunPermisos();
        }

        private void LM830ActualizarEstadoBotonesSegunPermisos()
        {
            LM830Usuario LM830usuarioActual = LM830SessionManager.LM830Instance.LM830UsuarioActual();

            LM830btnCrearPermiso.Enabled = LM830usuarioActual.LM830TienePermiso("Crear Permiso");
            LM830btnEliminarPermiso.Enabled = LM830usuarioActual.LM830TienePermiso("Eliminar Permiso");

            LM830btnCrearFamilia.Enabled = LM830usuarioActual.LM830TienePermiso("Crear Familia");
            LM830btnEliminarFamilia.Enabled = LM830usuarioActual.LM830TienePermiso("Eliminar Familia");
            LM830btnAsignarPermisos.Enabled = LM830usuarioActual.LM830TienePermiso("Asignar Permiso Familia");
            LM830btnQuitarPermisos.Enabled = LM830usuarioActual.LM830TienePermiso("Quitar Permiso Familia");
            LM830btnAsignarSubfamilia.Enabled = LM830usuarioActual.LM830TienePermiso("Asignar Subfamilia");
            LM830btnQuitarSubfamilia.Enabled = LM830usuarioActual.LM830TienePermiso("Quitar Subfamilia");

            LM830btnCrearPerfil.Enabled = LM830usuarioActual.LM830TienePermiso("Crear Perfil");
            LM830btnEliminarPerfil.Enabled = LM830usuarioActual.LM830TienePermiso("Eliminar Perfil");
            LM830btnAsignarFamiliaPerfil.Enabled = LM830usuarioActual.LM830TienePermiso("Asignar Familia Perfil");
            LM830btnQuitarFamiliaPerfil.Enabled = LM830usuarioActual.LM830TienePermiso("Quitar Familia Perfil");
            LM830BtnAsignarPermisoPerfil.Enabled = LM830usuarioActual.LM830TienePermiso("Asignar Permiso Perfil");
            LM830BtnQuitarPermisoPerfil.Enabled = LM830usuarioActual.LM830TienePermiso("Quitar Permiso Perfil");
        }

        private void LM830CentrarPanelesContenedores()
        {
            int LM830contenedorAncho = this.ClientSize.Width;

            Panel LM830panelActivo = null;
            if (LM830RbPermisos.Checked) LM830panelActivo = LM830pnlPermisos;
            else if (LM830RbFamilias.Checked) LM830panelActivo = LM830pnlFamilias;
            else if (LM830RbPerfiles.Checked) LM830panelActivo = LM830pnlPerfiles;

            if (LM830panelActivo != null)
            {
                int LM830xDelCentro = LM830panel4.Right;
                int LM830yAlineada = LM830panel4.Top - 10;

                LM830panelActivo.Location = new Point(LM830xDelCentro, LM830yAlineada);
            }
        }

        private void LM830FrmGestionPerfiles_SizeChanged(object LM830sender, EventArgs LM830e)
        {
            LM830CentrarPanelesContenedores();
        }

        private void LM830ActualizarTreeViewConsulta(LM830Familia LM830componenteRaiz)
        {
            LM830treeView1.BeginUpdate();
            LM830treeView1.Nodes.Clear();

            if (LM830componenteRaiz != null)
            {
                LM830_bll.LM830ArmarArbolEstructural(LM830componenteRaiz, LM830treeView1.Nodes);
                LM830treeView1.ExpandAll();
            }

            LM830treeView1.EndUpdate();
        }

        private void LM830CargarDatosFormulario()
        {
            try
            {
                string LM830nombreFamAnterior = LM830_familiaSeleccionada?.LM830Nombre;
                string LM830nombrePerfAnterior = LM830_perfilSeleccionado?.LM830Nombre;

                LM830_permisos = LM830_bll.LM830ObtenerPermisos();
                LM830_familias = LM830_bll.LM830ObtenerFamilias();
                LM830_perfiles = LM830_bll.LM830ObtenerPerfiles();

                LM830_familiaSeleccionada = !string.IsNullOrEmpty(LM830nombreFamAnterior)
                    ? LM830_familias.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombreFamAnterior)
                    : LM830_familias.FirstOrDefault();

                LM830_perfilSeleccionado = !string.IsNullOrEmpty(LM830nombrePerfAnterior)
                    ? LM830_perfiles.FirstOrDefault(LM830p => LM830p.LM830Nombre == LM830nombrePerfAnterior)
                    : LM830_perfiles.FirstOrDefault();

                LM830SincronizarVisibilidadPaneles();
                LM830RefrescarSeguridad();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorSincrop") + LM830ex.Message,
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorOperacionalP"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LM830SincronizarVisibilidadPaneles()
        {
            LM830pnlPermisos.Visible = LM830RbPermisos.Checked;
            LM830pnlFamilias.Visible = LM830RbFamilias.Checked;
            LM830pnlPerfiles.Visible = LM830RbPerfiles.Checked;

            LM830CentrarPanelesContenedores();

            if (LM830RbPermisos.Checked)
            {
                LM830treeView1.Visible = false;
                LM830treeView1.Nodes.Clear();
                LM830CargarComponentesPermisos();
            }
            else if (LM830RbFamilias.Checked)
            {
                LM830treeView1.Visible = true;
                LM830CargarComponentesFamilias();
            }
            else if (LM830RbPerfiles.Checked)
            {
                LM830treeView1.Visible = true;
                LM830CargarComponentesPerfiles();
            }
        }

        private void LM830CargarComponentesPermisos()
        {
            LM830dgvPermisos.DataSource = null;
            LM830dgvPermisos.DataSource = LM830_permisos.Select(LM830p => new
            {
                Nombre = LM830p.LM830Nombre,
                Tipo = "Permiso Simple"
            }).ToList();
        }

        private void LM830BtnCrearPermiso_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830nombre = LM830txtNombrePermiso.Text.Trim();

            if (string.IsNullOrEmpty(LM830nombre))
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("IngreseUnNombreParaPermisoP"), LM830LanguageManager.LM830Instance.LM830GetTraduction("CampoRequeridoP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtNombrePermiso.Focus();
                return;
            }

            try
            {
                LM830_bll.LM830CrearPermiso(LM830nombre);
                LM830txtNombrePermiso.Clear();
                LM830CargarDatosFormulario();
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Permisomsjp")} '{LM830nombre}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("CreadoExitoP")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex) { MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LM830BtnEliminarPermiso_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dgvPermisos.CurrentRow == null) return;
            string LM830nombre = LM830dgvPermisos.CurrentRow.Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿{LM830LanguageManager.LM830Instance.LM830GetTraduction("EliminarP")} '{LM830nombre}'?", LM830LanguageManager.LM830Instance.LM830GetTraduction("Confirmarp"), MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                LM830_bll.LM830EliminarPermiso(LM830nombre);
                LM830CargarDatosFormulario();
            }
            catch (Exception LM830ex) { MessageBox.Show(LM830ex.Message); }
        }

        private void LM830CargarComponentesFamilias()
        {
            LM830lstFamilias.SelectedIndexChanged -= LM830LstFamilias_SelectedIndexChanged;
            LM830lstFamilias.DataSource = null;
            LM830lstFamilias.DataSource = LM830_familias;
            LM830lstFamilias.DisplayMember = "LM830Nombre";

            if (LM830_familiaSeleccionada != null)
            {
                LM830lstFamilias.SelectedItem = LM830_familias.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830_familiaSeleccionada.LM830Nombre);
            }

            LM830lstFamilias.SelectedIndexChanged += LM830LstFamilias_SelectedIndexChanged;
            LM830VisualizarDetallesFamilia();
        }

        private void LM830VisualizarDetallesFamilia()
        {
            if (LM830_familiaSeleccionada == null)
            {
                LM830clbPermisosDisp.DataSource = null;
                LM830clbPermisosAsig.DataSource = null;
                LM830clbSubfamiliasDisp.DataSource = null;
                LM830clbSubfamiliasAsig.DataSource = null;
                LM830treeView1.Nodes.Clear();
                return;
            }

            LM830clbPermisosDisp.DataSource = LM830_bll.LM830ObtenerPermisosDisponibles(LM830_familiaSeleccionada);
            LM830clbPermisosDisp.DisplayMember = "LM830Nombre";

            LM830clbPermisosAsig.DataSource = LM830_familiaSeleccionada.LM830ListaHijos.OfType<LM830PermisoSimple>().ToList();
            LM830clbPermisosAsig.DisplayMember = "LM830Nombre";

            LM830clbSubfamiliasDisp.DataSource = LM830_bll.LM830ObtenerFamiliasDisponibles(LM830_familiaSeleccionada.LM830Nombre)
                .Where(LM830f => !LM830_familiaSeleccionada.LM830ListaHijos.Any(LM830x => LM830x.LM830Nombre == LM830f.LM830Nombre)).ToList();
            LM830clbSubfamiliasDisp.DisplayMember = "LM830Nombre";

            LM830clbSubfamiliasAsig.DataSource = LM830_familiaSeleccionada.LM830ListaHijos.OfType<LM830Familia>().ToList();
            LM830clbSubfamiliasAsig.DisplayMember = "LM830Nombre";

            LM830ActualizarTreeViewConsulta(LM830_familiaSeleccionada);
        }

        private void LM830LstFamilias_SelectedIndexChanged(object LM830sender, EventArgs LM830e)
        {
            LM830_familiaSeleccionada = LM830lstFamilias.SelectedItem as LM830Familia;
            LM830VisualizarDetallesFamilia();
        }

        private void LM830BtnCrearFamilia_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830nombre = LM830txtNombreFamilia.Text.Trim();

            if (string.IsNullOrEmpty(LM830nombre))
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("ingreseNombreFamiliaP"), LM830LanguageManager.LM830Instance.LM830GetTraduction("CampoRequeridoP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtNombreFamilia.Focus();
                return;
            }

            try
            {
                LM830_bll.LM830CrearFamilia(LM830nombre);
                LM830txtNombreFamilia.Clear();
                LM830CargarDatosFormulario();
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Familiap")} '{LM830nombre}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("CreadoExitoP")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex) { MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LM830BtnAsignarPermisos_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_familiaSeleccionada == null) return;
            var LM830seleccionados = LM830clbPermisosDisp.CheckedItems.Cast<LM830PermisoSimple>().Select(LM830p => LM830p.LM830Nombre).ToList();
            if (!LM830seleccionados.Any()) return;

            foreach (var LM830permiso in LM830seleccionados)
            {
                var LM830res = LM830_bll.LM830AsignarComponentesHijos(LM830_familiaSeleccionada.LM830Nombre, new List<string> { LM830permiso }, true);

                if (LM830res.LM830Estado == LM830EstadoAsignacion.LM830ConflictoPermisos)
                {
                    string LM830detalleError = LM830res.LM830OrigenConflicto[LM830permiso];

                    if (LM830detalleError != null && LM830detalleError.Contains("Redundancia detectada"))
                    {
                        LM830MostrarModalResolucionHeredada(LM830_familiaSeleccionada.LM830Nombre, LM830permiso, LM830permiso, (LM830estrategia) =>
                        {
                            if (LM830estrategia == "RESOLVER")
                            {
                                LM830_bll.LM830EliminarPermisoRedundanteDeNodoContenedor(LM830_familiaSeleccionada.LM830Nombre, new List<string> { LM830permiso });
                                var LM830reintento = LM830_bll.LM830AsignarComponentesHijos(LM830_familiaSeleccionada.LM830Nombre, new List<string> { LM830permiso }, true);
                                if (LM830reintento.LM830Estado == LM830EstadoAsignacion.LM830Ok)
                                {
                                    MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Permisomsjp")} '{LM830permiso}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("UcExitoEnLaRaizp")} '{LM830_familiaSeleccionada.LM830Nombre}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("RemovidoDeSubfami")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
                                }
                            }
                            LM830CargarDatosFormulario();
                        });
                        return;
                    }

                    if (LM830detalleError != null && LM830detalleError.StartsWith("CONFLICTO_HORIZONTAL_DETALLADO|"))
                    {
                        var LM830partes = LM830detalleError.Split('|');
                        string LM830perm = LM830partes[1];
                        string LM830nodoDest = LM830partes[2];
                        string LM830ancestro = LM830partes[3];
                        string LM830ramaColat = LM830partes[4];
                        string LM830contenedorDirecto = LM830partes[5];

                        LM830MostrarModalResolucionHorizontal(LM830ancestro, LM830ramaColat, LM830contenedorDirecto, LM830nodoDest, LM830perm, (LM830estrategia) =>
                        {
                            if (LM830estrategia == "RESOLVER")
                            {
                                LM830_bll.LM830EliminarPermisoDeContenedorEspecifico(LM830contenedorDirecto, LM830perm);
                                var LM830reintento = LM830_bll.LM830AsignarComponentesHijos(LM830nodoDest, new List<string> { LM830perm }, true);
                                if (LM830reintento.LM830Estado == LM830EstadoAsignacion.LM830Ok)
                                {
                                    MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Permisomsjp")} '{LM830perm}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("AsConExitoaP")} '{LM830nodoDest}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("TrasResolverRedun")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("TrasResolverRedun"));
                                }
                            }
                            LM830CargarDatosFormulario();
                        });
                        return;
                    }

                    MessageBox.Show(LM830detalleError, LM830LanguageManager.LM830Instance.LM830GetTraduction("validacionesDePermisosmsj"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("PermisosAsignadosCorrectmsjP"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnQuitarPermisos_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_familiaSeleccionada == null) return;
            var LM830seleccionados = LM830clbPermisosAsig.CheckedItems.Cast<LM830PermisoSimple>().Select(LM830p => LM830p.LM830Nombre).ToList();
            if (!LM830seleccionados.Any()) return;

            LM830_bll.LM830QuitarHijos(LM830_familiaSeleccionada.LM830Nombre, LM830seleccionados, true);
            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("PermisosRemovep"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnAsignarSubfamilia_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_familiaSeleccionada == null) return;
            var LM830seleccionadas = LM830clbSubfamiliasDisp.CheckedItems.Cast<LM830Familia>().Select(LM830f => LM830f.LM830Nombre).ToList();
            if (!LM830seleccionadas.Any()) return;

            foreach (var LM830subfamiliaHijo in LM830seleccionadas)
            {
                var LM830res = LM830_bll.LM830AsignarComponentesHijos(LM830_familiaSeleccionada.LM830Nombre, new List<string> { LM830subfamiliaHijo }, false);

                if (LM830res.LM830Estado == LM830EstadoAsignacion.LM830ConflictoPermisos)
                {
                    string LM830claveConflicto = LM830res.LM830OrigenConflicto.Values.FirstOrDefault();

                    if (LM830claveConflicto != null && LM830claveConflicto.StartsWith("CONFLICTO_REDUNDANCIA_HEREDADA|"))
                    {
                        var LM830partes = LM830claveConflicto.Split('|');
                        var LM830permisosConflictivos = LM830partes[1].Split(',').ToList();
                        string LM830subFamiliaConflictiva = LM830partes[2];
                        string LM830nodoDondeYaExiste = LM830partes[3];

                        LM830MostrarModalResolucionHeredada(LM830nodoDondeYaExiste, LM830subFamiliaConflictiva, LM830partes[1], (LM830estrategia) =>
                        {
                            if (LM830estrategia == "RESOLVER")
                            {
                                LM830_bll.LM830EliminarPermisoRedundanteDeNodoContenedor(LM830_familiaSeleccionada.LM830Nombre, LM830permisosConflictivos);
                                var LM830reintento = LM830_bll.LM830AsignarComponentesHijos(LM830_familiaSeleccionada.LM830Nombre, new List<string> { LM830subfamiliaHijo }, false);
                                if (LM830reintento.LM830Estado == LM830EstadoAsignacion.LM830Ok)
                                {
                                    MessageBox.Show($"'{LM830subfamiliaHijo}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("AsigCorrecmsjP")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
                                }
                            }
                            LM830CargarDatosFormulario();
                        });
                        return;
                    }

                    MessageBox.Show(LM830claveConflicto, LM830LanguageManager.LM830Instance.LM830GetTraduction("Restriccionp"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("SubFamiliaAsigCorrectp"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnQuitarSubfamilia_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_familiaSeleccionada == null) return;
            var LM830seleccionadas = LM830clbSubfamiliasAsig.CheckedItems.Cast<LM830Familia>().Select(LM830f => LM830f.LM830Nombre).ToList();
            if (!LM830seleccionadas.Any()) return;

            LM830_bll.LM830QuitarHijos(LM830_familiaSeleccionada.LM830Nombre, LM830seleccionadas, false);
            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("SubFamiliaRemovep"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnEliminarFamilia_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_familiaSeleccionada == null) return;
            if (MessageBox.Show($"¿{LM830LanguageManager.LM830Instance.LM830GetTraduction("EstasSeguroEliFami")} '{LM830_familiaSeleccionada.LM830Nombre}'? {LM830LanguageManager.LM830Instance.LM830GetTraduction("EstasAcciQuiToRelap")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ConfirmarElimip"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                LM830_bll.LM830EliminarFamiliaOPerfil(LM830_familiaSeleccionada.LM830Nombre);

                string LM830nombreEliminado = LM830_familiaSeleccionada.LM830Nombre;
                LM830_familiaSeleccionada = null;

                LM830CargarDatosFormulario();
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("LaFamiliamsjP")} '{LM830nombreEliminado}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("SeEliminodelSistema")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("RestrIntegraJerarmsjP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LM830CargarComponentesPerfiles()
        {
            LM830lstPerfiles.SelectedIndexChanged -= LM830LstPerfiles_SelectedIndexChanged;
            LM830lstPerfiles.DataSource = null;
            LM830lstPerfiles.DataSource = LM830_perfiles;
            LM830lstPerfiles.DisplayMember = "LM830Nombre";

            if (LM830_perfilSeleccionado != null)
            {
                LM830lstPerfiles.SelectedItem = LM830_perfiles.FirstOrDefault(LM830p => LM830p.LM830Nombre == LM830_perfilSeleccionado.LM830Nombre);
            }

            LM830lstPerfiles.SelectedIndexChanged += LM830LstPerfiles_SelectedIndexChanged;
            LM830VisualizarDetallesPerfil();
        }

        private void LM830VisualizarDetallesPerfil()
        {
            if (LM830_perfilSeleccionado == null)
            {
                LM830clbFamiliasDispPerfil.DataSource = null;
                LM830clbFamiliasAsigPerfil.DataSource = null;
                LM830clbPermisosDispPerfil.DataSource = null;
                LM830clbPermisosAsigPerfil.DataSource = null;
                LM830treeView1.Nodes.Clear();
                return;
            }

            LM830clbFamiliasDispPerfil.DataSource = LM830_bll.LM830ObtenerFamiliasDisponibles(LM830_perfilSeleccionado.LM830Nombre)
                .Where(LM830f => !LM830_perfilSeleccionado.LM830ListaHijos.Any(LM830x => LM830x.LM830Nombre == LM830f.LM830Nombre)).ToList();
            LM830clbFamiliasDispPerfil.DisplayMember = "LM830Nombre";

            LM830clbFamiliasAsigPerfil.DataSource = LM830_perfilSeleccionado.LM830ListaHijos.OfType<LM830Familia>().ToList();
            LM830clbFamiliasAsigPerfil.DisplayMember = "LM830Nombre";

            LM830clbPermisosDispPerfil.DataSource = LM830_bll.LM830ObtenerPermisosDisponibles(LM830_perfilSeleccionado);
            LM830clbPermisosDispPerfil.DisplayMember = "LM830Nombre";

            LM830clbPermisosAsigPerfil.DataSource = LM830_perfilSeleccionado.LM830ListaHijos.OfType<LM830PermisoSimple>().ToList();
            LM830clbPermisosAsigPerfil.DisplayMember = "LM830Nombre";

            LM830ActualizarTreeViewConsulta(LM830_perfilSeleccionado);
        }

        private void LM830LstPerfiles_SelectedIndexChanged(object LM830sender, EventArgs LM830e)
        {
            LM830_perfilSeleccionado = LM830lstPerfiles.SelectedItem as LM830Familia;
            LM830VisualizarDetallesPerfil();
        }

        private void LM830BtnCrearPerfil_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830nombre = LM830txtNombrePerfil.Text.Trim();

            if (string.IsNullOrEmpty(LM830nombre))
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("ingUnNombrePerfilP"), LM830LanguageManager.LM830Instance.LM830GetTraduction("CampoRequeridoP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtNombrePerfil.Focus();
                return;
            }

            try
            {
                LM830_bll.LM830CrearPerfil(LM830nombre);
                LM830txtNombrePerfil.Clear();
                LM830CargarDatosFormulario();
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilmsjP")} '{LM830nombre}'{LM830LanguageManager.LM830Instance.LM830GetTraduction("CreadoExitoP")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex) { MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LM830BtnAsignarFamiliaPerfil_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_perfilSeleccionado == null) return;
            var LM830seleccionados = LM830clbFamiliasDispPerfil.CheckedItems.Cast<LM830Familia>().Select(LM830f => LM830f.LM830Nombre).ToList();
            if (!LM830seleccionados.Any()) return;

            foreach (var LM830familia in LM830seleccionados)
            {
                var LM830res = LM830_bll.LM830AsignarComponentesHijos(LM830_perfilSeleccionado.LM830Nombre, new List<string> { LM830familia }, false);

                if (LM830res.LM830Estado == LM830EstadoAsignacion.LM830ConflictoPermisos)
                {
                    string LM830detalleError = LM830res.LM830OrigenConflicto[LM830familia];

                    if (LM830detalleError != null && LM830detalleError.StartsWith("CONFLICTO_REDUNDANCIA_HEREDADA|"))
                    {
                        var LM830partes = LM830detalleError.Split('|');
                        var LM830permisosConflictivos = LM830partes[1].Split(',').ToList();
                        string LM830subFamiliaConflictiva = LM830partes[2];
                        string LM830nodoDondeYaExiste = LM830partes[3];

                        LM830MostrarModalResolucionHeredada(LM830nodoDondeYaExiste, LM830subFamiliaConflictiva, LM830partes[1], (LM830estrategia) =>
                        {
                            if (LM830estrategia == "RESOLVER")
                            {
                                LM830_bll.LM830EliminarPermisoRedundanteDeNodoContenedor(LM830_perfilSeleccionado.LM830Nombre, LM830permisosConflictivos);
                                var LM830reintento = LM830_bll.LM830AsignarComponentesHijos(LM830_perfilSeleccionado.LM830Nombre, new List<string> { LM830subFamiliaConflictiva }, false);
                                if (LM830reintento.LM830Estado == LM830EstadoAsignacion.LM830Ok)
                                {
                                    MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Familiap")} '{LM830subFamiliaConflictiva}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("integradaAlPerfilExitosamentep")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
                                }
                            }
                            LM830CargarDatosFormulario();
                        });
                        return;
                    }

                    MessageBox.Show(LM830detalleError, LM830LanguageManager.LM830Instance.LM830GetTraduction("ValiEstrucPerfP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("FamiAsigAPerfCorrecp"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnQuitarFamiliaPerfil_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_perfilSeleccionado == null) return;
            var LM830seleccionadas = LM830clbFamiliasAsigPerfil.CheckedItems.Cast<LM830Familia>().Select(LM830f => LM830f.LM830Nombre).ToList();
            if (!LM830seleccionadas.Any()) return;

            LM830_bll.LM830QuitarHijos(LM830_perfilSeleccionado.LM830Nombre, LM830seleccionadas, false);
            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("FamiRemovep"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnAsignarPermisoPerfil_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_perfilSeleccionado == null) return;
            var LM830seleccionados = LM830clbPermisosDispPerfil.CheckedItems.Cast<LM830PermisoSimple>().Select(LM830p => LM830p.LM830Nombre).ToList();
            if (!LM830seleccionados.Any()) return;

            foreach (var LM830permiso in LM830seleccionados)
            {
                var LM830res = LM830_bll.LM830AsignarComponentesHijos(LM830_perfilSeleccionado.LM830Nombre, new List<string> { LM830permiso }, true);

                if (LM830res.LM830Estado == LM830EstadoAsignacion.LM830ConflictoPermisos)
                {
                    string LM830detalleError = LM830res.LM830OrigenConflicto[LM830permiso];

                    if (LM830detalleError != null && LM830detalleError.Contains("Redundancia detectada"))
                    {
                        LM830MostrarModalResolucionHeredada(LM830_perfilSeleccionado.LM830Nombre, LM830permiso, LM830permiso, (LM830estrategia) =>
                        {
                            if (LM830estrategia == "RESOLVER")
                            {
                                LM830_bll.LM830EliminarPermisoRedundanteDeNodoContenedor(LM830_perfilSeleccionado.LM830Nombre, new List<string> { LM830permiso });
                                var LM830reintento = LM830_bll.LM830AsignarComponentesHijos(LM830_perfilSeleccionado.LM830Nombre, new List<string> { LM830permiso }, true);
                                if (LM830reintento.LM830Estado == LM830EstadoAsignacion.LM830Ok)
                                {
                                    MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Permisomsjp")} '{LM830permiso}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("UnifiConExitoRaizFamilia")} '{LM830_perfilSeleccionado.LM830Nombre}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("YRemoveDeSusFamilp")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
                                }
                            }
                            LM830CargarDatosFormulario();
                        });
                        return;
                    }

                    if (LM830detalleError != null && LM830detalleError.StartsWith("CONFLICTO_HORIZONTAL_DETALLADO|"))
                    {
                        var LM830partes = LM830detalleError.Split('|');
                        string LM830perm = LM830partes[1];
                        string LM830nodoDest = LM830partes[2];
                        string LM830ancestro = LM830partes[3];
                        string LM830ramaColat = LM830partes[4];
                        string LM830contenedorDirecto = LM830partes[5];

                        LM830MostrarModalResolucionHorizontal(LM830ancestro, LM830ramaColat, LM830contenedorDirecto, LM830nodoDest, LM830perm, (LM830estrategia) =>
                        {
                            if (LM830estrategia == "RESOLVER")
                            {
                                LM830_bll.LM830EliminarPermisoDeContenedorEspecifico(LM830contenedorDirecto, LM830perm);
                                var LM830reintento = LM830_bll.LM830AsignarComponentesHijos(LM830nodoDest, new List<string> { LM830perm }, true);
                                if (LM830reintento.LM830Estado == LM830EstadoAsignacion.LM830Ok)
                                {
                                    MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Permisomsjp")} '{LM830perm}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("UnificandoExtoPermisop")} '{LM830nodoDest}'.", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
                                }
                            }
                            LM830CargarDatosFormulario();
                        });
                        return;
                    }

                    MessageBox.Show(LM830detalleError, LM830LanguageManager.LM830Instance.LM830GetTraduction("ValiPerPerfp"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("PermiAsigPerfCorrectP"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnQuitarPermisoPerfil_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_perfilSeleccionado == null) return;
            var LM830seleccionados = LM830clbPermisosAsigPerfil.CheckedItems.Cast<LM830PermisoSimple>().Select(LM830p => LM830p.LM830Nombre).ToList();
            if (!LM830seleccionados.Any()) return;

            LM830_bll.LM830QuitarHijos(LM830_perfilSeleccionado.LM830Nombre, LM830seleccionados, true);
            LM830CargarDatosFormulario();
            MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("PermisosRemovep"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"));
        }

        private void LM830BtnEliminarPerfil_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_perfilSeleccionado == null) return;
            if (MessageBox.Show($"¿{LM830LanguageManager.LM830Instance.LM830GetTraduction("SeguEliminaPerfP")} '{LM830_perfilSeleccionado.LM830Nombre}'?", LM830LanguageManager.LM830Instance.LM830GetTraduction("ConfirmarElimip"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                LM830_bll.LM830EliminarFamiliaOPerfil(LM830_perfilSeleccionado.LM830Nombre);

                string LM830nombreEliminado = LM830_perfilSeleccionado.LM830Nombre;
                LM830_perfilSeleccionado = null;

                LM830CargarDatosFormulario();
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("ELPerfilP")} '{LM830nombreEliminado}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("SeEliminodelSistema")}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ExitoP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("RestAsigUsup"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LM830MostrarModalResolucionHorizontal(string LM830ancestro, string LM830ramaColateral, string LM830contenedorDirecto, string LM830nodoDestino, string LM830permiso, Action<string> LM830callback)
        {
            Control LM830panelActivo = LM830RbPerfiles.Checked ? (Control)LM830panelPerfiles : (Control)LM830panelFamilias;
            LM830panelActivo.Enabled = false;

            Panel LM830pnlModal = new Panel
            {
                Name = "pnlModalHorizontal",
                Size = new Size(600, 390),
                BackColor = Color.FromArgb(255, 244, 244),
                BorderStyle = BorderStyle.FixedSingle
            };
            LM830pnlModal.Location = new Point((this.ClientSize.Width - LM830pnlModal.Width) / 2, (this.ClientSize.Height - LM830pnlModal.Height) / 2);

            var LM830lblTitulo = new Label
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("AlerCritiP"),
                Location = new Point(15, 15),
                Size = new Size(570, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Firebrick
            };

            string LM830textoExplicativo = "";

            if (LM830RbFamilias.Checked)
            {
                string LM830familiaActual = LM830_familiaSeleccionada != null ? LM830_familiaSeleccionada.LM830Nombre : LM830nodoDestino;

                LM830textoExplicativo =
                    $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("textexpli1")} '{LM830permiso}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("textexpli2")} '{LM830familiaActual}'.\n\n" +
                    $"[{LM830LanguageManager.LM830Instance.LM830GetTraduction("text3")}]:\n" +
                    $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text4")} '{LM830ancestro}').\n\n" +
                    $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("Text5")} '{LM830ramaColateral}', {LM830LanguageManager.LM830Instance.LM830GetTraduction("text6")} '{LM830contenedorDirecto}').\n\n" +
                    $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text7")} '{LM830permiso}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text8")}";
            }
            else
            {
                string LM830perfilActual = LM830_perfilSeleccionado != null ? LM830_perfilSeleccionado.LM830Nombre : LM830nodoDestino;

                if (LM830ancestro == LM830perfilActual)
                {
                    LM830textoExplicativo =
                        $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text9")} '{LM830permiso}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text10")} '{LM830perfilActual}'.\n\n" +
                        $"[{LM830LanguageManager.LM830Instance.LM830GetTraduction("text11")}]:\n" +
                        $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text12")} '{LM830perfilActual}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text13")} '{LM830contenedorDirecto}'. {LM830LanguageManager.LM830Instance.LM830GetTraduction("text14")}";
                }
                else
                {
                    LM830textoExplicativo =
                        $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text15")} '{LM830permiso}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text16")} '{LM830perfilActual}'.\n\n" +
                        $"[{LM830LanguageManager.LM830Instance.LM830GetTraduction("text17")}]:\n" +
                        $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text18")} '{LM830ancestro}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text19")} '{LM830ramaColateral}'.";
                }
            }

            var LM830lblDescripcion = new Label
            {
                Text = LM830textoExplicativo,
                Location = new Point(15, 45),
                Size = new Size(570, 170),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            var LM830rbtnResolver = new RadioButton
            {
                Text = $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text20")} '{LM830contenedorDirecto}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text21")} '{LM830nodoDestino}')",
                Location = new Point(20, 230),
                Size = new Size(560, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Checked = true
            };

            var LM830rbtnCancelar = new RadioButton
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("text22"),
                Location = new Point(20, 265),
                Size = new Size(560, 30),
                Font = new Font("Segoe UI", 9F)
            };

            var LM830btnEjecutar = new Button
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("text23"),
                Location = new Point(220, 320),
                Size = new Size(160, 35),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            LM830btnEjecutar.Click += (LM830s, LM830e) =>
            {
                string LM830estrategia = LM830rbtnResolver.Checked ? "RESOLVER" : "CANCEL";
                this.Controls.Remove(LM830pnlModal);
                LM830pnlModal.Dispose();
                LM830panelActivo.Enabled = true;
                LM830callback?.Invoke(LM830estrategia);
            };

            LM830pnlModal.Controls.Add(LM830lblTitulo);
            LM830pnlModal.Controls.Add(LM830lblDescripcion);
            LM830pnlModal.Controls.Add(LM830rbtnResolver);
            LM830pnlModal.Controls.Add(LM830rbtnCancelar);
            LM830pnlModal.Controls.Add(LM830btnEjecutar);

            this.Controls.Add(LM830pnlModal);
            LM830pnlModal.BringToFront();
        }

        private void LM830MostrarModalResolucionHeredada(string LM830nodoDondeYaExiste, string LM830hijo, string LM830permisos, Action<string> LM830callback)
        {
            Control LM830panelActivo = LM830RbPerfiles.Checked ? (Control)LM830panelPerfiles : (Control)LM830panelFamilias;
            LM830panelActivo.Enabled = false;

            Panel LM830pnlModal = new Panel
            {
                Name = "pnlModalConflictos",
                Size = new Size(500, 280),
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.FixedSingle
            };
            LM830pnlModal.Location = new Point((this.ClientSize.Width - LM830pnlModal.Width) / 2, (this.ClientSize.Height - LM830pnlModal.Height) / 2);

            var LM830lblTitulo = new Label
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("text26"),
                Location = new Point(15, 15),
                Size = new Size(470, 20),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40)
            };

            var LM830lblDescripcion = new Label
            {
                Text = $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text27")} '{LM830hijo}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("text28")}: [{LM830permisos}].\n" +
                       $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("text29")} '{LM830nodoDondeYaExiste}'.\n\n" +
                       LM830LanguageManager.LM830Instance.LM830GetTraduction("text30"),
                Location = new Point(15, 45),
                Size = new Size(470, 75),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            var LM830rbtnResolver = new RadioButton
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("text31"),
                Location = new Point(20, 135),
                Size = new Size(460, 25),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Checked = true
            };

            var LM830rbtnCancelar = new RadioButton
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("text32"),
                Location = new Point(20, 165),
                Size = new Size(460, 25),
                Font = new Font("Segoe UI", 9F)
            };

            var LM830btnEjecutar = new Button
            {
                Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("Confirmarp"),
                Location = new Point(170, 215),
                Size = new Size(160, 32),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            LM830btnEjecutar.Click += (LM830s, LM830e) =>
            {
                string LM830estrategia = LM830rbtnResolver.Checked ? "RESOLVER" : "CANCEL";
                this.Controls.Remove(LM830pnlModal);
                LM830pnlModal.Dispose();
                LM830panelActivo.Enabled = true;
                LM830callback?.Invoke(LM830estrategia);
            };

            LM830pnlModal.Controls.Add(LM830lblTitulo);
            LM830pnlModal.Controls.Add(LM830lblDescripcion);
            LM830pnlModal.Controls.Add(LM830rbtnResolver);
            LM830pnlModal.Controls.Add(LM830rbtnCancelar);
            LM830pnlModal.Controls.Add(LM830btnEjecutar);

            this.Controls.Add(LM830pnlModal);
            LM830pnlModal.BringToFront();
        }

        private void LM830RbPermisos_CheckedChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830RbPermisos.Checked)
            {
                LM830ActualizarEstadoBotonesSegunPermisos();
                LM830SincronizarVisibilidadPaneles();
            }
        }

        private void LM830RbFamilias_CheckedChanged_1(object LM830sender, EventArgs LM830e)
        {
            if (LM830RbFamilias.Checked)
            {
                LM830ActualizarEstadoBotonesSegunPermisos();
                LM830SincronizarVisibilidadPaneles();
            }
        }

        private void LM830RbPerfiles_CheckedChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830RbPerfiles.Checked)
            {
                LM830ActualizarEstadoBotonesSegunPermisos();
                LM830SincronizarVisibilidadPaneles();
            }
        }

        private void LM830btnCerrar_Click(object LM830sender, EventArgs LM830e)
        {
            if (Application.OpenForms["LM830Menu"] != null)
            {
                Application.OpenForms["LM830Menu"].Show();
            }
            else
            {
                LM830Menu LM830menu = new LM830Menu();
                LM830menu.Show();
            }
            this.Close();
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

        private void LM830RefrescarSeguridad()
        {
            LM830ActualizarEstadoBotonesSegunPermisos();

            LM830Usuario LM830usuarioActual = LM830SessionManager.LM830Instance.LM830UsuarioActual();

            if (!LM830usuarioActual.LM830TienePermiso("Ver Perfiles"))
            {
                MessageBox.Show(
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("text33"),
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("text34"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                if (Application.OpenForms["LM830Menu"] != null)
                {
                    Application.OpenForms["LM830Menu"].Show();
                }
                else
                {
                    LM830Menu LM830menu = new LM830Menu();
                    LM830menu.Show();
                }

                this.Close();
            }
        }

        private void LM830frmGestionPerfiles_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
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

        private void LM830BarraTitulo_MouseUp(object LM830sender, MouseEventArgs LM830e)
        {
            LM830arrastrando = false;
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830RbPermisos.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RbPermisos");
            LM830RbFamilias.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RbFamilias");
            LM830RbPerfiles.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("RbPerfiles");

            LM830lblArbol.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblArbol");
            LM830lblPerfiles.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblPerfiles");
            LM830lblNombreP.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblNombreP");

            LM830btnCrearPerfil.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnCrearPerfil");
            LM830btnEliminarPerfil.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnEliminarPerfil");

            LM830lblGestionPerfiles.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblGestionPerfiles");

            LM830lblFamiliaDisponible.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblFamiliaDisponible");
            LM830lblFamiliaAsignadas.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblFamiliaAsignadas");

            LM830lblPermisoDisponible.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblPermisoDisponible");
            LM830lblAsignados.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblAsignados");

            LM830btnAsignarFamiliaPerfil.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnAsignarFamiliaPerfil");
            LM830btnQuitarFamiliaPerfil.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnQuitarFamiliaPerfil");

            LM830BtnAsignarPermisoPerfil.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("BtnAsignarPermisoPerfil");
            LM830BtnQuitarPermisoPerfil.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("BtnQuitarPermisoPerfil");

            LM830label6.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label6");
            LM830label10.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label10");
            LM830label15.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label15");

            LM830lblNombrePermisos.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("lblNombrePermisos");
            LM830btnCrearPermiso.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnCrearPermiso");
            LM830btnEliminarPermiso.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnEliminarPermiso");
            LM830label2.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label2");
            LM830btnCrearFamilia.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnCrearFamilia");
            LM830btnEliminarFamilia.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnEliminarFamilia");
            LM830label4.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label4");
            LM830btnAsignarSubfamilia.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnAsignarSubfamilia");
            LM830label5.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label5");
            LM830btnQuitarSubfamilia.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnQuitarSubfamilia");
            LM830label7.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label7");
            LM830btnAsignarPermisos.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnAsignarPermisos");
            LM830label8.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("label8");
            LM830btnQuitarPermisos.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("btnQuitarPermisos");
        }
    }
}

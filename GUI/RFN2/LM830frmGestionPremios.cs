#nullable enable
using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN2;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN2
{
    public partial class LM830frmGestionPremios : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830PremioBLL LM830_bll = new LM830PremioBLL();
        private List<LM830Premio> LM830_premios = new List<LM830Premio>();

        public LM830frmGestionPremios()
        {
            InitializeComponent();
            LM830dgvPremios.DataBindingComplete += (LM830s, LM830e) => LM830dgvPremios.ClearSelection();
        }

        private void LM830frmGestionPremios_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            try
            {
                LM830Cargar();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LM830Limpiar();
        }

        private void LM830Cargar()
        {
            LM830_premios = LM830_bll.LM830Listar();
            LM830dgvPremios.DataSource = LM830_premios.Select(LM830p => new
            {
                Premio = LM830p.LM830Nombre,
                Descripción = LM830p.LM830Descripcion,
                Puntos = LM830p.LM830PuntosRequeridos.ToString("N0"),
                Stock = LM830p.LM830Stock,
                Valor = "$ " + LM830p.LM830ValorReferencia.ToString("N2")
            }).ToList();
        }

        private void LM830Limpiar()
        {
            LM830dgvPremios.ClearSelection();
            LM830txtNombre.Clear();
            LM830txtDescripcion.Clear();
            LM830nudPuntos.Value = 0;
            LM830nudStock.Value = 0;
            LM830nudValor.Value = 0;
            LM830txtNombre.Select();
        }

        private LM830Premio? LM830Seleccionado()
        {
            if (LM830dgvPremios.SelectedRows.Count == 0) return null;
            int LM830i = LM830dgvPremios.SelectedRows[0].Index;
            return LM830i >= 0 && LM830i < LM830_premios.Count ? LM830_premios[LM830i] : null;
        }

        private void LM830dgvPremios_SelectionChanged(object LM830sender, EventArgs LM830e)
        {
            LM830Premio? LM830p = LM830Seleccionado();
            if (LM830p == null) return;
            LM830txtNombre.Text = LM830p.LM830Nombre;
            LM830txtDescripcion.Text = LM830p.LM830Descripcion;
            LM830nudPuntos.Value = Math.Min(LM830p.LM830PuntosRequeridos, LM830nudPuntos.Maximum);
            LM830nudStock.Value = Math.Min(LM830p.LM830Stock, LM830nudStock.Maximum);
            LM830nudValor.Value = Math.Min(LM830p.LM830ValorReferencia, LM830nudValor.Maximum);
        }

        private LM830Premio LM830LeerDatos(int LM830id) => new LM830Premio
        {
            LM830IdPremio = LM830id,
            LM830Nombre = LM830txtNombre.Text,
            LM830Descripcion = LM830txtDescripcion.Text,
            LM830PuntosRequeridos = (int)LM830nudPuntos.Value,
            LM830Stock = (int)LM830nudStock.Value,
            LM830ValorReferencia = LM830nudValor.Value
        };

        private void LM830btnAgregar_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Guardar(() => LM830_bll.LM830Agregar(LM830LeerDatos(0)));
        }

        private void LM830btnModificar_Click(object LM830sender, EventArgs LM830e)
        {
            var LM830sel = LM830Seleccionado();
            if (LM830sel == null)
            {
                MessageBox.Show(LM830T("RFN1_SeleccioneRegistro"), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LM830Guardar(() => LM830_bll.LM830Modificar(LM830LeerDatos(LM830sel.LM830IdPremio)));
        }

        private void LM830btnEliminar_Click(object LM830sender, EventArgs LM830e)
        {
            var LM830sel = LM830Seleccionado();
            if (LM830sel == null)
            {
                MessageBox.Show(LM830T("RFN1_SeleccioneRegistro"), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(string.Format(LM830T("RFN1_ConfirmarEliminar"), LM830sel.LM830Nombre), Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            LM830Guardar(() => LM830_bll.LM830Eliminar(LM830sel));
        }

        private void LM830Guardar(Action LM830accion)
        {
            try
            {
                LM830accion();
                MessageBox.Show(LM830T("RFN1_CambiosGuardados"), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LM830Cargar();
                LM830Limpiar();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LM830btnLimpiar_Click(object LM830sender, EventArgs LM830e) => LM830Limpiar();

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmGestionPremios_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN2_GestionPremios");
            LM830lblTitulo.Text = Text;
            LM830grpDatos.Text = LM830lenguaje.LM830GetTraduction("RFN1_Datos");
            LM830lblNombre.Text = LM830lenguaje.LM830GetTraduction("RFN1_Nombre");
            LM830lblDescripcion.Text = LM830lenguaje.LM830GetTraduction("RFN2_Descripcion");
            LM830lblPuntos.Text = LM830lenguaje.LM830GetTraduction("RFN2_PuntosRequeridos");
            LM830lblStock.Text = LM830lenguaje.LM830GetTraduction("RFN2_Stock");
            LM830lblValor.Text = LM830lenguaje.LM830GetTraduction("RFN2_ValorDeReferencia");
            LM830btnAgregar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Agregar");
            LM830btnModificar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Modificar");
            LM830btnEliminar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Eliminar");
            LM830btnLimpiar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Limpiar");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtNombre.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN2_PH_NombrePremio"));
            SendMessage(LM830txtDescripcion.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN2_PH_Descripcion"));
        }
    }
}

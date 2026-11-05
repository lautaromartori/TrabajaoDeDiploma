#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmGestionProductos : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830ProductoBLL LM830_bll = new LM830ProductoBLL();
        private List<LM830Producto> LM830_productos = new List<LM830Producto>();

        public LM830frmGestionProductos()
        {
            InitializeComponent();
            LM830dgvProductos.DataBindingComplete += (LM830s, LM830e) => LM830dgvProductos.ClearSelection();
        }

        private void LM830frmGestionProductos_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830cmbCategoria.DisplayMember = "LM830Nombre";
            LM830cmbCategoria.ValueMember = "LM830IdCategoria";
            try
            {
                LM830cmbCategoria.DataSource = LM830_bll.LM830ListarCategorias();
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
            LM830_productos = LM830_bll.LM830Listar();
            LM830dgvProductos.DataSource = LM830_productos.Select(LM830p => new
            {
                Producto = LM830p.LM830Nombre,
                Precio = "$ " + LM830p.LM830Precio.ToString("N2"),
                Categoría = LM830p.LM830Categoria.LM830Nombre
            }).ToList();
        }

        private void LM830Limpiar()
        {
            LM830dgvProductos.ClearSelection();
            LM830txtNombre.Clear();
            LM830nudPrecio.Value = 0;
            LM830cmbCategoria.SelectedIndex = LM830cmbCategoria.Items.Count > 0 ? 0 : -1;
            LM830txtNombre.Select();
        }

        private LM830Producto? LM830Seleccionado()
        {
            if (LM830dgvProductos.SelectedRows.Count == 0) return null;
            int LM830i = LM830dgvProductos.SelectedRows[0].Index;
            return LM830i >= 0 && LM830i < LM830_productos.Count ? LM830_productos[LM830i] : null;
        }

        private void LM830dgvProductos_SelectionChanged(object LM830sender, EventArgs LM830e)
        {
            LM830Producto? LM830p = LM830Seleccionado();
            if (LM830p == null) return;
            LM830txtNombre.Text = LM830p.LM830Nombre;
            LM830nudPrecio.Value = Math.Min(LM830p.LM830Precio, LM830nudPrecio.Maximum);
            LM830cmbCategoria.SelectedValue = LM830p.LM830Categoria.LM830IdCategoria;
        }

        private LM830Producto LM830LeerDatos(int LM830id) => new LM830Producto
        {
            LM830IdProducto = LM830id,
            LM830Nombre = LM830txtNombre.Text,
            LM830Precio = LM830nudPrecio.Value,
            LM830Categoria = LM830cmbCategoria.SelectedItem as LM830Categoria ?? new LM830Categoria()
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
            LM830Guardar(() => LM830_bll.LM830Modificar(LM830LeerDatos(LM830sel.LM830IdProducto)));
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

        private void LM830frmGestionProductos_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN1_GestionProductos");
            LM830lblTitulo.Text = Text;
            LM830grpDatos.Text = LM830lenguaje.LM830GetTraduction("RFN1_Datos");
            LM830lblNombre.Text = LM830lenguaje.LM830GetTraduction("RFN1_Nombre");
            LM830lblPrecio.Text = LM830lenguaje.LM830GetTraduction("RFN1_Precio");
            LM830lblCategoria.Text = LM830lenguaje.LM830GetTraduction("RFN1_Categoria");
            LM830btnAgregar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Agregar");
            LM830btnModificar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Modificar");
            LM830btnEliminar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Eliminar");
            LM830btnLimpiar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Limpiar");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtNombre.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_NombreProducto"));
        }
    }
}

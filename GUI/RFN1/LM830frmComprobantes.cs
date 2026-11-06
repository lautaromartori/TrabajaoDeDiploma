#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830GUI.LM830Comprobantes;
using LM830Servicios;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmComprobantes : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830ComprobanteBLL LM830_comprobanteBLL = new LM830ComprobanteBLL();
        private LM830ComprobanteVenta? LM830_comprobante;
        private string? LM830_archivoOrigen;

        public LM830frmComprobantes()
        {
            InitializeComponent();
        }

        public LM830frmComprobantes(string LM830nroComprobante) : this()
        {
            LM830txtNro.Text = LM830nroComprobante;
        }

        private void LM830frmComprobantes_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            if (LM830txtNro.Text.Trim().Length > 0) LM830btnBuscar_Click(LM830sender, LM830e);
            else LM830Mostrar();
            LM830txtNro.Select();
        }

        private void LM830btnBuscar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830ComprobanteVenta? LM830c = LM830_comprobanteBLL.LM830Buscar(LM830txtNro.Text);
                if (LM830c == null)
                {
                    MessageBox.Show(LM830T("RFN1_VentaNoExiste"), LM830T("CMP_Comprobantes"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LM830txtNro.SelectAll();
                    LM830txtNro.Select();
                    return;
                }
                LM830_comprobante = LM830c;
                LM830_archivoOrigen = null;
                LM830txtNro.Text = LM830c.LM830NroComprobante;
                LM830Mostrar();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830Mostrar()
        {
            LM830ComprobanteVenta? LM830c = LM830_comprobante;
            bool LM830hay = LM830c != null;
            LM830btnPdf.Enabled = LM830hay;
            LM830btnXml.Enabled = LM830hay;
            LM830btnJson.Enabled = LM830hay;

            if (LM830c == null)
            {
                LM830lblNroDatos.Text = "-";
                LM830lblFechaDatos.Text = "-";
                LM830lblClienteDatos.Text = "-";
                LM830lblTotalesDatos.Text = "-";
                LM830lblOrigen.Text = "";
                LM830dgvItems.DataSource = null;
                return;
            }

            LM830lblNroDatos.Text = $"{LM830c.LM830Comercio} - {LM830T("RFN1_Comprobante")} {LM830c.LM830NroComprobante}";
            LM830lblFechaDatos.Text = $"{LM830T("CMP_Fecha")}: {LM830c.LM830Fecha:dd/MM/yyyy HH:mm} - {LM830T("CMP_Vendedor")}: {LM830c.LM830Vendedor}";
            LM830lblClienteDatos.Text = LM830c.LM830TieneCliente()
                ? $"{LM830T("RFN1_Cliente")}: {LM830c.LM830Cliente} (DNI {LM830c.LM830DniCliente}) - {LM830T("RFN1_Nivel")} {LM830c.LM830Nivel}"
                : LM830T("RFN1_VentaSinCliente");
            LM830lblTotalesDatos.Text = LM830c.LM830TieneCliente()
                ? $"{LM830T("RFN1_Total")}: $ {LM830c.LM830Total:N2} - {LM830T("RFN1_PuntosAcreditados")}: {LM830c.LM830PuntosAcreditados:N0} - {LM830T("RFN1_SaldoVigente")}: {LM830c.LM830SaldoVigente:N0}"
                : $"{LM830T("RFN1_Total")}: $ {LM830c.LM830Total:N2}";
            LM830lblOrigen.Text = LM830_archivoOrigen == null
                ? LM830T("CMP_OrigenBase")
                : $"{LM830T("CMP_OrigenArchivo")} {Path.GetFileName(LM830_archivoOrigen)}";

            LM830dgvItems.DataSource = LM830c.LM830Items.Select(LM830i => new
            {
                Producto = LM830i.LM830Producto,
                Categoría = LM830i.LM830Categoria,
                Cantidad = LM830i.LM830Cantidad,
                Precio = LM830i.LM830PrecioUnitario.ToString("N2"),
                Subtotal = LM830i.LM830Subtotal.ToString("N2"),
                Puntos = LM830i.LM830Puntos
            }).ToList();
        }

        private void LM830btnPdf_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_comprobante == null) return;
            string? LM830ruta = LM830GeneradorPDF.LM830ElegirRuta(this, "Comprobante_" + LM830_comprobante.LM830NroComprobante);
            if (LM830ruta == null) return;
            try
            {
                LM830GeneradorPDF.LM830ComprobanteVenta(LM830_comprobante, LM830ruta);
                LM830_comprobanteBLL.LM830RegistrarImpresion(LM830_comprobante.LM830NroComprobante, LM830ruta);
                LM830GeneradorPDF.LM830Abrir(LM830ruta);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830btnXml_Click(object LM830sender, EventArgs LM830e) => LM830Exportar("XML (*.xml)|*.xml", ".xml");

        private void LM830btnJson_Click(object LM830sender, EventArgs LM830e) => LM830Exportar("JSON (*.json)|*.json", ".json");

        private void LM830Exportar(string LM830filtro, string LM830extension)
        {
            if (LM830_comprobante == null) return;
            using (var LM830dialogo = new SaveFileDialog())
            {
                LM830dialogo.Filter = LM830filtro;
                LM830dialogo.FileName = "Comprobante_" + LM830_comprobante.LM830NroComprobante + LM830extension;
                LM830dialogo.Title = LM830T("CMP_Serializar");
                if (LM830dialogo.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    LM830_comprobanteBLL.LM830Exportar(LM830_comprobante, LM830dialogo.FileName);
                    MessageBox.Show($"{LM830T("CMP_Serializado")}{Environment.NewLine}{LM830dialogo.FileName}", LM830T("CMP_Comprobantes"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception LM830ex)
                {
                    MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LM830btnImportar_Click(object LM830sender, EventArgs LM830e)
        {
            using (var LM830dialogo = new OpenFileDialog())
            {
                LM830dialogo.Filter = "XML / JSON (*.xml;*.json)|*.xml;*.json";
                LM830dialogo.Title = LM830T("CMP_Deserializar");
                if (LM830dialogo.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    LM830_comprobante = LM830_comprobanteBLL.LM830Importar(LM830dialogo.FileName);
                    LM830_archivoOrigen = LM830dialogo.FileName;
                    LM830txtNro.Text = LM830_comprobante.LM830NroComprobante;
                    LM830Mostrar();
                }
                catch (Exception LM830ex)
                {
                    MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmComprobantes_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("CMP_Comprobantes");
            LM830lblTitulo.Text = Text;
            LM830lblNro.Text = LM830lenguaje.LM830GetTraduction("RFN1_NroComprobante");
            LM830btnBuscar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830btnImportar.Text = LM830lenguaje.LM830GetTraduction("CMP_AbrirArchivo");
            LM830grpDatos.Text = LM830lenguaje.LM830GetTraduction("RFN1_Comprobante");
            LM830btnPdf.Text = LM830lenguaje.LM830GetTraduction("CMP_GenerarPdf");
            LM830btnXml.Text = LM830lenguaje.LM830GetTraduction("CMP_ExportarXml");
            LM830btnJson.Text = LM830lenguaje.LM830GetTraduction("CMP_ExportarJson");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            LM830Mostrar();
            SendMessage(LM830txtNro.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_NroComprobante"));
        }
    }
}

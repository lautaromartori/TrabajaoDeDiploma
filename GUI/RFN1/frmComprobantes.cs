#nullable enable
using BE.RFN1;
using BLL.RFN1;
using GUI.Comprobantes;
using Servicios;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI.RFN1
{
    public partial class frmComprobantes : Form, IObserver
    {
        private readonly ComprobanteBLL _comprobanteBLL = new ComprobanteBLL();
        private ComprobanteVenta? _comprobante;
        private string? _archivoOrigen;

        public frmComprobantes()
        {
            InitializeComponent();
        }

        public frmComprobantes(string nroComprobante) : this()
        {
            txtNro.Text = nroComprobante;
        }

        private void frmComprobantes_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            if (txtNro.Text.Trim().Length > 0) btnBuscar_Click(sender, e);
            else Mostrar();
            txtNro.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ComprobanteVenta? c = _comprobanteBLL.Buscar(txtNro.Text);
                if (c == null)
                {
                    MessageBox.Show(T("RFN1_VentaNoExiste"), T("CMP_Comprobantes"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNro.SelectAll();
                    txtNro.Select();
                    return;
                }
                _comprobante = c;
                _archivoOrigen = null;
                txtNro.Text = c.NroComprobante;
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mostrar()
        {
            ComprobanteVenta? c = _comprobante;
            bool hay = c != null;
            btnPdf.Enabled = hay;
            btnXml.Enabled = hay;
            btnJson.Enabled = hay;

            if (c == null)
            {
                lblNroDatos.Text = "-";
                lblFechaDatos.Text = "-";
                lblClienteDatos.Text = "-";
                lblTotalesDatos.Text = "-";
                lblOrigen.Text = "";
                dgvItems.DataSource = null;
                return;
            }

            lblNroDatos.Text = $"{c.Comercio} - {T("RFN1_Comprobante")} {c.NroComprobante}";
            lblFechaDatos.Text = $"{T("CMP_Fecha")}: {c.Fecha:dd/MM/yyyy HH:mm} - {T("CMP_Vendedor")}: {c.Vendedor}";
            lblClienteDatos.Text = c.TieneCliente()
                ? $"{T("RFN1_Cliente")}: {c.Cliente} (DNI {c.DniCliente}) - {T("RFN1_Nivel")} {c.Nivel}"
                : T("RFN1_VentaSinCliente");
            lblTotalesDatos.Text = c.TieneCliente()
                ? $"{T("RFN1_Total")}: $ {c.Total:N2} - {T("RFN1_PuntosAcreditados")}: {c.PuntosAcreditados:N0} - {T("RFN1_SaldoVigente")}: {c.SaldoVigente:N0}"
                : $"{T("RFN1_Total")}: $ {c.Total:N2}";
            lblOrigen.Text = _archivoOrigen == null
                ? T("CMP_OrigenBase")
                : $"{T("CMP_OrigenArchivo")} {Path.GetFileName(_archivoOrigen)}";

            dgvItems.DataSource = c.Items.Select(i => new
            {
                Producto = i.Producto,
                Categoría = i.Categoria,
                Cantidad = i.Cantidad,
                Precio = i.PrecioUnitario.ToString("N2"),
                Subtotal = i.Subtotal.ToString("N2"),
                Puntos = i.Puntos
            }).ToList();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (_comprobante == null) return;
            string? ruta = GeneradorPDF.ElegirRuta(this, "Comprobante_" + _comprobante.NroComprobante);
            if (ruta == null) return;
            try
            {
                GeneradorPDF.ComprobanteVenta(_comprobante, ruta);
                _comprobanteBLL.RegistrarImpresion(_comprobante.NroComprobante, ruta);
                GeneradorPDF.Abrir(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXml_Click(object sender, EventArgs e) => Exportar("XML (*.xml)|*.xml", ".xml");

        private void btnJson_Click(object sender, EventArgs e) => Exportar("JSON (*.json)|*.json", ".json");

        private void Exportar(string filtro, string extension)
        {
            if (_comprobante == null) return;
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Filter = filtro;
                dialogo.FileName = "Comprobante_" + _comprobante.NroComprobante + extension;
                dialogo.Title = T("CMP_Serializar");
                if (dialogo.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    _comprobanteBLL.Exportar(_comprobante, dialogo.FileName);
                    MessageBox.Show($"{T("CMP_Serializado")}{Environment.NewLine}{dialogo.FileName}", T("CMP_Comprobantes"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (var dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "XML / JSON (*.xml;*.json)|*.xml;*.json";
                dialogo.Title = T("CMP_Deserializar");
                if (dialogo.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    _comprobante = _comprobanteBLL.Importar(dialogo.FileName);
                    _archivoOrigen = dialogo.FileName;
                    txtNro.Text = _comprobante.NroComprobante;
                    Mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmComprobantes_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("CMP_Comprobantes");
            lblTitulo.Text = Text;
            lblNro.Text = lenguaje.GetTraduction("RFN1_NroComprobante");
            btnBuscar.Text = lenguaje.GetTraduction("RFN1_Buscar");
            btnImportar.Text = lenguaje.GetTraduction("CMP_AbrirArchivo");
            grpDatos.Text = lenguaje.GetTraduction("RFN1_Comprobante");
            btnPdf.Text = lenguaje.GetTraduction("CMP_GenerarPdf");
            btnXml.Text = lenguaje.GetTraduction("CMP_ExportarXml");
            btnJson.Text = lenguaje.GetTraduction("CMP_ExportarJson");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
            Mostrar();
        }
    }
}

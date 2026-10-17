#nullable enable
using BE.RFN1;
using BLL.RFN1;
using Servicios;
using System;
using System.Windows.Forms;

namespace GUI.RFN1
{
    public partial class frmRegistrarCliente : Form, IObserver
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly bool _desdeOtroCU;

        public Cliente? ClienteRegistrado { get; private set; }

        public frmRegistrarCliente()
        {
            InitializeComponent();
        }

        public frmRegistrarCliente(string dni) : this()
        {
            _desdeOtroCU = true;
            txtDni.Text = dni;
        }

        private void frmRegistrarCliente_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Actualizar(LanguageManager.Instance);
            if (_desdeOtroCU) txtNombre.Select(); else txtDni.Select();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblErrores.Text = "";
            Cliente cliente = new Cliente
            {
                Dni = txtDni.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            try
            {
                if (!_clienteBLL.ValidarDatos(cliente))
                {
                    lblErrores.Text = string.Join(Environment.NewLine, _clienteBLL.ErroresValidacion);
                    return;
                }

                _clienteBLL.Registrar(cliente);
                ClienteRegistrado = cliente;

                MessageBox.Show($"{T("RFN1_ClienteInscripto")} {cliente.NombreCompleto} - {T("RFN1_Nivel")} {cliente.Nivel.Nombre}.",
                    T("RFN1_RegistrarCliente"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_desdeOtroCU)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Limpiar();
                }
            }
            catch (ClienteExistenteException ex)
            {
                string datos = $"{ex.Cliente.NombreCompleto}{Environment.NewLine}DNI {ex.Cliente.Dni} - {ex.Cliente.Email}{Environment.NewLine}{T("RFN1_Nivel")}: {ex.Cliente.Nivel.Nombre}";
                if (_desdeOtroCU)
                {
                    if (MessageBox.Show($"{T("RFN1_DniYaRegistrado")}{Environment.NewLine}{Environment.NewLine}{datos}{Environment.NewLine}{Environment.NewLine}{T("RFN1_UsarCliente")}",
                            T("RFN1_RegistrarCliente"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ClienteRegistrado = ex.Cliente;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show($"{T("RFN1_DniYaRegistrado")}{Environment.NewLine}{Environment.NewLine}{datos}",
                        T("RFN1_RegistrarCliente"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_desdeOtroCU) DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmRegistrarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            if (!_desdeOtroCU) Navegacion.MostrarMenu();
        }

        private void Limpiar()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            lblErrores.Text = "";
            txtDni.Select();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN1_RegistrarCliente");
            lblTitulo.Text = Text;
            lblDni.Text = lenguaje.GetTraduction("RFN1_Dni");
            lblNombre.Text = lenguaje.GetTraduction("RFN1_Nombre");
            lblApellido.Text = lenguaje.GetTraduction("RFN1_Apellido");
            lblEmail.Text = lenguaje.GetTraduction("RFN1_Email");
            lblTelefono.Text = lenguaje.GetTraduction("RFN1_Telefono");
            btnGuardar.Text = lenguaje.GetTraduction("RFN1_Guardar");
            btnCancelar.Text = lenguaje.GetTraduction("RFN1_Cancelar");
        }
    }
}

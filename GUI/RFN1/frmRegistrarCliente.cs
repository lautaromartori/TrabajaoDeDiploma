#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830Servicios;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmRegistrarCliente : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830ClienteBLL LM830_clienteBLL = new LM830ClienteBLL();
        private readonly bool LM830_desdeOtroCU;

        public LM830Cliente? LM830ClienteRegistrado { get; private set; }

        public LM830frmRegistrarCliente()
        {
            InitializeComponent();
        }

        public LM830frmRegistrarCliente(string LM830dni) : this()
        {
            LM830_desdeOtroCU = true;
            LM830txtDni.Text = LM830dni;
        }

        private void LM830frmRegistrarCliente_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            if (LM830_desdeOtroCU) LM830txtNombre.Select(); else LM830txtDni.Select();
        }

        private void LM830btnGuardar_Click(object LM830sender, EventArgs LM830e)
        {
            LM830lblErrores.Text = "";
            LM830Cliente LM830cliente = new LM830Cliente
            {
                LM830Dni = LM830txtDni.Text,
                LM830Nombre = LM830txtNombre.Text,
                LM830Apellido = LM830txtApellido.Text,
                LM830Email = LM830txtEmail.Text,
                LM830Telefono = LM830txtTelefono.Text
            };

            try
            {
                if (!LM830_clienteBLL.LM830ValidarDatos(LM830cliente))
                {
                    LM830lblErrores.Text = string.Join(Environment.NewLine, LM830_clienteBLL.LM830ErroresValidacion);
                    return;
                }

                LM830_clienteBLL.LM830Registrar(LM830cliente);
                LM830ClienteRegistrado = LM830cliente;

                MessageBox.Show($"{LM830T("RFN1_ClienteInscripto")} {LM830cliente.LM830NombreCompleto} - {LM830T("RFN1_Nivel")} {LM830cliente.LM830Nivel.LM830Nombre}.",
                    LM830T("RFN1_RegistrarCliente"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (LM830_desdeOtroCU)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    LM830Limpiar();
                }
            }
            catch (LM830ClienteExistenteException LM830ex)
            {
                string LM830datos = $"{LM830ex.LM830Cliente.LM830NombreCompleto}{Environment.NewLine}DNI {LM830ex.LM830Cliente.LM830Dni} - {LM830ex.LM830Cliente.LM830Email}{Environment.NewLine}{LM830T("RFN1_Nivel")}: {LM830ex.LM830Cliente.LM830Nivel.LM830Nombre}";
                if (LM830_desdeOtroCU)
                {
                    if (MessageBox.Show($"{LM830T("RFN1_DniYaRegistrado")}{Environment.NewLine}{Environment.NewLine}{LM830datos}{Environment.NewLine}{Environment.NewLine}{LM830T("RFN1_UsarCliente")}",
                            LM830T("RFN1_RegistrarCliente"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        LM830ClienteRegistrado = LM830ex.LM830Cliente;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show($"{LM830T("RFN1_DniYaRegistrado")}{Environment.NewLine}{Environment.NewLine}{LM830datos}",
                        LM830T("RFN1_RegistrarCliente"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830btnCancelar_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_desdeOtroCU) DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LM830frmRegistrarCliente_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            if (!LM830_desdeOtroCU) LM830Navegacion.LM830MostrarMenu();
        }

        private void LM830Limpiar()
        {
            LM830txtDni.Clear();
            LM830txtNombre.Clear();
            LM830txtApellido.Clear();
            LM830txtEmail.Clear();
            LM830txtTelefono.Clear();
            LM830lblErrores.Text = "";
            LM830txtDni.Select();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN1_RegistrarCliente");
            LM830lblTitulo.Text = Text;
            LM830lblDni.Text = LM830lenguaje.LM830GetTraduction("RFN1_Dni");
            LM830lblNombre.Text = LM830lenguaje.LM830GetTraduction("RFN1_Nombre");
            LM830lblApellido.Text = LM830lenguaje.LM830GetTraduction("RFN1_Apellido");
            LM830lblEmail.Text = LM830lenguaje.LM830GetTraduction("RFN1_Email");
            LM830lblTelefono.Text = LM830lenguaje.LM830GetTraduction("RFN1_Telefono");
            LM830btnGuardar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Guardar");
            LM830btnCancelar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Cancelar");
            SendMessage(LM830txtDni.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Dni"));
            SendMessage(LM830txtNombre.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Nombre"));
            SendMessage(LM830txtApellido.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Apellido"));
            SendMessage(LM830txtEmail.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Email"));
            SendMessage(LM830txtTelefono.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Telefono"));
        }
    }
}

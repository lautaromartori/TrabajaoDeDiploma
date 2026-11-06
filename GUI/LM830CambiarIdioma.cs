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
    public partial class LM830CambiarIdioma : Form,LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        public LM830CambiarIdioma()
        {
            InitializeComponent();
        }
        private void LM830IniciarListaDeIdiomas()
        {
            var LM830lista = new List<object>()
            {
                new {Idioma=LM830LanguageManager.LM830Instance.LM830GetTraduction("Español"), Codigo="es"},
                new {Idioma=LM830LanguageManager.LM830Instance.LM830GetTraduction("Ingles"), Codigo="en"},
                new {Idioma=LM830LanguageManager.LM830Instance.LM830GetTraduction("Japones"), Codigo="ja"}
            };

            LM830cbIdiomas.DisplayMember = "Idioma";
            LM830cbIdiomas.ValueMember = "Codigo";
            LM830cbIdiomas.DataSource = LM830lista;

            int LM830ind = 0;
            foreach (object LM830item in LM830cbIdiomas.Items)
            {
                if (LM830item.GetType().GetProperty("Idioma").GetValue(LM830item) as string
                    == LM830LanguageManager.LM830Instance.LM830GetCurrentLanguage().EnglishName)
                {
                    LM830ind = LM830cbIdiomas.Items.IndexOf(LM830item);
                }
            }
            LM830cbIdiomas.SelectedIndex = LM830ind;
        }

        private void LM830btnCambiar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                string LM830idioma =
                    LM830cbIdiomas.SelectedValue.ToString();

                LM830LanguageManager.LM830Instance
                    .LM830CargarIdioma(LM830idioma);

                MessageBox.Show(
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("MsjCambiarIdioma"),
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("MsjConfirmacion"),
                    MessageBoxButtons.OK);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message);
            }
        }
        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            try
            {
                LM830btnCambiarCI.Text = LM830lenguaje.LM830GetTraduction("btnCambiarCI");
                LM830lblCambiarIdioma.Text = LM830lenguaje.LM830GetTraduction("lblCambiarIdioma");
                LM830button1.Text = LM830LanguageManager.LM830Instance.LM830GetTraduction("Salir");
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message);
            }
        }

        private void LM830CambiarIdioma_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830LanguageManager.LM830Instance.LM830NotificarObservadores();
            LM830IniciarListaDeIdiomas();
        }

        private void LM830button1_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Navegacion.LM830VolverAlMenu(this);
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
    }
}

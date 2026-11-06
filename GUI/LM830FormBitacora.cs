using LM830BLL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iText = iTextSharp.text;

namespace LM830GUI
{
    public partial class LM830FormBitacora : Form,LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        LM830BitacoraBLL LM830bll;
        public LM830FormBitacora()
        {
            InitializeComponent();
            LM830bll = new LM830BitacoraBLL();

            this.Load += LM830FormBitacora_Load;

            LM830dtpFechaFinal.Value = DateTime.Now;
            LM830dtpFechaInicio.Value = DateTime.Now.AddDays(-3);

            LM830CargarFiltros();

            try
            {
                List<LM830Bitacora> LM830listaInicial = LM830bll.LM830FiltrarEventos(null, null, null, "Todos", null, LM830dtpFechaInicio.Value, LM830dtpFechaFinal.Value, null);

                LM830dtgvBitacora.DataSource = LM830listaInicial;
                LM830ConfigurarDtgv();
                LM830MostrarPrimerRegistro();
            }
            catch (Exception)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("Bitmsj1"), LM830LanguageManager.LM830Instance.LM830GetTraduction("Bitmsj2"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LM830dtgvBitacora.SelectionChanged += LM830DtgvBitacora_SelectionChanged;
        }

        private void LM830MostrarPrimerRegistro()
        {
            if (LM830dtgvBitacora.Rows.Count > 0)
            {
                LM830dtgvBitacora.Rows[0].Selected = true;
                if (LM830dtgvBitacora.Rows[0].DataBoundItem is LM830Bitacora LM830b)
                    LM830MostrarUsuario(LM830b.LM830Login);
            }
            else
            {
                LM830txtNombre.Text = string.Empty;
                LM830txtApellido.Text = string.Empty;
            }
        }
        private void LM830MostrarUsuario(string LM830login)
        {
            try
            {
                LM830Usuario LM830u = LM830bll.LM830ObtenerUsuarioPorLogin(LM830login);
                if (LM830u != null)
                {
                    LM830txtNombre.Text = LM830u.LM830Nombre;
                    LM830txtApellido.Text = LM830u.LM830Apellido;
                }
                else
                {
                    LM830txtNombre.Text = string.Empty;
                    LM830txtApellido.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                LM830txtNombre.Text = string.Empty;
                LM830txtApellido.Text = string.Empty;
            }
        }

        private void LM830CargarFiltros()
        {
            try
            {
                LM830cmbLogin.SelectedIndexChanged -= LM830cmbLogin_SelectedIndexChanged;

                LM830cmbLogin.Items.Clear();
                foreach (var LM830l in LM830bll.LM830ObtenerLogins())
                    LM830cmbLogin.Items.Add(LM830l);

                LM830cmbModulo.Items.Clear();
                LM830cmbModulo.Items.Add("Todos");
                LM830cmbModulo.Items.Add("Usuarios");
                LM830cmbModulo.Items.Add("Perfiles");
                LM830cmbModulo.Items.Add("Idioma");
                LM830cmbModulo.Items.Add("DigitoVerificador");
                LM830cmbModulo.Items.Add("Clientes");
                LM830cmbModulo.Items.Add("Ventas");
                LM830cmbModulo.Items.Add("Reclamos");
                LM830cmbModulo.SelectedIndex = 0;

                LM830cmbEvento.Items.Clear();
                LM830cmbEvento.Items.Add("Login");
                LM830cmbEvento.Items.Add("Login fallido");
                LM830cmbEvento.Items.Add("Desloguear");
                LM830cmbEvento.Items.Add("Crear Usuario");
                LM830cmbEvento.Items.Add("Cambiar Clave");
                LM830cmbEvento.Items.Add("bloqueado");
                LM830cmbEvento.Items.Add("Registrar cliente");
                LM830cmbEvento.Items.Add("Registrar venta");
                LM830cmbEvento.Items.Add("Registrar reclamo");
                LM830cmbEvento.Items.Add("Aprobar reclamo");
                LM830cmbEvento.Items.Add("Rechazar reclamo");
                LM830cmbEvento.Items.Add("Recalculo");

                LM830cmbCriticidad.Items.Clear();
                LM830cmbCriticidad.Items.Add("Todos");
                for (int LM830i = 1; LM830i <= 5; LM830i++)
                    LM830cmbCriticidad.Items.Add(LM830i.ToString());
                LM830cmbCriticidad.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj3"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                LM830cmbLogin.SelectedIndexChanged += LM830cmbLogin_SelectedIndexChanged;
            }
        }

        private void LM830DtgvBitacora_SelectionChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830dtgvBitacora.CurrentRow?.DataBoundItem is LM830Bitacora LM830b)
                LM830MostrarUsuario(LM830b.LM830Login);
        }

         private void LM830ConfigurarDtgv()
        {
            LM830dtgvBitacora.ReadOnly = true;
            LM830dtgvBitacora.AllowUserToAddRows = false;
            LM830dtgvBitacora.AllowUserToDeleteRows = false;
            LM830dtgvBitacora.AllowUserToOrderColumns = false;
            LM830dtgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LM830dtgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (LM830dtgvBitacora.Columns["LM830Id_Evento"] != null)
                LM830dtgvBitacora.Columns["LM830Id_Evento"].Visible = false;

            if (LM830dtgvBitacora.Columns["LM830Fecha"] != null)
                LM830dtgvBitacora.Columns["LM830Fecha"].Visible = false;

            if (LM830dtgvBitacora.Columns["LM830Evento"] != null)
                LM830dtgvBitacora.Columns["LM830Evento"].HeaderText = "Evento";

            if (LM830dtgvBitacora.Columns["LM830FechaSolo"] != null)
                LM830dtgvBitacora.Columns["LM830FechaSolo"].HeaderText = "Fecha";

            if (LM830dtgvBitacora.Columns["LM830HoraSolo"] != null)
                LM830dtgvBitacora.Columns["LM830HoraSolo"].HeaderText = "Hora";

            LM830dtgvBitacora.Columns["LM830Login"].DisplayIndex = 0;
            LM830dtgvBitacora.Columns["LM830FechaSolo"].DisplayIndex = 1;
            LM830dtgvBitacora.Columns["LM830HoraSolo"].DisplayIndex = 2;
            LM830dtgvBitacora.Columns["LM830Modulo"].DisplayIndex = 3;
            LM830dtgvBitacora.Columns["LM830Evento"].DisplayIndex = 4;
            LM830dtgvBitacora.Columns["LM830Criticidad"].DisplayIndex = 5;
        }
        private void LM830panel1_MouseUp(object LM830sender, MouseEventArgs LM830e)
        {
            LM830arrastrando = false;
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

        private void LM830btnAplicar_Click(object LM830sender, EventArgs LM830e)
        {
            if (!LM830ValidarFiltros()) return;

            try
            {
                string LM830nombre = string.IsNullOrWhiteSpace(LM830txtNombre.Text) ? null : LM830txtNombre.Text.Trim();
                string LM830apellido = string.IsNullOrWhiteSpace(LM830txtApellido.Text) ? null : LM830txtApellido.Text.Trim();
                string LM830login = string.IsNullOrWhiteSpace(LM830cmbLogin.Text) ? null : LM830cmbLogin.Text.Trim();
                string LM830modulo = LM830cmbModulo.SelectedItem?.ToString();
                string LM830evento = string.IsNullOrWhiteSpace(LM830cmbEvento.Text) ? null : LM830cmbEvento.Text.Trim();
                DateTime LM830desde = LM830dtpFechaInicio.Value;
                DateTime LM830hasta = LM830dtpFechaFinal.Value;

                int? LM830criticidad = null;
                if (!string.IsNullOrEmpty(LM830cmbCriticidad.Text) && LM830cmbCriticidad.Text != "Todos")
                    LM830criticidad = Convert.ToInt32(LM830cmbCriticidad.Text);

                List<LM830Bitacora> LM830listaFiltrada = LM830bll.LM830FiltrarEventos(LM830nombre, LM830apellido, LM830login, LM830modulo, LM830evento, LM830desde, LM830hasta, LM830criticidad);

                LM830dtgvBitacora.SelectionChanged -= LM830DtgvBitacora_SelectionChanged;
                LM830dtgvBitacora.DataSource = null;
                LM830dtgvBitacora.DataSource = LM830listaFiltrada;
                LM830ConfigurarDtgv();
                LM830dtgvBitacora.SelectionChanged += LM830DtgvBitacora_SelectionChanged;

                if (LM830listaFiltrada.Count == 0)
                {
                    LM830txtNombre.Text = string.Empty;
                    LM830txtApellido.Text = string.Empty;
                    MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj4"), LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj5"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LM830MostrarPrimerRegistro();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj6"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LM830ValidarFiltros()
        {
            if (LM830dtpFechaInicio.Value.Date > LM830dtpFechaFinal.Value.Date)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj7"), LM830LanguageManager.LM830Instance.LM830GetTraduction("bitMsj8"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830dtpFechaInicio.Focus();
                return false;
            }

            return true;
        }

        private void LM830panel1_MouseMove(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830arrastrando)
            {
                this.Location = new Point(this.Location.X + (LM830e.X - LM830posX), this.Location.Y + (LM830e.Y - LM830posY));
            }
        }

        private void LM830btnLimpiar_Click(object LM830sender, EventArgs LM830e)
        {
            LM830cmbLogin.SelectedIndexChanged -= LM830cmbLogin_SelectedIndexChanged;
            LM830dtgvBitacora.SelectionChanged -= LM830DtgvBitacora_SelectionChanged;

            LM830txtNombre.Text = string.Empty;
            LM830txtApellido.Text = string.Empty;
            LM830cmbLogin.SelectedIndex = -1;
            LM830cmbModulo.SelectedIndex = 0;
            LM830cmbEvento.SelectedIndex = -1;
            LM830cmbCriticidad.SelectedIndex = 0;

            LM830dtpFechaInicio.Value = DateTime.Now.AddDays(-3);
            LM830dtpFechaFinal.Value = DateTime.Now;

            try
            {
                LM830dtgvBitacora.DataSource = null;
                LM830dtgvBitacora.DataSource = LM830bll.LM830FiltrarEventos(null, null, null, "Todos", null, LM830dtpFechaInicio.Value, LM830dtpFechaFinal.Value, null);
                LM830ConfigurarDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMjs9"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LM830cmbLogin.SelectedIndexChanged += LM830cmbLogin_SelectedIndexChanged;
                LM830dtgvBitacora.SelectionChanged += LM830DtgvBitacora_SelectionChanged;
            }
        }

        private void LM830btnImprimir_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dtgvBitacora.Rows.Count == 0)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMjs10"), LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj11"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog LM830saveDialog = new SaveFileDialog();
            LM830saveDialog.Filter = "PDF|*.pdf";
            LM830saveDialog.FileName = "Bitacora_" + DateTime.Now.ToString("yyyyMMdd_HHmm");

            if (LM830saveDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                iText.Document LM830doc = new iText.Document(iText.PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter.GetInstance(LM830doc, new FileStream(LM830saveDialog.FileName, FileMode.Create));
                LM830doc.Open();

                iText.Font LM830fontTitulo = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 14);
                iText.Font LM830fontFecha = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA, 9);
                iText.Font LM830fontHeader = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA_BOLD, 9);
                iText.Font LM830fontCell = iText.FontFactory.GetFont(iText.FontFactory.HELVETICA, 8);
                iText.BaseColor LM830colorHeader = new iText.BaseColor(46, 125, 50);

                LM830doc.Add(new iText.Paragraph("Bitácora de Eventos", LM830fontTitulo));
                LM830doc.Add(new iText.Paragraph("Generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), LM830fontFecha));
                LM830doc.Add(new iText.Paragraph(" "));

                PdfPTable LM830tabla = new PdfPTable(6);
                LM830tabla.WidthPercentage = 100;
                LM830tabla.SetWidths(new float[] { 15f, 12f, 8f, 12f, 25f, 10f });

                foreach (string LM830col in new[] { "Login", "Fecha", "Hora", "Módulo", "Evento", "Criticidad" })
                {
                    PdfPCell LM830cell = new PdfPCell(new iText.Phrase(LM830col, LM830fontHeader));
                    LM830cell.BackgroundColor = LM830colorHeader;
                    LM830cell.HorizontalAlignment = iText.Element.ALIGN_CENTER;
                    LM830cell.Padding = 5;
                    LM830tabla.AddCell(LM830cell);
                }

                foreach (DataGridViewRow LM830row in LM830dtgvBitacora.Rows)
                {
                    if (LM830row.DataBoundItem is LM830Bitacora LM830b)
                    {
                        LM830tabla.AddCell(new PdfPCell(new iText.Phrase(LM830b.LM830Login, LM830fontCell)) { Padding = 4 });
                        LM830tabla.AddCell(new PdfPCell(new iText.Phrase(LM830b.LM830Fecha.ToString("dd/MM/yyyy"), LM830fontCell)) { Padding = 4 });
                        LM830tabla.AddCell(new PdfPCell(new iText.Phrase(LM830b.LM830Fecha.ToString("HH:mm"), LM830fontCell)) { Padding = 4 });
                        LM830tabla.AddCell(new PdfPCell(new iText.Phrase(LM830b.LM830Modulo, LM830fontCell)) { Padding = 4 });
                        LM830tabla.AddCell(new PdfPCell(new iText.Phrase(LM830b.LM830Evento, LM830fontCell)) { Padding = 4 });
                        LM830tabla.AddCell(new PdfPCell(new iText.Phrase(LM830b.LM830Criticidad.ToString(), LM830fontCell)) { Padding = 4, HorizontalAlignment = iText.Element.ALIGN_CENTER });
                    }
                }

                LM830doc.Add(LM830tabla);
                LM830doc.Close();

                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj12"), LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj13"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(LM830saveDialog.FileName) { UseShellExecute = true });
            }
            catch (IOException)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj14"), LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj15"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj16"), LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830cmbLogin_SelectedIndexChanged(object LM830sender, EventArgs LM830e)
        {
            if (!string.IsNullOrEmpty(LM830cmbLogin.Text))
                LM830MostrarUsuario(LM830cmbLogin.Text);
            else
            {
                LM830txtNombre.Text = string.Empty;
                LM830txtApellido.Text = string.Empty;
            }
        }

        private void LM830FormBitacora_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);

            LM830ValidarPermisos();
        }

        private void LM830ValidarPermisos()
        {
            LM830Usuario LM830usuarioActual = LM830SessionManager.LM830Instance.LM830UsuarioActual();

            if (!LM830usuarioActual.LM830TienePermiso("Ver Bitacora"))
            {
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj17"), LM830LanguageManager.LM830Instance.LM830GetTraduction("BitMsj18"), MessageBoxButtons.OK, MessageBoxIcon.Stop);

                if (Application.OpenForms["LM830Menu"] != null)
                {
                    Application.OpenForms["LM830Menu"].Show();
                }
                else
                {
                    LM830Menu LM830menu = new LM830Menu();
                    LM830menu.Show();
                }

                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            LM830btnAplicarB.Enabled = LM830usuarioActual.LM830TienePermiso("Filtrar Bitacora");
            LM830btnLimpiarB.Enabled = LM830usuarioActual.LM830TienePermiso("Limpiar Bitacora");
            LM830btnImprimirB.Enabled = LM830usuarioActual.LM830TienePermiso("Imprimir Bitacora");
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830lblBitacora.Text = LM830lenguaje.LM830GetTraduction("lblBitacora");
            LM830lblNombreB.Text = LM830lenguaje.LM830GetTraduction("lblNombreB");
            LM830lblApellidoB.Text = LM830lenguaje.LM830GetTraduction("lblApellidoB");
            LM830lblLoginB.Text = LM830lenguaje.LM830GetTraduction("lblLoginB");
            LM830lblFechaInicioB.Text = LM830lenguaje.LM830GetTraduction("lblFechaInicioB");
            LM830lblFechaFinalB.Text = LM830lenguaje.LM830GetTraduction("lblFechaFinalB");
            LM830lblModuloB.Text = LM830lenguaje.LM830GetTraduction("lblModuloB");
            LM830lblEventoB.Text = LM830lenguaje.LM830GetTraduction("lblEventoB");
            LM830lblCriticidadB.Text = LM830lenguaje.LM830GetTraduction("lblCriticidadB");

            LM830btnLimpiarB.Text = LM830lenguaje.LM830GetTraduction("btnLimpiarB");
            LM830btnAplicarB.Text = LM830lenguaje.LM830GetTraduction("btnAplicarB");
            LM830btnImprimirB.Text = LM830lenguaje.LM830GetTraduction("btnImprimirB");
        }
    }
}

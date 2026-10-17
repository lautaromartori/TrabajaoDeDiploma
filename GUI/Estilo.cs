using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    internal static class Estilo
    {
        public static readonly Color Verde = Color.FromArgb(46, 125, 50);
        public static readonly Color VerdeOscuro = Color.FromArgb(27, 94, 32);
        public static readonly Color VerdeClaro = Color.FromArgb(232, 245, 233);
        public static readonly Color VerdeSeleccion = Color.FromArgb(165, 214, 167);

        public static void Aplicar(Control raiz)
        {
            foreach (Control c in raiz.Controls)
            {
                if (c is DataGridView grilla) Grilla(grilla);
                if (c.HasChildren) Aplicar(c);
            }
        }

        public static void Grilla(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersDefaultCellStyle.BackColor = Verde;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Verde;
            g.ColumnHeadersDefaultCellStyle.Font = new Font(g.Font, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            g.DefaultCellStyle.SelectionBackColor = VerdeSeleccion;
            g.DefaultCellStyle.SelectionForeColor = Color.Black;
            g.AlternatingRowsDefaultCellStyle.BackColor = VerdeClaro;
            g.BackgroundColor = Color.White;
            g.GridColor = Color.FromArgb(200, 230, 201);
        }
    }
}

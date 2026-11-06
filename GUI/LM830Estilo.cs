using System.Drawing;
using System.Windows.Forms;

namespace LM830GUI
{
    internal static class LM830Estilo
    {
        public static readonly Color LM830Verde = Color.FromArgb(46, 125, 50);
        public static readonly Color LM830VerdeOscuro = Color.FromArgb(27, 94, 32);
        public static readonly Color LM830VerdeClaro = Color.FromArgb(232, 245, 233);
        public static readonly Color LM830VerdeSeleccion = Color.FromArgb(165, 214, 167);

        public static void LM830Aplicar(Control LM830raiz)
        {
            foreach (Control LM830c in LM830raiz.Controls)
            {
                if (LM830c is DataGridView LM830grilla) LM830Grilla(LM830grilla);
                if (LM830c.HasChildren) LM830Aplicar(LM830c);
            }
        }

        public static void LM830Grilla(DataGridView LM830g)
        {
            LM830g.EnableHeadersVisualStyles = false;
            LM830g.ColumnHeadersDefaultCellStyle.BackColor = LM830Verde;
            LM830g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            LM830g.ColumnHeadersDefaultCellStyle.SelectionBackColor = LM830Verde;
            LM830g.ColumnHeadersDefaultCellStyle.Font = new Font(LM830g.Font, FontStyle.Bold);
            LM830g.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            LM830g.DefaultCellStyle.SelectionBackColor = LM830VerdeSeleccion;
            LM830g.DefaultCellStyle.SelectionForeColor = Color.Black;
            LM830g.AlternatingRowsDefaultCellStyle.BackColor = LM830VerdeClaro;
            LM830g.BackgroundColor = Color.White;
            LM830g.GridColor = Color.FromArgb(200, 230, 201);
        }
    }
}

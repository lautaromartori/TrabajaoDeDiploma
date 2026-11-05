#nullable enable
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    // Texto de ayuda en gris dentro de un TextBox con el formato que se espera (por ejemplo "Ej.: V-00000001").
    // Se ve mientras el campo está vacío y desaparece apenas se escribe; nunca forma parte de Text,
    // así que no interfiere con las validaciones. .NET Framework 4.7.2 no trae PlaceholderText,
    // por eso se dibuja encima del control al procesar WM_PAINT. Funciona en TextBox de una línea y multilínea.
    internal sealed class LM830Placeholder : NativeWindow
    {
        private const int LM830WM_PAINT = 0x000F;
        private static readonly Dictionary<TextBox, LM830Placeholder> LM830_activos = new Dictionary<TextBox, LM830Placeholder>();

        private readonly TextBox LM830_textBox;
        private string LM830_texto;

        private LM830Placeholder(TextBox LM830textBox, string LM830texto)
        {
            LM830_textBox = LM830textBox;
            LM830_texto = LM830texto;
            LM830textBox.HandleCreated += (LM830s, LM830e) => AssignHandle(LM830_textBox.Handle);
            LM830textBox.HandleDestroyed += (LM830s, LM830e) => ReleaseHandle();
            LM830textBox.TextChanged += (LM830s, LM830e) => LM830_textBox.Invalidate();
            LM830textBox.GotFocus += (LM830s, LM830e) => LM830_textBox.Invalidate();
            LM830textBox.LostFocus += (LM830s, LM830e) => LM830_textBox.Invalidate();
            LM830textBox.Disposed += (LM830s, LM830e) => LM830_activos.Remove(LM830_textBox);
            if (LM830textBox.IsHandleCreated) AssignHandle(LM830textBox.Handle);
        }

        // Pone o cambia el texto de ayuda (se vuelve a llamar al cambiar el idioma).
        public static void LM830Poner(TextBox LM830textBox, string LM830texto)
        {
            if (LM830_activos.TryGetValue(LM830textBox, out LM830Placeholder? LM830existente))
            {
                LM830existente.LM830_texto = LM830texto;
                LM830textBox.Invalidate();
                return;
            }
            LM830_activos[LM830textBox] = new LM830Placeholder(LM830textBox, LM830texto);
        }

        protected override void WndProc(ref Message LM830m)
        {
            base.WndProc(ref LM830m);
            if (LM830m.Msg != LM830WM_PAINT || LM830_textBox.TextLength > 0 || LM830_texto.Length == 0) return;

            using (Graphics LM830g = Graphics.FromHwnd(LM830_textBox.Handle))
            {
                Rectangle LM830area = LM830_textBox.ClientRectangle;
                TextFormatFlags LM830formato = TextFormatFlags.Left | TextFormatFlags.NoPrefix;
                if (LM830_textBox.Multiline)
                {
                    LM830area.Inflate(-2, -2);
                    LM830formato |= TextFormatFlags.Top | TextFormatFlags.WordBreak;
                }
                else
                {
                    LM830area.X += 1;
                    LM830area.Width -= 2;
                    LM830formato |= TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
                }
                TextRenderer.DrawText(LM830g, LM830_texto, LM830_textBox.Font, LM830area, SystemColors.GrayText, LM830formato);
            }
        }
    }
}

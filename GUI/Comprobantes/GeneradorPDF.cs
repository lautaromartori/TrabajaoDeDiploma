#nullable enable
using LM830BE.LM830RFN1;
using LM830BE.LM830RFN2;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using iText = iTextSharp.text;

namespace LM830GUI.LM830Comprobantes
{
    internal static class LM830GeneradorPDF
    {
        private static readonly CultureInfo LM830Cultura = new CultureInfo("es-AR");
        private static readonly iText.BaseColor LM830Verde = new iText.BaseColor(46, 125, 50);
        private static readonly iText.BaseColor LM830VerdeOscuro = new iText.BaseColor(27, 94, 32);
        private static readonly iText.BaseColor LM830VerdeClaro = new iText.BaseColor(232, 245, 233);
        private static readonly iText.BaseColor LM830Gris = new iText.BaseColor(97, 97, 97);

        private static readonly BaseFont LM830Base = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        private static readonly BaseFont LM830BaseNegrita = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

        private static iText.Font LM830Fuente(float LM830tamanio, bool LM830negrita = false, iText.BaseColor? LM830color = null) =>
            new iText.Font(LM830negrita ? LM830BaseNegrita : LM830Base, LM830tamanio, iText.Font.NORMAL, LM830color ?? iText.BaseColor.BLACK);

        public static string? LM830ElegirRuta(IWin32Window LM830owner, string LM830nombreSugerido)
        {
            using (var LM830dialogo = new SaveFileDialog())
            {
                LM830dialogo.Filter = "PDF (*.pdf)|*.pdf";
                LM830dialogo.FileName = LM830nombreSugerido + ".pdf";
                LM830dialogo.Title = "Guardar comprobante";
                return LM830dialogo.ShowDialog(LM830owner) == DialogResult.OK ? LM830dialogo.FileName : null;
            }
        }

        public static void LM830Abrir(string LM830ruta)
        {
            try
            {
                Process.Start(new ProcessStartInfo(LM830ruta) { UseShellExecute = true });
            }
            catch
            {
            }
        }

        public static void LM830ComprobanteVenta(LM830ComprobanteVenta LM830c, string LM830ruta)
        {
            LM830Generar(LM830ruta, LM830doc =>
            {
                LM830Encabezado(LM830doc, "Comprobante de venta", LM830c.LM830NroComprobante);

                PdfPTable LM830datos = LM830TablaDatos();
                LM830Dato(LM830datos, "Fecha", LM830c.LM830Fecha.ToString("dd/MM/yyyy HH:mm", LM830Cultura));
                LM830Dato(LM830datos, "Vendedor", LM830c.LM830Vendedor);
                if (LM830c.LM830TieneCliente())
                {
                    LM830Dato(LM830datos, "Cliente", $"{LM830c.LM830Cliente} (DNI {LM830c.LM830DniCliente})");
                    LM830Dato(LM830datos, "Nivel", LM830c.LM830Nivel);
                }
                else
                {
                    LM830Dato(LM830datos, "Cliente", "Venta sin cliente identificado");
                }
                LM830doc.Add(LM830datos);
                LM830doc.Add(LM830Espacio(8));

                PdfPTable LM830items = new PdfPTable(6) { WidthPercentage = 100 };
                LM830items.SetWidths(new float[] { 34, 18, 9, 14, 15, 10 });
                LM830Titulos(LM830items, "Producto", "Categoría", "Cant.", "P. unitario", "Subtotal", "Puntos");
                int LM830fila = 0;
                foreach (LM830ItemComprobante LM830i in LM830c.LM830Items)
                {
                    iText.BaseColor LM830fondo = LM830fila++ % 2 == 0 ? iText.BaseColor.WHITE : LM830VerdeClaro;
                    LM830Celda(LM830items, LM830i.LM830Producto, LM830fondo);
                    LM830Celda(LM830items, LM830i.LM830Categoria, LM830fondo);
                    LM830Celda(LM830items, LM830i.LM830Cantidad.ToString("N0", LM830Cultura), LM830fondo, iText.Element.ALIGN_RIGHT);
                    LM830Celda(LM830items, "$ " + LM830i.LM830PrecioUnitario.ToString("N2", LM830Cultura), LM830fondo, iText.Element.ALIGN_RIGHT);
                    LM830Celda(LM830items, "$ " + LM830i.LM830Subtotal.ToString("N2", LM830Cultura), LM830fondo, iText.Element.ALIGN_RIGHT);
                    LM830Celda(LM830items, LM830i.LM830Puntos.ToString("N0", LM830Cultura), LM830fondo, iText.Element.ALIGN_RIGHT);
                }
                LM830doc.Add(LM830items);
                LM830doc.Add(LM830Espacio(8));

                PdfPTable LM830totales = LM830TablaTotales();
                LM830Total(LM830totales, "Total", "$ " + LM830c.LM830Total.ToString("N2", LM830Cultura), true);
                if (LM830c.LM830TieneCliente())
                {
                    LM830Total(LM830totales, "Puntos acreditados", LM830c.LM830PuntosAcreditados.ToString("N0", LM830Cultura) + " pts", false);
                    LM830Total(LM830totales, "Saldo vigente", LM830c.LM830SaldoVigente.ToString("N0", LM830Cultura) + " pts", false);
                }
                LM830doc.Add(LM830totales);

                LM830Pie(LM830doc, LM830c.LM830FechaEmision);
            });
        }

        public static void LM830ComprobanteCanje(LM830Canje LM830k, int LM830saldoRestante, string LM830ruta)
        {
            LM830Generar(LM830ruta, LM830doc =>
            {
                LM830Encabezado(LM830doc, "Comprobante de canje", LM830k.LM830NroCanje);

                PdfPTable LM830datos = LM830TablaDatos();
                LM830Dato(LM830datos, "Fecha de entrega", (LM830k.LM830FechaEntrega ?? DateTime.Now).ToString("dd/MM/yyyy HH:mm", LM830Cultura));
                LM830Dato(LM830datos, "Cliente", $"{LM830k.LM830Cliente.LM830NombreCompleto} (DNI {LM830k.LM830Cliente.LM830Dni})");
                LM830Dato(LM830datos, "Nivel", LM830k.LM830Cliente.LM830Nivel.LM830Nombre);
                LM830Dato(LM830datos, "Premio", LM830k.LM830Premio.LM830Nombre);
                if (!string.IsNullOrWhiteSpace(LM830k.LM830Premio.LM830Descripcion)) LM830Dato(LM830datos, "Descripción", LM830k.LM830Premio.LM830Descripcion);
                LM830doc.Add(LM830datos);
                LM830doc.Add(LM830Espacio(8));

                LM830doc.Add(new iText.Paragraph("Puntos descontados por vencimiento", LM830Fuente(10, true, LM830VerdeOscuro)));
                LM830doc.Add(LM830Espacio(4));
                PdfPTable LM830lotes = new PdfPTable(4) { WidthPercentage = 100 };
                LM830lotes.SetWidths(new float[] { 20, 30, 30, 20 });
                LM830Titulos(LM830lotes, "Lote", "Acreditado", "Vence", "Puntos");
                int LM830fila = 0;
                foreach (LM830DetalleCanje LM830d in LM830k.LM830Detalle)
                {
                    iText.BaseColor LM830fondo = LM830fila++ % 2 == 0 ? iText.BaseColor.WHITE : LM830VerdeClaro;
                    LM830Celda(LM830lotes, LM830d.LM830Lote.LM830IdLote.ToString(LM830Cultura), LM830fondo);
                    LM830Celda(LM830lotes, LM830d.LM830Lote.LM830FechaAcreditacion.ToString("dd/MM/yyyy", LM830Cultura), LM830fondo);
                    LM830Celda(LM830lotes, LM830d.LM830Lote.LM830FechaVencimiento.ToString("dd/MM/yyyy", LM830Cultura), LM830fondo);
                    LM830Celda(LM830lotes, LM830d.LM830PuntosDescontados.ToString("N0", LM830Cultura), LM830fondo, iText.Element.ALIGN_RIGHT);
                }
                LM830doc.Add(LM830lotes);
                LM830doc.Add(LM830Espacio(8));

                PdfPTable LM830totales = LM830TablaTotales();
                LM830Total(LM830totales, "Puntos descontados", LM830k.LM830PuntosRequeridos.ToString("N0", LM830Cultura) + " pts", true);
                LM830Total(LM830totales, "Saldo restante", LM830saldoRestante.ToString("N0", LM830Cultura) + " pts", false);
                LM830Total(LM830totales, "Stock restante del premio", LM830k.LM830Premio.LM830Stock.ToString("N0", LM830Cultura), false);
                LM830doc.Add(LM830totales);

                LM830Pie(LM830doc, DateTime.Now);
            });
        }

        private static void LM830Generar(string LM830ruta, Action<iText.Document> LM830contenido)
        {
            var LM830doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 36f, 36f);
            using (var LM830archivo = new FileStream(LM830ruta, FileMode.Create, FileAccess.Write))
            {
                PdfWriter.GetInstance(LM830doc, LM830archivo);
                LM830doc.AddTitle("Le Marchant");
                LM830doc.AddCreator("Le Marchant");
                LM830doc.Open();
                try
                {
                    LM830contenido(LM830doc);
                }
                finally
                {
                    LM830doc.Close();
                }
            }
        }

        private static void LM830Encabezado(iText.Document LM830doc, string LM830tipo, string LM830numero)
        {
            PdfPTable LM830t = new PdfPTable(2) { WidthPercentage = 100 };
            LM830t.SetWidths(new float[] { 18, 82 });

            iText.Image LM830logo = iText.Image.GetInstance(Properties.Resources.LeMarchant, System.Drawing.Imaging.ImageFormat.Png);
            LM830logo.ScaleToFit(72f, 72f);
            LM830t.AddCell(new PdfPCell(LM830logo) { Border = iText.Rectangle.NO_BORDER, VerticalAlignment = iText.Element.ALIGN_MIDDLE });

            var LM830texto = new PdfPCell { Border = iText.Rectangle.NO_BORDER, VerticalAlignment = iText.Element.ALIGN_MIDDLE };
            LM830texto.AddElement(new iText.Paragraph("Le Marchant", LM830Fuente(22, true, LM830VerdeOscuro)));
            LM830texto.AddElement(new iText.Paragraph("Mercado de barrio · Ciudad Autónoma de Buenos Aires", LM830Fuente(9, false, LM830Gris)));
            LM830texto.AddElement(new iText.Paragraph($"{LM830tipo} N° {LM830numero}", LM830Fuente(13, true, LM830Verde)) { SpacingBefore = 6 });
            LM830t.AddCell(LM830texto);
            LM830doc.Add(LM830t);

            LM830doc.Add(new iText.Chunk(new LineSeparator(2f, 100f, LM830Verde, iText.Element.ALIGN_CENTER, -4f)));
            LM830doc.Add(LM830Espacio(10));
        }

        private static PdfPTable LM830TablaDatos()
        {
            PdfPTable LM830t = new PdfPTable(2) { WidthPercentage = 100 };
            LM830t.SetWidths(new float[] { 22, 78 });
            return LM830t;
        }

        private static void LM830Dato(PdfPTable LM830t, string LM830etiqueta, string LM830valor)
        {
            LM830t.AddCell(new PdfPCell(new iText.Phrase(LM830etiqueta, LM830Fuente(10, true, LM830VerdeOscuro))) { Border = iText.Rectangle.NO_BORDER, PaddingBottom = 4 });
            LM830t.AddCell(new PdfPCell(new iText.Phrase(LM830valor, LM830Fuente(10))) { Border = iText.Rectangle.NO_BORDER, PaddingBottom = 4 });
        }

        private static void LM830Titulos(PdfPTable LM830t, params string[] LM830titulos)
        {
            foreach (string LM830titulo in LM830titulos)
            {
                LM830t.AddCell(new PdfPCell(new iText.Phrase(LM830titulo, LM830Fuente(9, true, iText.BaseColor.WHITE)))
                {
                    BackgroundColor = LM830Verde,
                    BorderColor = LM830Verde,
                    Padding = 5,
                    HorizontalAlignment = iText.Element.ALIGN_CENTER
                });
            }
            LM830t.HeaderRows = 1;
        }

        private static void LM830Celda(PdfPTable LM830t, string LM830texto, iText.BaseColor LM830fondo, int LM830alineacion = 0)
        {
            LM830t.AddCell(new PdfPCell(new iText.Phrase(LM830texto, LM830Fuente(9)))
            {
                BackgroundColor = LM830fondo,
                BorderColor = new iText.BaseColor(200, 230, 201),
                Padding = 4,
                HorizontalAlignment = LM830alineacion
            });
        }

        private static PdfPTable LM830TablaTotales()
        {
            PdfPTable LM830t = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = iText.Element.ALIGN_RIGHT };
            LM830t.SetWidths(new float[] { 55, 45 });
            return LM830t;
        }

        private static void LM830Total(PdfPTable LM830t, string LM830etiqueta, string LM830valor, bool LM830destacado)
        {
            iText.BaseColor LM830fondo = LM830destacado ? LM830Verde : LM830VerdeClaro;
            iText.BaseColor LM830letra = LM830destacado ? iText.BaseColor.WHITE : LM830VerdeOscuro;
            LM830t.AddCell(new PdfPCell(new iText.Phrase(LM830etiqueta, LM830Fuente(LM830destacado ? 11 : 10, true, LM830letra)))
            {
                BackgroundColor = LM830fondo, BorderColor = LM830fondo, Padding = 5
            });
            LM830t.AddCell(new PdfPCell(new iText.Phrase(LM830valor, LM830Fuente(LM830destacado ? 11 : 10, LM830destacado, LM830letra)))
            {
                BackgroundColor = LM830fondo, BorderColor = LM830fondo, Padding = 5, HorizontalAlignment = iText.Element.ALIGN_RIGHT
            });
        }

        private static void LM830Pie(iText.Document LM830doc, DateTime LM830emision)
        {
            LM830doc.Add(LM830Espacio(18));
            LM830doc.Add(new iText.Chunk(new LineSeparator(0.5f, 100f, new iText.BaseColor(200, 230, 201), iText.Element.ALIGN_CENTER, -2f)));
            var LM830pie = new iText.Paragraph($"Emitido el {LM830emision.ToString("dd/MM/yyyy HH:mm", LM830Cultura)} · Documento no válido como factura · ¡Gracias por elegirnos!", LM830Fuente(8, false, LM830Gris))
            {
                Alignment = iText.Element.ALIGN_CENTER,
                SpacingBefore = 6
            };
            LM830doc.Add(LM830pie);
        }

        private static iText.Paragraph LM830Espacio(float LM830alto) => new iText.Paragraph(" ", LM830Fuente(1)) { SpacingAfter = LM830alto };
    }
}

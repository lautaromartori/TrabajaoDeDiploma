#nullable enable
using BE.RFN1;
using BE.RFN2;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using iText = iTextSharp.text;

namespace GUI.Comprobantes
{
    internal static class GeneradorPDF
    {
        private static readonly CultureInfo Cultura = new CultureInfo("es-AR");
        private static readonly iText.BaseColor Verde = new iText.BaseColor(46, 125, 50);
        private static readonly iText.BaseColor VerdeOscuro = new iText.BaseColor(27, 94, 32);
        private static readonly iText.BaseColor VerdeClaro = new iText.BaseColor(232, 245, 233);
        private static readonly iText.BaseColor Gris = new iText.BaseColor(97, 97, 97);

        private static readonly BaseFont Base = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        private static readonly BaseFont BaseNegrita = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

        private static iText.Font Fuente(float tamanio, bool negrita = false, iText.BaseColor? color = null) =>
            new iText.Font(negrita ? BaseNegrita : Base, tamanio, iText.Font.NORMAL, color ?? iText.BaseColor.BLACK);

        public static string? ElegirRuta(IWin32Window owner, string nombreSugerido)
        {
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "PDF (*.pdf)|*.pdf";
                dialogo.FileName = nombreSugerido + ".pdf";
                dialogo.Title = "Guardar comprobante";
                return dialogo.ShowDialog(owner) == DialogResult.OK ? dialogo.FileName : null;
            }
        }

        public static void Abrir(string ruta)
        {
            try
            {
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch
            {
            }
        }

        public static void ComprobanteVenta(ComprobanteVenta c, string ruta)
        {
            Generar(ruta, doc =>
            {
                Encabezado(doc, "Comprobante de venta", c.NroComprobante);

                PdfPTable datos = TablaDatos();
                Dato(datos, "Fecha", c.Fecha.ToString("dd/MM/yyyy HH:mm", Cultura));
                Dato(datos, "Vendedor", c.Vendedor);
                if (c.TieneCliente())
                {
                    Dato(datos, "Cliente", $"{c.Cliente} (DNI {c.DniCliente})");
                    Dato(datos, "Nivel", c.Nivel);
                }
                else
                {
                    Dato(datos, "Cliente", "Venta sin cliente identificado");
                }
                doc.Add(datos);
                doc.Add(Espacio(8));

                PdfPTable items = new PdfPTable(6) { WidthPercentage = 100 };
                items.SetWidths(new float[] { 34, 18, 9, 14, 15, 10 });
                Titulos(items, "Producto", "Categoría", "Cant.", "P. unitario", "Subtotal", "Puntos");
                int fila = 0;
                foreach (ItemComprobante i in c.Items)
                {
                    iText.BaseColor fondo = fila++ % 2 == 0 ? iText.BaseColor.WHITE : VerdeClaro;
                    Celda(items, i.Producto, fondo);
                    Celda(items, i.Categoria, fondo);
                    Celda(items, i.Cantidad.ToString("N0", Cultura), fondo, iText.Element.ALIGN_RIGHT);
                    Celda(items, "$ " + i.PrecioUnitario.ToString("N2", Cultura), fondo, iText.Element.ALIGN_RIGHT);
                    Celda(items, "$ " + i.Subtotal.ToString("N2", Cultura), fondo, iText.Element.ALIGN_RIGHT);
                    Celda(items, i.Puntos.ToString("N0", Cultura), fondo, iText.Element.ALIGN_RIGHT);
                }
                doc.Add(items);
                doc.Add(Espacio(8));

                PdfPTable totales = TablaTotales();
                Total(totales, "Total", "$ " + c.Total.ToString("N2", Cultura), true);
                if (c.TieneCliente())
                {
                    Total(totales, "Puntos acreditados", c.PuntosAcreditados.ToString("N0", Cultura) + " pts", false);
                    Total(totales, "Saldo vigente", c.SaldoVigente.ToString("N0", Cultura) + " pts", false);
                }
                doc.Add(totales);

                Pie(doc, c.FechaEmision);
            });
        }

        public static void ComprobanteCanje(Canje k, int saldoRestante, string ruta)
        {
            Generar(ruta, doc =>
            {
                Encabezado(doc, "Comprobante de canje", k.NroCanje);

                PdfPTable datos = TablaDatos();
                Dato(datos, "Fecha de entrega", (k.FechaEntrega ?? DateTime.Now).ToString("dd/MM/yyyy HH:mm", Cultura));
                Dato(datos, "Cliente", $"{k.Cliente.NombreCompleto} (DNI {k.Cliente.Dni})");
                Dato(datos, "Nivel", k.Cliente.Nivel.Nombre);
                Dato(datos, "Premio", k.Premio.Nombre);
                if (!string.IsNullOrWhiteSpace(k.Premio.Descripcion)) Dato(datos, "Descripción", k.Premio.Descripcion);
                doc.Add(datos);
                doc.Add(Espacio(8));

                doc.Add(new iText.Paragraph("Puntos descontados por vencimiento", Fuente(10, true, VerdeOscuro)));
                doc.Add(Espacio(4));
                PdfPTable lotes = new PdfPTable(4) { WidthPercentage = 100 };
                lotes.SetWidths(new float[] { 20, 30, 30, 20 });
                Titulos(lotes, "Lote", "Acreditado", "Vence", "Puntos");
                int fila = 0;
                foreach (DetalleCanje d in k.Detalle)
                {
                    iText.BaseColor fondo = fila++ % 2 == 0 ? iText.BaseColor.WHITE : VerdeClaro;
                    Celda(lotes, d.Lote.IdLote.ToString(Cultura), fondo);
                    Celda(lotes, d.Lote.FechaAcreditacion.ToString("dd/MM/yyyy", Cultura), fondo);
                    Celda(lotes, d.Lote.FechaVencimiento.ToString("dd/MM/yyyy", Cultura), fondo);
                    Celda(lotes, d.PuntosDescontados.ToString("N0", Cultura), fondo, iText.Element.ALIGN_RIGHT);
                }
                doc.Add(lotes);
                doc.Add(Espacio(8));

                PdfPTable totales = TablaTotales();
                Total(totales, "Puntos descontados", k.PuntosRequeridos.ToString("N0", Cultura) + " pts", true);
                Total(totales, "Saldo restante", saldoRestante.ToString("N0", Cultura) + " pts", false);
                Total(totales, "Stock restante del premio", k.Premio.Stock.ToString("N0", Cultura), false);
                doc.Add(totales);

                Pie(doc, DateTime.Now);
            });
        }

        private static void Generar(string ruta, Action<iText.Document> contenido)
        {
            var doc = new iText.Document(iText.PageSize.A4, 40f, 40f, 36f, 36f);
            using (var archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            {
                PdfWriter.GetInstance(doc, archivo);
                doc.AddTitle("Le Marchant");
                doc.AddCreator("Le Marchant");
                doc.Open();
                try
                {
                    contenido(doc);
                }
                finally
                {
                    doc.Close();
                }
            }
        }

        private static void Encabezado(iText.Document doc, string tipo, string numero)
        {
            PdfPTable t = new PdfPTable(2) { WidthPercentage = 100 };
            t.SetWidths(new float[] { 18, 82 });

            iText.Image logo = iText.Image.GetInstance(Properties.Resources.LeMarchant, System.Drawing.Imaging.ImageFormat.Png);
            logo.ScaleToFit(72f, 72f);
            t.AddCell(new PdfPCell(logo) { Border = iText.Rectangle.NO_BORDER, VerticalAlignment = iText.Element.ALIGN_MIDDLE });

            var texto = new PdfPCell { Border = iText.Rectangle.NO_BORDER, VerticalAlignment = iText.Element.ALIGN_MIDDLE };
            texto.AddElement(new iText.Paragraph("Le Marchant", Fuente(22, true, VerdeOscuro)));
            texto.AddElement(new iText.Paragraph("Mercado de barrio · Ciudad Autónoma de Buenos Aires", Fuente(9, false, Gris)));
            texto.AddElement(new iText.Paragraph($"{tipo} N° {numero}", Fuente(13, true, Verde)) { SpacingBefore = 6 });
            t.AddCell(texto);
            doc.Add(t);

            doc.Add(new iText.Chunk(new LineSeparator(2f, 100f, Verde, iText.Element.ALIGN_CENTER, -4f)));
            doc.Add(Espacio(10));
        }

        private static PdfPTable TablaDatos()
        {
            PdfPTable t = new PdfPTable(2) { WidthPercentage = 100 };
            t.SetWidths(new float[] { 22, 78 });
            return t;
        }

        private static void Dato(PdfPTable t, string etiqueta, string valor)
        {
            t.AddCell(new PdfPCell(new iText.Phrase(etiqueta, Fuente(10, true, VerdeOscuro))) { Border = iText.Rectangle.NO_BORDER, PaddingBottom = 4 });
            t.AddCell(new PdfPCell(new iText.Phrase(valor, Fuente(10))) { Border = iText.Rectangle.NO_BORDER, PaddingBottom = 4 });
        }

        private static void Titulos(PdfPTable t, params string[] titulos)
        {
            foreach (string titulo in titulos)
            {
                t.AddCell(new PdfPCell(new iText.Phrase(titulo, Fuente(9, true, iText.BaseColor.WHITE)))
                {
                    BackgroundColor = Verde,
                    BorderColor = Verde,
                    Padding = 5,
                    HorizontalAlignment = iText.Element.ALIGN_CENTER
                });
            }
            t.HeaderRows = 1;
        }

        private static void Celda(PdfPTable t, string texto, iText.BaseColor fondo, int alineacion = 0)
        {
            t.AddCell(new PdfPCell(new iText.Phrase(texto, Fuente(9)))
            {
                BackgroundColor = fondo,
                BorderColor = new iText.BaseColor(200, 230, 201),
                Padding = 4,
                HorizontalAlignment = alineacion
            });
        }

        private static PdfPTable TablaTotales()
        {
            PdfPTable t = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = iText.Element.ALIGN_RIGHT };
            t.SetWidths(new float[] { 55, 45 });
            return t;
        }

        private static void Total(PdfPTable t, string etiqueta, string valor, bool destacado)
        {
            iText.BaseColor fondo = destacado ? Verde : VerdeClaro;
            iText.BaseColor letra = destacado ? iText.BaseColor.WHITE : VerdeOscuro;
            t.AddCell(new PdfPCell(new iText.Phrase(etiqueta, Fuente(destacado ? 11 : 10, true, letra)))
            {
                BackgroundColor = fondo, BorderColor = fondo, Padding = 5
            });
            t.AddCell(new PdfPCell(new iText.Phrase(valor, Fuente(destacado ? 11 : 10, destacado, letra)))
            {
                BackgroundColor = fondo, BorderColor = fondo, Padding = 5, HorizontalAlignment = iText.Element.ALIGN_RIGHT
            });
        }

        private static void Pie(iText.Document doc, DateTime emision)
        {
            doc.Add(Espacio(18));
            doc.Add(new iText.Chunk(new LineSeparator(0.5f, 100f, new iText.BaseColor(200, 230, 201), iText.Element.ALIGN_CENTER, -2f)));
            var pie = new iText.Paragraph($"Emitido el {emision.ToString("dd/MM/yyyy HH:mm", Cultura)} · Documento no válido como factura · ¡Gracias por elegirnos!", Fuente(8, false, Gris))
            {
                Alignment = iText.Element.ALIGN_CENTER,
                SpacingBefore = 6
            };
            doc.Add(pie);
        }

        private static iText.Paragraph Espacio(float alto) => new iText.Paragraph(" ", Fuente(1)) { SpacingAfter = alto };
    }
}

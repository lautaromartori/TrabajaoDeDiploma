using System;
using System.Globalization;

namespace BE.RFN1
{
    public static class FormatoDV
    {
        public static string Fecha(DateTime f) => f.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        public static string FechaHora(DateTime f) => f.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        public static string FechaHora(DateTime? f) => f.HasValue ? FechaHora(f.Value) : "";
        public static string Importe(decimal d) => d.ToString("0.00", CultureInfo.InvariantCulture);
        public static string Entero(int? n) => n.HasValue ? n.Value.ToString(CultureInfo.InvariantCulture) : "";
        public static string Texto(string? s) => s ?? "";
    }
}

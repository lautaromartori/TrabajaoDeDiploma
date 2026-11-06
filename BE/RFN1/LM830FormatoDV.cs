using System;
using System.Globalization;

namespace LM830BE.LM830RFN1
{
    public static class LM830FormatoDV
    {
        public static string LM830Fecha(DateTime LM830f) => LM830f.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        public static string LM830FechaHora(DateTime LM830f) => LM830f.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        public static string LM830FechaHora(DateTime? LM830f) => LM830f.HasValue ? LM830FechaHora(LM830f.Value) : "";
        public static string LM830Importe(decimal LM830d) => LM830d.ToString("0.00", CultureInfo.InvariantCulture);
        public static string LM830Entero(int? LM830n) => LM830n.HasValue ? LM830n.Value.ToString(CultureInfo.InvariantCulture) : "";
        public static string LM830Texto(string? LM830s) => LM830s ?? "";
    }
}

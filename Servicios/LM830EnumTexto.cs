using System;

namespace LM830Servicios
{
    // Los valores de los enum llevan el prefijo LM830 en el código, pero en la base de datos,
    // en los dígitos verificadores y en las claves de traducción se guardan sin prefijo
    // (pendiente, aprobado, venta, ...). Esta clase hace la conversión en los dos sentidos.
    public static class LM830EnumTexto
    {
        private const string LM830Prefijo = "LM830";

        public static string LM830ATexto(this Enum LM830valor)
        {
            string LM830texto = LM830valor.ToString();
            return LM830texto.StartsWith(LM830Prefijo) ? LM830texto.Substring(LM830Prefijo.Length) : LM830texto;
        }

        public static LM830T LM830DesdeTexto<LM830T>(string LM830texto) where LM830T : struct
        {
            return (LM830T)Enum.Parse(typeof(LM830T), LM830Prefijo + LM830texto);
        }
    }
}

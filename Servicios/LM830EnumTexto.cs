using System;

namespace LM830Servicios
{
   
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

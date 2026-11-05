using System;
using System.Collections.Generic;
using System.Text;

namespace LM830Servicios
{
    public class LM830DigitoVerificador
    {
        public static string LM830GetHexa(string LM830texto)
        {
            string LM830hex = string.Concat(LM830texto.Select(LM830c => ((int)LM830c).ToString("X2")));
            return LM830hex;
        }
        public static void LM830RecalcularDV()
        {
        }

        private bool LM830CompararDV(string LM830DVCalculado, string LM830DVOriginal)
        {
            throw new NotImplementedException();
        }

        public static string LM830CalcularDVH(string LM830cadena)
        {
           return LM830cadena = LM830Encriptador.LM830GetHash256(LM830GetHexa(LM830cadena));
        }

        public static string LM830CalcularDVV(List<string> LM830cadena)
        {
            string LM830DVVcolumna = "";
            foreach (var LM830item in LM830cadena)
            {
                LM830DVVcolumna += LM830GetHexa(LM830item);
            }
            return LM830Encriptador.LM830GetHash256(LM830DVVcolumna);
        }
    }
}

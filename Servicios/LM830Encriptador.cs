using System.Security.Cryptography;
using System.Text;

namespace LM830Servicios
{
    public class LM830Encriptador
    {
        public static string LM830GetHash256(string LM830texto)
        {
            using (SHA256 LM830sha256 = SHA256.Create())
            {
                byte[] LM830bytesTexto = Encoding.UTF8.GetBytes(LM830texto);
                byte[] LM830hash = LM830sha256.ComputeHash(LM830bytesTexto);

                StringBuilder LM830sb = new StringBuilder();
                foreach (byte LM830b in LM830hash)
                {
                    LM830sb.Append(LM830b.ToString("x2"));
                }

                return LM830sb.ToString();
            }
        }

        private static readonly string LM830Key = "12345678910111213141516171819202";
        private static readonly string LM830IV = "1234567891011121";

        public static string LM830EncriptarAES(string LM830texto)
        {
            using (Aes LM830aes = Aes.Create())
            {
                LM830aes.Key = Encoding.UTF8.GetBytes(LM830Key);
                LM830aes.IV = Encoding.UTF8.GetBytes(LM830IV);
                ICryptoTransform LM830encriptador = LM830aes.CreateEncryptor();
                byte[] LM830bytesTexto = Encoding.UTF8.GetBytes(LM830texto);
                byte[] LM830bytesEncriptados = LM830encriptador.TransformFinalBlock(LM830bytesTexto, 0, LM830bytesTexto.Length);
                return Convert.ToBase64String(LM830bytesEncriptados);
            }
        }

        public static string LM830DesencriptarAES(string LM830textoEncriptado)
        {
            using (Aes LM830aes = Aes.Create())
            {
                LM830aes.Key = Encoding.UTF8.GetBytes(LM830Key);
                LM830aes.IV = Encoding.UTF8.GetBytes(LM830IV);
                ICryptoTransform LM830desencriptador = LM830aes.CreateDecryptor();
                byte[] LM830bytesEncriptados = Convert.FromBase64String(LM830textoEncriptado);
                byte[] LM830bytesTexto = LM830desencriptador.TransformFinalBlock(LM830bytesEncriptados, 0, LM830bytesEncriptados.Length);
                return Encoding.UTF8.GetString(LM830bytesTexto);
            }
        }
    }
}

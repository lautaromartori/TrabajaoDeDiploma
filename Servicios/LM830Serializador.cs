using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LM830Servicios
{
    public enum LM830FormatoSerializacion
    {
        LM830Xml,
        LM830Json
    }

    public static class LM830Serializador
    {
        public static LM830FormatoSerializacion LM830FormatoDe(string LM830ruta)
        {
            string LM830extension = Path.GetExtension(LM830ruta).ToLowerInvariant();
            if (LM830extension == ".xml") return LM830FormatoSerializacion.LM830Xml;
            if (LM830extension == ".json") return LM830FormatoSerializacion.LM830Json;
            throw new Exception("El archivo debe ser .xml o .json.");
        }

        public static void LM830Serializar<LM830T>(LM830T LM830objeto, string LM830ruta)
        {
            if (LM830objeto == null) throw new ArgumentNullException(nameof(LM830objeto));
            string LM830contenido = LM830FormatoDe(LM830ruta) == LM830FormatoSerializacion.LM830Xml ? LM830AXml(LM830objeto) : LM830AJson(LM830objeto);
            File.WriteAllText(LM830ruta, LM830contenido, new UTF8Encoding(false));
        }

        public static LM830T LM830Deserializar<LM830T>(string LM830ruta)
        {
            if (!File.Exists(LM830ruta)) throw new FileNotFoundException("No se encontró el archivo.", LM830ruta);
            string LM830contenido = File.ReadAllText(LM830ruta, Encoding.UTF8);
            LM830T? LM830objeto = LM830FormatoDe(LM830ruta) == LM830FormatoSerializacion.LM830Xml ? LM830DesdeXml<LM830T>(LM830contenido) : LM830DesdeJson<LM830T>(LM830contenido);
            if (LM830objeto == null) throw new Exception("El archivo está vacío o no tiene el formato esperado.");
            return LM830objeto;
        }

        public static string LM830AXml<LM830T>(LM830T LM830objeto)
        {
            var LM830serializer = new XmlSerializer(typeof(LM830T));
            var LM830opciones = new XmlWriterSettings { Indent = true, Encoding = new UTF8Encoding(false) };
            using (var LM830memoria = new MemoryStream())
            {
                using (XmlWriter LM830writer = XmlWriter.Create(LM830memoria, LM830opciones))
                {
                    LM830serializer.Serialize(LM830writer, LM830objeto);
                }
                return new UTF8Encoding(false).GetString(LM830memoria.ToArray());
            }
        }

        public static LM830T? LM830DesdeXml<LM830T>(string LM830xml)
        {
            var LM830serializer = new XmlSerializer(typeof(LM830T));
            using (var LM830lector = new StringReader(LM830xml))
            {
                try
                {
                    return (LM830T?)LM830serializer.Deserialize(LM830lector);
                }
                catch (InvalidOperationException LM830ex)
                {
                    throw new Exception("El XML no tiene el formato esperado: " + (LM830ex.InnerException?.Message ?? LM830ex.Message), LM830ex);
                }
            }
        }

        public static string LM830AJson<LM830T>(LM830T LM830objeto) =>
            JsonConvert.SerializeObject(LM830objeto, Newtonsoft.Json.Formatting.Indented);

        public static LM830T? LM830DesdeJson<LM830T>(string LM830json)
        {
            try
            {
                return JsonConvert.DeserializeObject<LM830T>(LM830json);
            }
            catch (JsonException LM830ex)
            {
                throw new Exception("El JSON no tiene el formato esperado: " + LM830ex.Message, LM830ex);
            }
        }
    }
}

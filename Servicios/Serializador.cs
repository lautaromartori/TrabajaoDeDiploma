using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Servicios
{
    public enum FormatoSerializacion
    {
        Xml,
        Json
    }

    public static class Serializador
    {
        public static FormatoSerializacion FormatoDe(string ruta)
        {
            string extension = Path.GetExtension(ruta).ToLowerInvariant();
            if (extension == ".xml") return FormatoSerializacion.Xml;
            if (extension == ".json") return FormatoSerializacion.Json;
            throw new Exception("El archivo debe ser .xml o .json.");
        }

        public static void Serializar<T>(T objeto, string ruta)
        {
            if (objeto == null) throw new ArgumentNullException(nameof(objeto));
            string contenido = FormatoDe(ruta) == FormatoSerializacion.Xml ? AXml(objeto) : AJson(objeto);
            File.WriteAllText(ruta, contenido, new UTF8Encoding(false));
        }

        public static T Deserializar<T>(string ruta)
        {
            if (!File.Exists(ruta)) throw new FileNotFoundException("No se encontró el archivo.", ruta);
            string contenido = File.ReadAllText(ruta, Encoding.UTF8);
            T? objeto = FormatoDe(ruta) == FormatoSerializacion.Xml ? DesdeXml<T>(contenido) : DesdeJson<T>(contenido);
            if (objeto == null) throw new Exception("El archivo está vacío o no tiene el formato esperado.");
            return objeto;
        }

        public static string AXml<T>(T objeto)
        {
            var serializer = new XmlSerializer(typeof(T));
            var opciones = new XmlWriterSettings { Indent = true, Encoding = new UTF8Encoding(false) };
            using (var memoria = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(memoria, opciones))
                {
                    serializer.Serialize(writer, objeto);
                }
                return new UTF8Encoding(false).GetString(memoria.ToArray());
            }
        }

        public static T? DesdeXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var lector = new StringReader(xml))
            {
                try
                {
                    return (T?)serializer.Deserialize(lector);
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception("El XML no tiene el formato esperado: " + (ex.InnerException?.Message ?? ex.Message), ex);
                }
            }
        }

        public static string AJson<T>(T objeto) =>
            JsonConvert.SerializeObject(objeto, Newtonsoft.Json.Formatting.Indented);

        public static T? DesdeJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException ex)
            {
                throw new Exception("El JSON no tiene el formato esperado: " + ex.Message, ex);
            }
        }
    }
}

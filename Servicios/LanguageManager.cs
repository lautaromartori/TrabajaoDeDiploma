using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Xml;

namespace LM830Servicios
{
    public class LM830LanguageManager : LM830IObserved
    {
        private List<LM830IObserver> LM830_observers;
        private static LM830LanguageManager LM830_lenguageManager;
        private LM830DefaultLenguage LM830_language;
        private Dictionary<string, string> LM830_jsonidioma;

        public static LM830LanguageManager LM830Instance
        {
            get
            {
                if (LM830_lenguageManager == null) LM830_lenguageManager = new LM830LanguageManager();
                return LM830_lenguageManager;
            }
        }
        public string LM830CodigoIdiomaActual
        {
            get
            {
                if (LM830_language == null)
                    return "es";

                return LM830_language.LM830Idioma;
            }
        }

        private LM830LanguageManager()
        {
            LM830_observers = new List<LM830IObserver>();
        }

        public void LM830AgregarObservador(LM830IObserver LM830observable)
        {
            LM830_observers.Add(LM830observable);
        }

        public void LM830EliminarObservador(LM830IObserver LM830observable)
        {
            LM830_observers.Remove(LM830observable);
        }

        public void LM830NotificarObservadores()
        {
            foreach (LM830IObserver LM830item in LM830_observers)
            {
                LM830item.LM830Actualizar(this);
            }
        }

        public CultureInfo LM830GetCurrentLanguage()
        {
            if (LM830_language == null)
                return new CultureInfo("es");

            return new CultureInfo(
                LM830_language.LM830Idioma);
        }

        public string LM830GetTraduction(string LM830key)
        {
            if (LM830_jsonidioma == null)
                return LM830key;

            if (!LM830_jsonidioma.ContainsKey(LM830key))
                return LM830key;

            return LM830_jsonidioma[LM830key];
        }

        private string LM830GetJsonRute(string LM830name)
        {
            string LM830directory = AppDomain.CurrentDomain.BaseDirectory;
            string LM830jsonruta = Path.Combine(LM830directory, "Idiomas", $"{LM830name}.json");
            return LM830jsonruta;
        }
        public void LM830CargarIdioma(string LM830codigoIdioma)
        {
            string LM830readjson =File.ReadAllText(LM830GetJsonRute(LM830codigoIdioma));

            LM830_jsonidioma =JsonConvert.DeserializeObject<Dictionary<string, string>>(LM830readjson);

            LM830_language = new LM830DefaultLenguage
            {
                LM830Idioma = LM830codigoIdioma
            };

            LM830NotificarObservadores();
        }
    }
}

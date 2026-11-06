using System;
using System.Collections.Generic;
using System.Text;

namespace LM830Servicios
{
    public interface LM830IObserver
    {
        void LM830Actualizar(LM830LanguageManager LM830lenguaje);
    }
}

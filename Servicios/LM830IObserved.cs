using System;
using System.Collections.Generic;
using System.Text;

namespace LM830Servicios
{
    public interface LM830IObserved
    {
        void LM830NotificarObservadores();
        void LM830AgregarObservador(LM830IObserver LM830observable);
        void LM830EliminarObservador(LM830IObserver LM830observable);
    }
}

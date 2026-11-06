using System;
using System.Collections.Generic;
using System.Text;

namespace LM830Servicios
{
    public enum LM830LoginResultado
    {
        LM830ContraseñaIncorrecta,
        LM830UsuarioNoEncontrado,
        LM830Valido,
        LM830Bloqueado,
        LM830Error,
        LM830ContraseñaIguales,
        LM830Inactivo,
    }
}

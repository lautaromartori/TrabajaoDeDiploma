using LM830BE.LM830RFN1;
using System;

namespace LM830BLL.LM830RFN1
{
    public class LM830ClienteExistenteException : Exception
    {
        public LM830Cliente LM830Cliente { get; }

        public LM830ClienteExistenteException(LM830Cliente LM830cliente)
            : base($"El DNI {LM830cliente.LM830Dni} ya está registrado ({LM830cliente.LM830NombreCompleto}).")
        {
            LM830Cliente = LM830cliente;
        }
    }
}

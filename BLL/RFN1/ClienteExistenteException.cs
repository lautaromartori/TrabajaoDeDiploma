using BE.RFN1;
using System;

namespace BLL.RFN1
{
    
    public class ClienteExistenteException : Exception
    {
        public Cliente Cliente { get; }

        public ClienteExistenteException(Cliente cliente)
            : base($"El DNI {cliente.Dni} ya está registrado ({cliente.NombreCompleto}).")
        {
            Cliente = cliente;
        }
    }
}

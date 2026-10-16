using BE.RFN1;
using System;

namespace BLL.RFN1
{
    // Flujo alternativo 4.1 de CU-N01-001: el DNI ya está registrado. Lleva el cliente para mostrarlo.
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

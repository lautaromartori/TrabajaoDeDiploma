using BE.RFN1;
using DAL.RFN1;
using Servicios;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BLL.RFN1
{
    public class ClienteBLL
    {
        private const string MODULO = "Clientes";

        private readonly ClienteDAL _clienteDAL = new ClienteDAL();
        private readonly NivelBLL _nivelBLL = new NivelBLL();
        private readonly BitacoraBLL _bitacoraBLL = new BitacoraBLL();
        private readonly DigitoVerificadorBLL _digitoVerificadorBLL = new DigitoVerificadorBLL();

        // Mensajes del último ValidarDatos (campos a corregir, flujo 3.1).
        public List<string> ErroresValidacion { get; } = new List<string>();

        // CU-N01-001 Registrar cliente
        public void Registrar(Cliente c)
        {
            if (!ValidarDatos(c))
                throw new Exception(string.Join(Environment.NewLine, ErroresValidacion));

            if (_clienteDAL.ExisteDni(c.Dni))
                throw new ClienteExistenteException(_clienteDAL.Obtener(c.Dni)!);

            c.Nivel = _nivelBLL.ObtenerInicial();
            c.FechaInscripcion = DateTime.Today;

            _clienteDAL.Insertar(c);
            _digitoVerificadorBLL.RecalcularDVV_Cliente();

            RegistrarEvento($"Registrar cliente DNI {c.Dni}", 1);
        }

        public bool ValidarDatos(Cliente c)
        {
            ErroresValidacion.Clear();
            c.Dni = (c.Dni ?? "").Trim();
            c.Nombre = (c.Nombre ?? "").Trim();
            c.Apellido = (c.Apellido ?? "").Trim();
            c.Email = (c.Email ?? "").Trim();
            c.Telefono = (c.Telefono ?? "").Trim();

            if (!Regex.IsMatch(c.Dni, @"^\d{7,8}$"))
                ErroresValidacion.Add("DNI: debe tener 7 u 8 números, sin puntos.");
            if (!Regex.IsMatch(c.Nombre, @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' ]{2,50}$"))
                ErroresValidacion.Add("Nombre: obligatorio, solo letras (2 a 50).");
            if (!Regex.IsMatch(c.Apellido, @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' ]{2,50}$"))
                ErroresValidacion.Add("Apellido: obligatorio, solo letras (2 a 50).");
            if (c.Email.Length > 100 || !Regex.IsMatch(c.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                ErroresValidacion.Add("Email: obligatorio, con formato nombre@dominio.com.");
            if (c.Telefono.Length > 0 && !Regex.IsMatch(c.Telefono, @"^[0-9+\- ]{6,20}$"))
                ErroresValidacion.Add("Teléfono: solo números, espacios, + o - (6 a 20).");

            return ErroresValidacion.Count == 0;
        }

        // null = el cliente no está inscripto.
        public Cliente? Buscar(string dni)
        {
            return _clienteDAL.Obtener((dni ?? "").Trim());
        }

        private void RegistrarEvento(string evento, int criticidad)
        {
            try
            {
                _bitacoraBLL.RegistrarEvento(new Bitacora
                {
                    Login = SessionManager.Instance.UsuarioActual().Username,
                    Modulo = MODULO,
                    Evento = evento,
                    Criticidad = criticidad
                });
            }
            catch { }
        }
    }
}

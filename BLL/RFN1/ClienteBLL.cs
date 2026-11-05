using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LM830BLL.LM830RFN1
{
    public class LM830ClienteBLL
    {
        private const string LM830MODULO = "Clientes";

        private readonly LM830ClienteDAL LM830_clienteDAL = new LM830ClienteDAL();
        private readonly LM830NivelBLL LM830_nivelBLL = new LM830NivelBLL();
        private readonly LM830DigitoVerificadorBLL LM830_digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

        public List<string> LM830ErroresValidacion { get; } = new List<string>();

        public void LM830Registrar(LM830Cliente LM830c)
        {
            if (!LM830ValidarDatos(LM830c))
                throw new Exception(string.Join(Environment.NewLine, LM830ErroresValidacion));

            if (LM830_clienteDAL.LM830ExisteDni(LM830c.LM830Dni))
                throw new LM830ClienteExistenteException(LM830_clienteDAL.LM830Obtener(LM830c.LM830Dni)!);

            LM830c.LM830Nivel = LM830_nivelBLL.LM830ObtenerInicial();
            LM830c.LM830FechaInscripcion = DateTime.Today;

            LM830_clienteDAL.LM830Insertar(LM830c);
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Cliente();
        }

        public bool LM830ValidarDatos(LM830Cliente LM830c)
        {
            LM830ErroresValidacion.Clear();
            LM830c.LM830Dni = (LM830c.LM830Dni ?? "").Trim();
            LM830c.LM830Nombre = (LM830c.LM830Nombre ?? "").Trim();
            LM830c.LM830Apellido = (LM830c.LM830Apellido ?? "").Trim();
            LM830c.LM830Email = (LM830c.LM830Email ?? "").Trim();
            LM830c.LM830Telefono = (LM830c.LM830Telefono ?? "").Trim();

            if (!Regex.IsMatch(LM830c.LM830Dni, @"^\d{7,8}$"))
                LM830ErroresValidacion.Add("DNI: debe tener 7 u 8 números, sin puntos.");
            if (!Regex.IsMatch(LM830c.LM830Nombre, @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' ]{2,50}$"))
                LM830ErroresValidacion.Add("Nombre: obligatorio, solo letras (2 a 50).");
            if (!Regex.IsMatch(LM830c.LM830Apellido, @"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' ]{2,50}$"))
                LM830ErroresValidacion.Add("Apellido: obligatorio, solo letras (2 a 50).");
            if (LM830c.LM830Email.Length > 100 || !Regex.IsMatch(LM830c.LM830Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                LM830ErroresValidacion.Add("Email: obligatorio, con formato nombre@dominio.com.");
            if (LM830c.LM830Telefono.Length > 0 && !Regex.IsMatch(LM830c.LM830Telefono, @"^[0-9+\- ]{6,20}$"))
                LM830ErroresValidacion.Add("Teléfono: solo números, espacios, + o - (6 a 20).");

            return LM830ErroresValidacion.Count == 0;
        }

        public LM830Cliente? LM830Buscar(string LM830dni)
        {
            return LM830_clienteDAL.LM830Obtener((LM830dni ?? "").Trim());
        }
    }
}

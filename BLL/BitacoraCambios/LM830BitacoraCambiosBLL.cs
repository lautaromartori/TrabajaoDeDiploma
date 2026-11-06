using LM830BE.LM830BitacoraCambios;
using LM830BE.LM830RFN1;
using LM830DAL.LM830BitacoraCambios;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830BLL.LM830BitacoraCambios
{
    // Bitácora de cambios de la tabla maestra Cliente.
    // El historial lo escriben los triggers de la base; acá se consulta y se restaura una versión.
    public class LM830BitacoraCambiosBLL
    {
        private readonly LM830BitacoraCambiosDAL LM830_dal = new LM830BitacoraCambiosDAL();
        private readonly LM830DigitoVerificadorBLL LM830_digitoVerificadorBLL = new LM830DigitoVerificadorBLL();

        public List<LM830BitacoraCambioCliente> LM830ListarClientes(string? LM830dni, DateTime LM830desde, DateTime LM830hasta)
        {
            LM830ValidarFechas(LM830desde, LM830hasta);
            return LM830_dal.LM830ListarClientes(LM830dni, LM830desde, LM830hasta);
        }

        public void LM830RestaurarCliente(LM830BitacoraCambioCliente LM830version)
        {
            if (LM830version.LM830Activo) throw new Exception("La versión elegida ya es la vigente.");

            // El DVH del cliente se recalcula con los datos que vuelven.
            var LM830cliente = new LM830Cliente
            {
                LM830IdCliente = LM830version.LM830IdCliente,
                LM830Dni = LM830version.LM830Dni,
                LM830Nombre = LM830version.LM830Nombre,
                LM830Apellido = LM830version.LM830Apellido,
                LM830Email = LM830version.LM830Email,
                LM830Telefono = LM830version.LM830Telefono,
                LM830FechaInscripcion = LM830version.LM830FechaInscripcion,
                LM830Nivel = new LM830Nivel { LM830IdNivel = LM830version.LM830IdNivel }
            };
            string LM830dvh = LM830DigitoVerificador.LM830CalcularDVH(LM830cliente.LM830CadenaDVH());

            LM830_dal.LM830RestaurarCliente(LM830version, LM830dvh);
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Cliente();
        }

        private static void LM830ValidarFechas(DateTime LM830desde, DateTime LM830hasta)
        {
            if (LM830desde.Date > LM830hasta.Date) throw new Exception("La fecha desde no puede ser posterior a la fecha hasta.");
        }
    }
}

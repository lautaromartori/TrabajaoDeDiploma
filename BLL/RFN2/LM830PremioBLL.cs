using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN1;
using LM830DAL.LM830RFN2;
using System;
using System.Collections.Generic;

namespace LM830BLL.LM830RFN2
{
    public class LM830PremioBLL
    {
        private readonly LM830PremioDAL LM830_premioDAL = new LM830PremioDAL();

        public List<LM830Premio> LM830Listar() => LM830_premioDAL.LM830Listar();

        public List<LM830Premio> LM830ListarCanjeables(int LM830saldoDisponible) =>
            LM830saldoDisponible <= 0 ? new List<LM830Premio>() : LM830_premioDAL.LM830ListarCanjeables(LM830saldoDisponible);

        public LM830Premio? LM830Obtener(int LM830idPremio) => LM830_premioDAL.LM830Obtener(LM830idPremio);

        public bool LM830RequiereAutorizacion(LM830Premio LM830p) =>
            LM830p.LM830ValorReferencia > LM830ProgramaPuntosBLL.LM830Obtener().LM830UmbralAutorizacion;

        public void LM830Agregar(LM830Premio LM830p)
        {
            LM830Validar(LM830p);
            LM830_premioDAL.LM830Insertar(LM830p);
        }

        public void LM830Modificar(LM830Premio LM830p)
        {
            LM830Validar(LM830p);
            LM830_premioDAL.LM830Modificar(LM830p);
        }

        public void LM830Eliminar(LM830Premio LM830p) => LM830_premioDAL.LM830Eliminar(LM830p.LM830IdPremio);

        private static void LM830Validar(LM830Premio LM830p)
        {
            LM830p.LM830Nombre = (LM830p.LM830Nombre ?? "").Trim();
            LM830p.LM830Descripcion = (LM830p.LM830Descripcion ?? "").Trim();
            if (LM830p.LM830Nombre.Length == 0)
                throw new Exception("Complete el nombre del premio.");
            if (LM830p.LM830Nombre.Length > 100)
                throw new Exception("El nombre no puede superar los 100 caracteres.");
            if (LM830p.LM830Descripcion.Length > 200)
                throw new Exception("La descripción no puede superar los 200 caracteres.");
            if (LM830p.LM830PuntosRequeridos <= 0)
                throw new Exception("Los puntos requeridos tienen que ser mayores a cero.");
            if (LM830p.LM830Stock < 0)
                throw new Exception("El stock no puede ser negativo.");
            if (LM830p.LM830ValorReferencia < 0)
                throw new Exception("El valor de referencia no puede ser negativo.");
        }
    }
}

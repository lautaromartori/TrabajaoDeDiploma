using BE.RFN2;
using BLL.RFN1;
using DAL.RFN2;
using System.Collections.Generic;

namespace BLL.RFN2
{
    public class PremioBLL
    {
        private readonly PremioDAL _premioDAL = new PremioDAL();

        public List<Premio> Listar() => _premioDAL.Listar();

        public List<Premio> ListarCanjeables(int saldoDisponible) =>
            saldoDisponible <= 0 ? new List<Premio>() : _premioDAL.ListarCanjeables(saldoDisponible);

        public Premio? Obtener(int idPremio) => _premioDAL.Obtener(idPremio);

        public bool RequiereAutorizacion(Premio p) =>
            p.ValorReferencia > ProgramaPuntosBLL.Obtener().UmbralAutorizacion;
    }
}

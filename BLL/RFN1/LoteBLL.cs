using BE.RFN1;
using DAL.RFN1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.RFN1
{
    public class LoteBLL
    {
        private readonly LoteDAL _loteDAL = new LoteDAL();

        // CU-N01-002 Consultar saldo. El saldo no se guarda: se calcula con los lotes no vencidos.
        public int ConsultarSaldo(Cliente c)
        {
            return ConsultarSaldo(c, out _);
        }

        // Igual que ConsultarSaldo(c) pero devuelve también los lotes vigentes para la grilla de frmSaldo.
        public int ConsultarSaldo(Cliente c, out List<LotePuntos> lotesVigentes)
        {
            List<LotePuntos> lotes = _loteDAL.ObtenerPorCliente(c.IdCliente);
            lotesVigentes = DescartarVencidos(lotes);
            return CalcularSaldo(lotesVigentes);
        }

        public List<LotePuntos> DescartarVencidos(List<LotePuntos> l)
        {
            return l.Where(x => x.FechaVencimiento.Date >= DateTime.Today && x.PuntosDisponibles > 0)
                    .OrderBy(x => x.FechaVencimiento)
                    .ToList();
        }

        public int CalcularSaldo(List<LotePuntos> l)
        {
            return l.Sum(x => x.PuntosDisponibles);
        }
    }
}

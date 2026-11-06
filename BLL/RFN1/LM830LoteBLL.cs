using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LM830BLL.LM830RFN1
{
    public class LM830LoteBLL
    {
        private readonly LM830LoteDAL LM830_loteDAL = new LM830LoteDAL();

        public int LM830ConsultarSaldo(LM830Cliente LM830c)
        {
            return LM830ConsultarSaldo(LM830c, out _);
        }

        public int LM830ConsultarSaldo(LM830Cliente LM830c, out List<LM830LotePuntos> LM830lotesVigentes)
        {
            List<LM830LotePuntos> LM830lotes = LM830_loteDAL.LM830ObtenerPorCliente(LM830c.LM830IdCliente);
            LM830lotesVigentes = LM830DescartarVencidos(LM830lotes);
            return LM830CalcularSaldo(LM830lotesVigentes);
        }

        public List<LM830LotePuntos> LM830DescartarVencidos(List<LM830LotePuntos> LM830l)
        {
            return LM830l.Where(LM830x => LM830x.LM830FechaVencimiento.Date >= DateTime.Today && LM830x.LM830PuntosDisponibles > 0)
                    .OrderBy(LM830x => LM830x.LM830FechaVencimiento)
                    .ToList();
        }

        public int LM830CalcularSaldo(List<LM830LotePuntos> LM830l)
        {
            return LM830l.Sum(LM830x => LM830x.LM830PuntosDisponibles);
        }
    }
}

using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;
using System;
using System.Linq;

namespace LM830BLL.LM830RFN1
{
    public class LM830NivelBLL
    {
        private readonly LM830NivelDAL LM830_nivelDAL = new LM830NivelDAL();
        private readonly LM830LoteDAL LM830_loteDAL = new LM830LoteDAL();

        public LM830Nivel LM830ObtenerInicial() => LM830_nivelDAL.LM830ObtenerInicial();

        internal LM830Nivel LM830CalcularNivel(LM830Cliente LM830c, int LM830puntosNuevos)
        {
            DateTime LM830desde = DateTime.Today.AddMonths(-12);
            int LM830puntos12Meses = LM830_loteDAL.LM830ObtenerPorCliente(LM830c.LM830IdCliente)
                                        .Where(LM830l => LM830l.LM830FechaAcreditacion >= LM830desde)
                                        .Sum(LM830l => LM830l.LM830PuntosOriginales) + LM830puntosNuevos;

            LM830Nivel? LM830nivel = LM830ProgramaPuntosBLL.LM830Obtener().LM830Niveles
                                .Where(LM830n => LM830n.LM830PuntosMinimos <= LM830puntos12Meses)
                                .OrderByDescending(LM830n => LM830n.LM830PuntosMinimos)
                                .FirstOrDefault();

            return LM830nivel ?? LM830ObtenerInicial();
        }
    }
}

using BE.RFN1;
using DAL.RFN1;
using System;
using System.Linq;

namespace BLL.RFN1
{
    public class NivelBLL
    {
        private readonly NivelDAL _nivelDAL = new NivelDAL();
        private readonly LoteDAL _loteDAL = new LoteDAL();

        public Nivel ObtenerInicial() => _nivelDAL.ObtenerInicial();

        internal Nivel CalcularNivel(Cliente c, int puntosNuevos)
        {
            DateTime desde = DateTime.Today.AddMonths(-12);
            int puntos12Meses = _loteDAL.ObtenerPorCliente(c.IdCliente)
                                        .Where(l => l.FechaAcreditacion >= desde)
                                        .Sum(l => l.PuntosOriginales) + puntosNuevos;

            Nivel? nivel = ProgramaPuntosBLL.Obtener().Niveles
                                .Where(n => n.PuntosMinimos <= puntos12Meses)
                                .OrderByDescending(n => n.PuntosMinimos)
                                .FirstOrDefault();

            return nivel ?? ObtenerInicial();
        }
    }
}

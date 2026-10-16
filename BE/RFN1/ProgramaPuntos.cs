using System;
using System.Collections.Generic;

namespace BE.RFN1
{
    
    public class ProgramaPuntos
    {
        private int idPrograma;
        private string nombre = "";
        private decimal montoPorPunto;
        private int mesesVencimiento;
        private int plazoReclamoDias;
        private DateTime vigenciaDesde;
        private List<Nivel> niveles = new List<Nivel>();

        public int IdPrograma { get => idPrograma; set => idPrograma = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal MontoPorPunto { get => montoPorPunto; set => montoPorPunto = value; }
        public int MesesVencimiento { get => mesesVencimiento; set => mesesVencimiento = value; }
        public int PlazoReclamoDias { get => plazoReclamoDias; set => plazoReclamoDias = value; }
        public DateTime VigenciaDesde { get => vigenciaDesde; set => vigenciaDesde = value; }
        public List<Nivel> Niveles { get => niveles; set => niveles = value; }
    }
}

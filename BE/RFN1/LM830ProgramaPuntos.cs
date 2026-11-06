using System;
using System.Collections.Generic;

namespace LM830BE.LM830RFN1
{
    public class LM830ProgramaPuntos
    {
        private int LM830idPrograma;
        private string LM830nombre = "";
        private decimal LM830montoPorPunto;
        private int LM830mesesVencimiento;
        private int LM830plazoReclamoDias;
        private DateTime LM830vigenciaDesde;
        private decimal LM830umbralAutorizacion;
        private int LM830plazoAnulacionDias;
        private List<LM830Nivel> LM830niveles = new List<LM830Nivel>();

        public int LM830IdPrograma { get => LM830idPrograma; set => LM830idPrograma = value; }
        public string LM830Nombre { get => LM830nombre; set => LM830nombre = value; }
        public decimal LM830MontoPorPunto { get => LM830montoPorPunto; set => LM830montoPorPunto = value; }
        public int LM830MesesVencimiento { get => LM830mesesVencimiento; set => LM830mesesVencimiento = value; }
        public int LM830PlazoReclamoDias { get => LM830plazoReclamoDias; set => LM830plazoReclamoDias = value; }
        public DateTime LM830VigenciaDesde { get => LM830vigenciaDesde; set => LM830vigenciaDesde = value; }
        public decimal LM830UmbralAutorizacion { get => LM830umbralAutorizacion; set => LM830umbralAutorizacion = value; }
        public int LM830PlazoAnulacionDias { get => LM830plazoAnulacionDias; set => LM830plazoAnulacionDias = value; }
        public List<LM830Nivel> LM830Niveles { get => LM830niveles; set => LM830niveles = value; }
    }
}

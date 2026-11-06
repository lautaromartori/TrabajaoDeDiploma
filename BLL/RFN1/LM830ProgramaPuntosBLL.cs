using LM830BE.LM830RFN1;
using LM830DAL.LM830RFN1;

namespace LM830BLL.LM830RFN1
{
    public static class LM830ProgramaPuntosBLL
    {
        private static LM830ProgramaPuntos? LM830_actual;

        public static LM830ProgramaPuntos LM830Obtener()
        {
            if (LM830_actual == null) LM830Cargar();
            return LM830_actual!;
        }

        public static void LM830Cargar()
        {
            LM830ProgramaPuntos LM830programa = new LM830ProgramaPuntosDAL().LM830ObtenerVigente();
            LM830programa.LM830Niveles = new LM830NivelDAL().LM830Listar();
            LM830_actual = LM830programa;
        }
    }
}

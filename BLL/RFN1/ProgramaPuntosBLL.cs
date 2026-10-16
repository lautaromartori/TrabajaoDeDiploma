using BE.RFN1;
using DAL.RFN1;

namespace BLL.RFN1
{
    // Precondición de los CU del RFN1: "los parámetros del programa de puntos están cargados".
    // ProgramaPuntos y sus niveles se leen una sola vez y quedan en memoria; por eso VentaBLL y ReclamoBLL
    // calculan puntos, vencimientos y niveles sin volver a la base.
    public static class ProgramaPuntosBLL
    {
        private static ProgramaPuntos? _actual;

        public static ProgramaPuntos Obtener()
        {
            if (_actual == null) Cargar();
            return _actual!;
        }

        public static void Cargar()
        {
            ProgramaPuntos programa = new ProgramaPuntosDAL().ObtenerVigente();
            programa.Niveles = new NivelDAL().Listar();
            _actual = programa;
        }
    }
}

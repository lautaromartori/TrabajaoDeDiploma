using BE.RFN1;
using DAL.RFN1;

namespace BLL.RFN1
{
    
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

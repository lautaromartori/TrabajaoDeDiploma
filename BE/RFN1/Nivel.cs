namespace BE.RFN1
{
    public class Nivel
    {
        private int idNivel;
        private string nombre = "";
        private int puntosMinimos;
        private decimal multiplicador;

        public int IdNivel { get => idNivel; set => idNivel = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int PuntosMinimos { get => puntosMinimos; set => puntosMinimos = value; }
        public decimal Multiplicador { get => multiplicador; set => multiplicador = value; }

        public override string ToString() => Nombre;
    }
}

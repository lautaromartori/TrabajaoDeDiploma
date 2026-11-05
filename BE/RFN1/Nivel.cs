namespace LM830BE.LM830RFN1
{
    public class LM830Nivel
    {
        private int LM830idNivel;
        private string LM830nombre = "";
        private int LM830puntosMinimos;
        private decimal LM830multiplicador;

        public int LM830IdNivel { get => LM830idNivel; set => LM830idNivel = value; }
        public string LM830Nombre { get => LM830nombre; set => LM830nombre = value; }
        public int LM830PuntosMinimos { get => LM830puntosMinimos; set => LM830puntosMinimos = value; }
        public decimal LM830Multiplicador { get => LM830multiplicador; set => LM830multiplicador = value; }

        public override string ToString() => LM830Nombre;
    }
}

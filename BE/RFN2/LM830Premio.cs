namespace LM830BE.LM830RFN2
{
    public class LM830Premio
    {
        private int LM830idPremio;
        private string LM830nombre = "";
        private string LM830descripcion = "";
        private int LM830puntosRequeridos;
        private int LM830stock;
        private decimal LM830valorReferencia;

        public int LM830IdPremio { get => LM830idPremio; set => LM830idPremio = value; }
        public string LM830Nombre { get => LM830nombre; set => LM830nombre = value; }
        public string LM830Descripcion { get => LM830descripcion; set => LM830descripcion = value; }
        public int LM830PuntosRequeridos { get => LM830puntosRequeridos; set => LM830puntosRequeridos = value; }
        public int LM830Stock { get => LM830stock; set => LM830stock = value; }
        public decimal LM830ValorReferencia { get => LM830valorReferencia; set => LM830valorReferencia = value; }

        public override string ToString() => LM830Nombre;
    }
}

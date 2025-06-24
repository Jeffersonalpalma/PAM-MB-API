namespace PAM_MB_APP.Models
{
    public class MusicoInstrumento
    {
        public int MusicoId { get; set; }
        public int InstrumentoId { get; set; }
        public Instrumento? instrumento { get; set; }
    }
}

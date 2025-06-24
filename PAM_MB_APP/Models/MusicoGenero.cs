namespace PAM_MB_APP.Models
{
    public class MusicoGenero
    {
        public int MusicoId { get; set; }
        public int GeneroId { get; set; }
        public Genero? genero { get; set; }
    }
}

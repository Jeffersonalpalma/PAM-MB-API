namespace PAM_MB_API.Models
{
    public class MusicoDTO
    {
        public int UsuarioId { get; set; }
        public string Apelido { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<int> InstrumentosIds { get; set; } = new();
        public List<int> GenerosIds { get; set; } = new();
        public string Classe { get; set; } = "Musico";
        public byte[]? FotoPerfil { get; set; }
    }
}

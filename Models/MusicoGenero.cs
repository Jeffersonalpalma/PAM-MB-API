using System.Text.Json.Serialization;

namespace PAM_MB_API.Models
{
    public class MusicoGenero
    {
        public int MusicoId { get; set; }
        [JsonIgnore]
        public Musico? musico { get; set; } = null!;
        public int GeneroId { get; set; }
        public Genero? genero { get; set; } = null!;
    }
}
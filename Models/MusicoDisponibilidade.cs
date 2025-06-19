using System.Text.Json.Serialization;

namespace PAM_MB_API.Models
{
    public class MusicoDisponibilidade
    {
        public int MusicoId { get; set; }
        [JsonIgnore]
        public Musico? musico { get; set; } = null!;
        public int DisponibilidadeId { get; set; }
        public Disponibilidade? disponibilidade { get; set; } = null!;
    }
}
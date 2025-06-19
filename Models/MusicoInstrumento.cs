using System.Text.Json.Serialization;

namespace PAM_MB_API.Models
{
    public class MusicoInstrumento
    {
        public int MusicoId { get; set; }
        [JsonIgnore]
        public Musico? musico { get; set; } = null!;
        public int InstrumentoId { get; set; }
        public Instrumento? instrumento { get; set; } = null!;
    }
}
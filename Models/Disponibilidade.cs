

using System.Text.Json.Serialization;

namespace PAM_MB_API.Models
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public DateOnly? Data { get; set; }
        public TimeOnly Hora { get; set; }
        [JsonIgnore]
        public List<MusicoDisponibilidade> musicodisponibilidade { get; set; } = [];
    }


}
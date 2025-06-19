using System.Text.Json.Serialization;

namespace PAM_MB_API.Models
{
    public class Genero
    {
        public string Nome { get; set; } = string.Empty;
        public int Id { get; set; }
        [JsonIgnore]
        public List<MusicoGenero> musicogenero { get; set; } = [];
    }


}
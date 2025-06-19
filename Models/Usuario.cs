using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PAM_MB_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Musico? Musico { get; set; }= null!;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        
        public DateTime? DataCriacao { get; set; }
        public byte[]? FotoPerfil { get; set; }

    }


}
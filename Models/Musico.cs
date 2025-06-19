using System.Text.Json.Serialization;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Models
{
    public class Musico
    {
        public int UsuarioId { get; set; }
        public int Id { get; set; }
        public Usuario? Usuario { get; set; } = null!;
        public string Apelido { get; set; } = string.Empty;
        public string Cpf { get; set; }= string.Empty;
        public ClasseEnum Classe { get; set; }
        public List<MusicoInstrumento> musicoinstrumento { get; set; } = [];
        public List<MusicoGenero> musicogenero { get; set; } = [];
        public List<MusicoDisponibilidade> musicodisponibilidade { get; set; }= [];
    }


}
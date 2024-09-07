using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgroCare.Model
{
    [Table("T_AGROCARE_VETERINARIO")]
    public class Veterinario
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NumCrmv { get; set; }
        [Required]
        public string Especialidade { get; set; }
        [Required]
        public long Telefone { get; set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public ICollection<Consulta> Consultas { get; set; }

    }
}

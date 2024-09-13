using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgroCare.Model
{
    [Table("T_AGROCARE_AGROPECUARISTA")]
    public class User
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public long Number { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public int NumerosAnimais { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public bool Status { get; set; } = true;

        // Relacionamento
        [Required]
        [JsonIgnore]
        public ICollection<Boi> Bois { get; set; }

        [Required]
        public Planos Planos { get; set; }

        public static implicit operator List<object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}


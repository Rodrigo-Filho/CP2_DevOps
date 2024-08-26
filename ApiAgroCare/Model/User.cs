using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgroCare.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public long ID {  get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public long Number {  get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Fotourl { get; set; } = string.Empty ;
        [Required]
        public bool Status {  get; set; } = true;
        [Required]
        public List<Boi> Bois { get; set; } = new List<Boi>();
        [Required]
        public Planos planos { get; set; }

    }
}

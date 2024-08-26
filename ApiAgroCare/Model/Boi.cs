using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgroCare.Model
{
    [Table("Bovino")]
    public class Boi
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public double Saude { get; set; }
        [Required]
        public DateTime UltimoDiaAtualizacao { get; set; }
        [Required]
        public SaudeBoi SaudeBoi { get; set; }
        [Required]
        [ForeignKey("UserID")]
        public User UserDono { get; set; }
        [Required]
        public long UserID { get; set; }
    }
}

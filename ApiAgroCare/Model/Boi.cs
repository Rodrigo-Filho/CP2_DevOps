using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgroCare.Model
{
    [Table("T_AGROCARE_BOVINO")]
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

        // Relacionamentos
        [Required]
        [ForeignKey("UserID")]
        public User UserDono { get; set; }
        public long UserID { get; set; }

        [Required]
        [ForeignKey("ConsultaID")]
        public Consulta Consultas { get; set; }
        public long ConsultaID { get; set; }
    }
}

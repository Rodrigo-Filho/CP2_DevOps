using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public User UserDono { get; set; }   // Associação com User (muitos bois para um usuário)
        public long UserID { get; set; }

        [ForeignKey("ConsultaID")]
        public Consulta? Consultas { get; set; }  // Um boi pode ter uma consulta opcional
        public long? ConsultaID { get; set; }
    }
}


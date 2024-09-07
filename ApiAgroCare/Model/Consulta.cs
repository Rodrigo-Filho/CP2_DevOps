using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApiAgroCare.Model.Avaliacoes;

namespace ApiAgroCare.Model
{
    [Table("T_AGROCARE_CONSULTAS")]
    public class Consulta
        
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Observacao { get; set; }

        [Required]
        public DateTime DataConsulta { get; set; }

        // Relacionamentos
        [Required]
        public Boi Boi { get; set; }
        public long IdBoi { get; set; }

        [Required]
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public long IdUser { get; set; }

        [Required]
        [ForeignKey("IdVeterinario")]
        public Veterinario Veterinario { get; set; }
        public long IdVeterinario { get; set; }

        public AgrocareAvaliacao Avaliacoes { get; set; }


    }
}

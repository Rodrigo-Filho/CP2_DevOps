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


        public Boi Boi { get; set; }   // Associação com Boi (muitos-para-um)
        public long IdBoi { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }  // Associação com User (muitos-para-um)
        public long IdUser { get; set; }

        [Required]
        [ForeignKey("IdVeterinario")]
        public Veterinario Veterinario { get; set; }  // Associação com Veterinário (muitos-para-um)
        public long IdVeterinario { get; set; }

        public Avaliacoes Avaliacoes { get; set; }
    


}
}

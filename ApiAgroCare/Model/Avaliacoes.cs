using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgroCare.Model
{
    [Table("T_AGROCARE_AVALIACOES")]
    public class Avaliacoes
    {
            [Key]
            public long IdAvaliacoes { get; set; }

            [Range(1, 5, ErrorMessage = "A quantidade de estrelas deve ser entre 1 e 5.")]
            public int QtdEstrelas { get; set; }

            public string MsgAvaliacao { get; set; }
            public DateTime DataAvaliacao { get; set; }

            // Relacionamentos
            [Required]
            [ForeignKey("ConsultaID")]
            [JsonIgnore]
            public Consulta Consulta { get; set; }
            public long ConsultaID { get; set; }

            [Required]
            [ForeignKey("VeterinarioID")]
            public Veterinario Veterinario { get; set; }
            public long VeterinarioID { get; set; }

            [Required]
            [ForeignKey("UserID")]
            public User User { get; set; }
            public long UserID { get; set; }
        
    }
}

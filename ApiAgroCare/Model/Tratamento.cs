using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgroCare.Model
{
    [Table("T_AGROCARE_TRATAMENTO")]
    public class Tratamento
    { 
    [Key]
    public long IdTratamento { get; set; }

    public string TipoTratamento { get; set; }
    public string NomeMedicamento { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal DoseMedicamentoML { get; set; }
    public string DescricaoTratamento { get; set; }
    public string ViaAdministracao { get; set; }
    public int DuracaoTratamento { get; set; }
    public string EfeitoTratamento { get; set; }
    public string ObservacaoTratamento { get; set; }
    public DateTime DataTratamento { get; set; }

    // Relacionamentos
    [ForeignKey("VeterinarioID")]
    public Veterinario Veterinario { get; set; }
    public long VeterinarioID { get; set; }

    [ForeignKey("ConsultaID")]
    public Consulta Consulta { get; set; }
    public long ConsultaID { get; set; }

    [ForeignKey("Idboi")]
    public Boi Boi { get; set; }
    public long Idboi { get; set; }

    [ForeignKey("UserID")]
    public User User { get; set; }
    public long UserID { get; set; }
}
}

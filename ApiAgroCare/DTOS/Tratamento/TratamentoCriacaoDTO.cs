namespace ApiAgroCare.DTOS.Tratamento
{
    public class TratamentoCriacaoDTO
    {
        public string TipoTratamento { get; set; }
        public string NomeMedicamento { get; set; }
        public decimal DoseMedicamentoML { get; set; }
        public string DescricaoTratamento { get; set; }
        public string ViaAdministracao { get; set; }
        public int DuracaoTratamento { get; set; }
        public string EfeitoTratamento { get; set; }
        public string ObservacaoTratamento { get; set; }
        public DateTime DataTratamento { get; set; }
        public long VeterinarioID { get; set; }  
        public long ConsultaID { get; set; }
        public long IdUser { get; set; }
        public long BoiId { get; set;}
    }
}

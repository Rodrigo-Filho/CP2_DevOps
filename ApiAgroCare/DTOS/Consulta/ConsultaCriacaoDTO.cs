namespace ApiAgroCare.DTOS.Consulta
{
    public class ConsultaCriacaoDTO
    {
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public long BoiID { get; set; }
        public long IdUser { get; set; }
        public long VeterinarioID { get; set; }
    }
}

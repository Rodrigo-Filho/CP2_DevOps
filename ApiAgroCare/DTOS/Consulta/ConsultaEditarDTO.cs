namespace ApiAgroCare.DTOS.Consulta
{
    public class ConsultaEditarDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public long BoiID { get; set; }
        public long UserID { get; set; }
        public long VeterinarioID { get; set; }
    }
}

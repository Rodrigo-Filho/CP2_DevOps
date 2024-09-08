using ApiAgroCare.Model;

namespace ApiAgroCare.DTOS.Boi
{
    public class BoiEditarDTO
    {
        public int Id { get; set; }
        public double Saude { get; set; }
        public DateTime UltimoDiaAtualizacao { get; set; }
        public SaudeBoi SaudeBoi { get; set; }
        public long UserID { get; set; }  
        public long ConsultaID { get; set; }
    }
}

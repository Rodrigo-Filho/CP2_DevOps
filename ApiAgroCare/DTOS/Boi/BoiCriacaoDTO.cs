using ApiAgroCare.Model;

namespace ApiAgroCare.DTOS.Boi
{
    public class BoiCriacaoDTO
    {
        public double Saude { get; set; }
        public DateTime UltimoDiaAtualizacao { get; set; }
        public SaudeBoi SaudeBoi { get; set; }
        public long IdUser { get; set; }
       
        
    }
}

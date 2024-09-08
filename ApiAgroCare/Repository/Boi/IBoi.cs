using ApiAgroCare.DTOS.Boi;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.boi
{
    public interface IBoi
    {
        Task<Response<List<Boi>>> ListarBois();
        Task<Response<Boi>> BuscarBoiPorId(int idBoi);
        Task<Response<List<Boi>>> CriarBoi(BoiCriacaoDTO boiCriacaoDto);
        Task<Response<List<Boi>>> EditarBoi(BoiEditarDTO boiEdicaoDto);
        Task<Response<List<Boi>>> ExcluirBoi(int idBoi);
    }
}

using ApiAgroCare.DTOS.Veterinario;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.veterinario
{
    public interface IVeterinario
    {
        Task<Response<List<Veterinario>>> ListarVeterinarios();
        Task<Response<Veterinario>> BuscarVeterinarioPorId(int idVeterinario);
        Task<Response<List<Veterinario>>> CriarVeterinario(VeterinarioCriacaoDTO veterinarioCriacaoDto);
        Task<Response<List<Veterinario>>> EditarVeterinario(VeterinarioEditarDTO veterinarioEdicaoDto);
        Task<Response<List<Veterinario>>> ExcluirVeterinario(int idVeterinario);
    }
}

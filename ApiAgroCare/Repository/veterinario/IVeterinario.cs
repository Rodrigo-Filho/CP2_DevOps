using ApiAgroCare.DTOS.User;
using ApiAgroCare.DTOS.Veterinario;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.veterinario
{
    public interface IVeterinario
    {
        Task<Response<List<VeterinarioDTO>>> ListarVeterinarios();
        Task<Response<VeterinarioDTO>> BuscarVeterinarioPorId(int idVeterinario);
        Task<Response<Veterinario>> CriarVeterinario(VeterinarioCriacaoDTO veterinarioCriacaoDto);
        Task<Response<List<Veterinario>>> EditarVeterinario(VeterinarioEditarDTO veterinarioEdicaoDto);
        Task<Response<List<Veterinario>>> ExcluirVeterinario(int idVeterinario);
        Task<Veterinario> BuscarVeterinarioPorEmail(string email);
        Task<Response<string>> Login(VeterinarioLoginDTO veterinarioLoginDto);
    }
}

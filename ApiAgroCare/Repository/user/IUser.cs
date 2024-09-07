using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.user
{
    public interface IUser
    {
        Task<Response<List<User>>> ListarUsuarios();
        Task<Response<User>> BuscarUsuarioPorId(int idUsuario);
        Task<Response<List<User>>> CriarUsuario(UserCriacaoDTO userCriacaoDto);
        Task<Response<List<User>>> EditarUsuario(UserEditarDTO userEdicaoDto);
        Task<Response<List<User>>> ExcluirUsuario(int idUsuario);
    }
}

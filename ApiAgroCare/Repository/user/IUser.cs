using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.user
{
    public interface IUser
    {
        Task<Response<List<UserDTO>>> ListarUsuarios();

        
        Task<Response<UserDTO>> BuscarUsuarioPorId(int idUsuario);
        Task<Response<User>> CriarUsuario(UserCriacaoDTO userCriacaoDto);
        Task<Response<List<User>>> EditarUsuario(UserEditarDTO userEdicaoDto);
        Task<Response<List<User>>> ExcluirUsuario(int idUsuario);
        Task<User> BuscarUsuarioPorEmail(string email);
        Task<Response<string>> Login(UserLoginDTO userLoginDto);

    }
}

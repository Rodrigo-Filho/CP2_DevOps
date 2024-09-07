using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            this._userRepository = userRepository;
        }
        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<Response<List<User>>>> ListarUsuarios()
        {
            var usuarios = await _userRepository.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
        public async Task<ActionResult<Response<User>>> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _userRepository.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<Response<List<User>>>> CriarUsuario(UserCriacaoDTO userCriacaoDto)
        {
            var usuarios = await _userRepository.CriarUsuario(userCriacaoDto);
            return Ok(usuarios);
        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<Response<List<User>>>> EditarUsuario(UserEditarDTO userEdicaoDto)
        {
            var usuarios = await _userRepository.EditarUsuario(userEdicaoDto);
            return Ok(usuarios);
        }

        [HttpDelete("ExcluirUsuario/{idUsuario}")]
        public async Task<ActionResult<Response<List<User>>>> ExcluirUsuario(int idUsuario)
        {
            var usuarios = await _userRepository.ExcluirUsuario(idUsuario);
            return Ok(usuarios);
        }
    }
}

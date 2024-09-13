using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    /// <summary>
    /// Controlador responsável por operações com usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            this._userRepository = userRepository;
        }
        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <response code="200">Retorna a lista de usuários.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ListarUsuarios")]
        [ProducesResponseType(typeof(Response<List<User>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<User>>>> ListarUsuarios()
        {
            var usuarios = await _userRepository.ListarUsuarios();
            return Ok(usuarios);
        }

        /// <summary>
        /// Busca um usuário por ID.
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser buscado.</param>
        /// <response code="200">Retorna o usuário solicitado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
        [ProducesResponseType(typeof(Response<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<User>>> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _userRepository.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="userCriacaoDto">Dados para a criação do usuário.</param>
        /// <response code="201">Usuário criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CriarUsuario")]
        [ProducesResponseType(typeof(Response<List<User>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<User>>>> CriarUsuario(UserCriacaoDTO userCriacaoDto)
        {
            var usuarios = await _userRepository.CriarUsuario(userCriacaoDto);
            return Ok(usuarios);
        }

        /// <summary>
        /// Edita um usuário existente.
        /// </summary>
        /// <param name="userEdicaoDto">Dados do usuário a ser editado.</param>
        /// <response code="200">Usuário editado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("EditarUsuario")]
        [ProducesResponseType(typeof(Response<List<User>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<User>>>> EditarUsuario(UserEditarDTO userEdicaoDto)
        {
            var usuarios = await _userRepository.EditarUsuario(userEdicaoDto);
            return Ok(usuarios);
        }

        /// <summary>
        /// Exclui um usuário por ID.
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser excluído.</param>
        /// <response code="200">Usuário excluído com sucesso.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("ExcluirUsuario/{idUsuario}")]
        [ProducesResponseType(typeof(Response<List<User>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<User>>>> ExcluirUsuario(int idUsuario)
        {
            var usuarios = await _userRepository.ExcluirUsuario(idUsuario);
            return Ok(usuarios);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDto)
        {
            // Chama o método Login no repositório
            var response = await _userRepository.Login(userLoginDto);

            // Se o login falhar (ex: usuário não encontrado ou senha incorreta)
            if (!response.Status)
            {
                return Unauthorized(new { message = response.Mensagem });
            }

            // Retorna o token JWT se o login for bem-sucedido
            return Ok(new { token = response.Dados, message = response.Mensagem });
        }
    }
}
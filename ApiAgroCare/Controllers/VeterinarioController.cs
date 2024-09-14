using ApiAgroCare.DTOS.Veterinario;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.user;
using ApiAgroCare.Repository.veterinario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinario _veterinarioRepository;

        public VeterinarioController(IVeterinario veterinarioRepository)
        {
            this._veterinarioRepository = veterinarioRepository;
        }
        /// <summary>
        /// Lista todos os veterinários.
        /// </summary>
        /// <response code="200">Retorna a lista de veterinários.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ListarVeterinarios")]
        [ProducesResponseType(typeof(Response<List<Veterinario>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Veterinario>>>> ListarVeterinarios()
        {
            var veterinarios = await _veterinarioRepository.ListarVeterinarios();
            return Ok(veterinarios);
        }

        /// <summary>
        /// Busca um veterinário por ID.
        /// </summary>
        /// <param name="idVeterinario">ID do veterinário a ser buscado.</param>
        /// <response code="200">Retorna o veterinário solicitado.</response>
        /// <response code="404">Veterinário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("BuscarVeterinarioPorId/{idVeterinario}")]
        [ProducesResponseType(typeof(Response<Veterinario>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<Veterinario>>> BuscarVeterinarioPorId(int idVeterinario)
        {
            var veterinario = await _veterinarioRepository.BuscarVeterinarioPorId(idVeterinario);
            return Ok(veterinario);
        }

        /// <summary>
        /// Cria um novo veterinário.
        /// </summary>
        /// <param name="veterinarioCriacaoDto">Dados para a criação do veterinário.</param>
        /// <response code="201">Veterinário criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CriarVeterinario")]
        [ProducesResponseType(typeof(Response<List<Veterinario>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Veterinario>>>> CriarVeterinario(VeterinarioCriacaoDTO veterinarioCriacaoDto)
        {
            var veterinarios = await _veterinarioRepository.CriarVeterinario(veterinarioCriacaoDto);
            return Ok(veterinarios);
        }

        /// <summary>
        /// Edita um veterinário existente.
        /// </summary>
        /// <param name="veterinarioEdicaoDto">Dados do veterinário a ser editado.</param>
        /// <response code="200">Veterinário editado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Veterinário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("EditarVeterinario")]
        [ProducesResponseType(typeof(Response<List<Veterinario>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Veterinario>>>> EditarVeterinario(VeterinarioEditarDTO veterinarioEdicaoDto)
        {
            var veterinarios = await _veterinarioRepository.EditarVeterinario(veterinarioEdicaoDto);
            return Ok(veterinarios);
        }

        /// <summary>
        /// Exclui um veterinário por ID.
        /// </summary>
        /// <param name="idVeterinario">ID do veterinário a ser excluído.</param>
        /// <response code="200">Veterinário excluído com sucesso.</response>
        /// <response code="404">Veterinário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("ExcluirVeterinario/{idVeterinario}")]
        [ProducesResponseType(typeof(Response<List<Veterinario>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Veterinario>>>> ExcluirVeterinario(int idVeterinario)
        {
            var veterinarios = await _veterinarioRepository.ExcluirVeterinario(idVeterinario);
            return Ok(veterinarios);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(VeterinarioLoginDTO veterinarioLoginDto)
        {
            // Chama o método Login no repositório
            var response = await _veterinarioRepository.Login(veterinarioLoginDto);

            // Se o login falhar (ex: veterinário não encontrado ou senha incorreta)
            if (!response.Status)
            {
                return Unauthorized(new { message = response.Mensagem });
            }

            // Retorna o token JWT se o login for bem-sucedido
            return Ok(new { token = response.Dados, message = response.Mensagem });
        }
    }
}


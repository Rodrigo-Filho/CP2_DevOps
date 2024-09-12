using ApiAgroCare.DTOS.Tratamento;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.tratamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamentoController : ControllerBase
    {
        private readonly ITratamento _tratamentoService;

        public TratamentoController(ITratamento tratamentoService)
        {
            _tratamentoService = tratamentoService;
        }

        /// <summary>
        /// Lista todos os tratamentos.
        /// </summary>
        /// <response code="200">Retorna a lista de tratamentos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ListarTratamentos")]
        [ProducesResponseType(typeof(Response<List<Tratamento>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Tratamento>>>> ListarTratamentos()
        {
            var tratamentos = await _tratamentoService.ListarTratamentos();
            return Ok(tratamentos);
        }

        /// <summary>
        /// Busca um tratamento por ID.
        /// </summary>
        /// <param name="idTratamento">ID do tratamento a ser buscado.</param>
        /// <response code="200">Retorna o tratamento solicitado.</response>
        /// <response code="404">Tratamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("BuscarTratamentoPorId/{idTratamento}")]
        [ProducesResponseType(typeof(Response<Tratamento>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<Tratamento>>> BuscarTratamentoPorId(int idTratamento)
        {
            var tratamento = await _tratamentoService.BuscarTratamentoPorId(idTratamento);
            return Ok(tratamento);
        }

        /// <summary>
        /// Cria um novo tratamento.
        /// </summary>
        /// <param name="tratamentoCriacaoDto">Dados para a criação do tratamento.</param>
        /// <response code="201">Tratamento criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CriarTratamento")]
        [ProducesResponseType(typeof(Response<List<Tratamento>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Tratamento>>>> CriarTratamento(TratamentoCriacaoDTO tratamentoCriacaoDto)
        {
            var tratamentos = await _tratamentoService.CriarTratamento(tratamentoCriacaoDto);
            return Ok(tratamentos);
        }

        /// <summary>
        /// Edita um tratamento existente.
        /// </summary>
        /// <param name="tratamentoEdicaoDto">Dados do tratamento a ser editado.</param>
        /// <response code="200">Tratamento editado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Tratamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("EditarTratamento")]
        [ProducesResponseType(typeof(Response<List<Tratamento>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Tratamento>>>> EditarTratamento(TratamentoEditarDTO tratamentoEdicaoDto)
        {
            var tratamentos = await _tratamentoService.EditarTratamento(tratamentoEdicaoDto);
            return Ok(tratamentos);
        }

        /// <summary>
        /// Exclui um tratamento por ID.
        /// </summary>
        /// <param name="idTratamento">ID do tratamento a ser excluído.</param>
        /// <response code="200">Tratamento excluído com sucesso.</response>
        /// <response code="404">Tratamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("ExcluirTratamento/{idTratamento}")]
        [ProducesResponseType(typeof(Response<List<Tratamento>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Tratamento>>>> ExcluirTratamento(int idTratamento)
        {
            var tratamentos = await _tratamentoService.ExcluirTratamento(idTratamento);
            return Ok(tratamentos);
        }
    }
}


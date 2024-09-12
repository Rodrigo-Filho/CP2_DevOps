using ApiAgroCare.DTOS.Avaliacoes;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.avaliacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacoes _avaliacaoService;

        public AvaliacoesController(IAvaliacoes avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        /// <summary>
        /// Lista todas as avaliações.
        /// </summary>
        /// <response code="200">Retorna a lista de avaliações.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ListarAvaliacoes")]
        [ProducesResponseType(typeof(Response<List<Avaliacoes>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> ListarAvaliacoes()
        {
            var avaliacoes = await _avaliacaoService.ListarAvaliacoes();
            return Ok(avaliacoes);
        }

        /// <summary>
        /// Busca uma avaliação por ID.
        /// </summary>
        /// <param name="idAvaliacao">ID da avaliação a ser buscada.</param>
        /// <response code="200">Retorna a avaliação solicitada.</response>
        /// <response code="404">Avaliação não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("BuscarAvaliacaoPorId/{idAvaliacao}")]
        [ProducesResponseType(typeof(Response<Avaliacoes>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<Avaliacoes>>> BuscarAvaliacaoPorId(int idAvaliacao)
        {
            var avaliacao = await _avaliacaoService.BuscarAvaliacaoPorId(idAvaliacao);
            return Ok(avaliacao);
        }

        /// <summary>
        /// Cria uma nova avaliação.
        /// </summary>
        /// <param name="avaliacaoCriacaoDto">Dados para a criação da avaliação.</param>
        /// <response code="201">Avaliação criada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CriarAvaliacao")]
        [ProducesResponseType(typeof(Response<List<Avaliacoes>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> CriarAvaliacao(AvaliacaoCriacaoDTO avaliacaoCriacaoDto)
        {
            var avaliacoes = await _avaliacaoService.CriarAvaliacao(avaliacaoCriacaoDto);
            return Ok(avaliacoes);
        }

        /// <summary>
        /// Edita uma avaliação existente.
        /// </summary>
        /// <param name="avaliacaoEdicaoDto">Dados da avaliação a ser editada.</param>
        /// <response code="200">Avaliação editada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Avaliação não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("EditarAvaliacao")]
        [ProducesResponseType(typeof(Response<List<Avaliacoes>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> EditarAvaliacao(AvaliacaoEditarDTO avaliacaoEdicaoDto)
        {
            var avaliacoes = await _avaliacaoService.EditarAvaliacao(avaliacaoEdicaoDto);
            return Ok(avaliacoes);
        }

        /// <summary>
        /// Exclui uma avaliação por ID.
        /// </summary>
        /// <param name="idAvaliacao">ID da avaliação a ser excluída.</param>
        /// <response code="200">Avaliação excluída com sucesso.</response>
        /// <response code="404">Avaliação não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("ExcluirAvaliacao/{idAvaliacao}")]
        [ProducesResponseType(typeof(Response<List<Avaliacoes>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> ExcluirAvaliacao(int idAvaliacao)
        {
            var avaliacoes = await _avaliacaoService.ExcluirAvaliacao(idAvaliacao);
            return Ok(avaliacoes);
        }
    }
}

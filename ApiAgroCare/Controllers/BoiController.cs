using ApiAgroCare.DTOS.Boi;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.boi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoiController : ControllerBase
    {

        private readonly IBoi _boiService;

        public BoiController(IBoi boiService)
        {
            _boiService = boiService;
        }

        /// <summary>
        /// Lista todos os bois.
        /// </summary>
        /// <response code="200">Retorna a lista de bois.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ListarBois")]
        [ProducesResponseType(typeof(Response<List<Boi>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Boi>>>> ListarBois()
        {
            var bois = await _boiService.ListarBois();
            return Ok(bois);
        }

        /// <summary>
        /// Busca um boi por ID.
        /// </summary>
        /// <param name="idBoi">ID do boi a ser buscado.</param>
        /// <response code="200">Retorna o boi solicitado.</response>
        /// <response code="404">Boi não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("BuscarBoiPorId/{idBoi}")]
        [ProducesResponseType(typeof(Response<Boi>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<Boi>>> BuscarBoiPorId(int idBoi)
        {
            var boi = await _boiService.BuscarBoiPorId(idBoi);
            return Ok(boi);
        }

        /// <summary>
        /// Cria um novo boi.
        /// </summary>
        /// <param name="boiCriacaoDto">Dados para a criação do boi.</param>
        /// <response code="201">Boi criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CriarBoi")]
        [ProducesResponseType(typeof(Response<List<Boi>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Boi>>>> CriarBoi(BoiCriacaoDTO boiCriacaoDto)
        {
            var bois = await _boiService.CriarBoi(boiCriacaoDto);
            return Ok(bois);
        }

        /// <summary>
        /// Edita um boi existente.
        /// </summary>
        /// <param name="boiEdicaoDto">Dados do boi a ser editado.</param>
        /// <response code="200">Boi editado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Boi não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("EditarBoi")]
        [ProducesResponseType(typeof(Response<List<Boi>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Boi>>>> EditarBoi(BoiEditarDTO boiEdicaoDto)
        {
            var bois = await _boiService.EditarBoi(boiEdicaoDto);
            return Ok(bois);
        }

        /// <summary>
        /// Exclui um boi por ID.
        /// </summary>
        /// <param name="idBoi">ID do boi a ser excluído.</param>
        /// <response code="200">Boi excluído com sucesso.</response>
        /// <response code="404">Boi não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("ExcluirBoi/{idBoi}")]
        [ProducesResponseType(typeof(Response<List<Boi>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Boi>>>> ExcluirBoi(int idBoi)
        {
            var bois = await _boiService.ExcluirBoi(idBoi);
            return Ok(bois);
        }
    }

}


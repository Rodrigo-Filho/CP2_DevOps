using ApiAgroCare.DTOS.Consulta;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.consulta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgroCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        private readonly IConsulta _consultaService;

        public ConsultaController(IConsulta consultaService)
        {
            _consultaService = consultaService;
        }

        /// <summary>
        /// Lista todas as consultas.
        /// </summary>
        /// <response code="200">Retorna a lista de consultas.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("ListarConsultas")]
        [ProducesResponseType(typeof(Response<List<Consulta>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Consulta>>>> ListarConsultas()
        {
            var consultas = await _consultaService.ListarConsultas();
            return Ok(consultas);
        }

        /// <summary>
        /// Busca uma consulta por ID.
        /// </summary>
        /// <param name="idConsulta">ID da consulta a ser buscada.</param>
        /// <response code="200">Retorna a consulta solicitada.</response>
        /// <response code="404">Consulta não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("BuscarConsultaPorId/{idConsulta}")]
        [ProducesResponseType(typeof(Response<Consulta>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<Consulta>>> BuscarConsultaPorId(int idConsulta)
        {
            var consulta = await _consultaService.BuscarConsultaPorId(idConsulta);
            return Ok(consulta);
        }

        /// <summary>
        /// Cria uma nova consulta.
        /// </summary>
        /// <param name="consultaCriacaoDto">Dados para a criação da consulta.</param>
        /// <response code="201">Consulta criada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("CriarConsulta")]
        [ProducesResponseType(typeof(Response<List<Consulta>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Consulta>>>> CriarConsulta(ConsultaCriacaoDTO consultaCriacaoDto)
        {
            var consultas = await _consultaService.CriarConsulta(consultaCriacaoDto);
            return Ok(consultas);
        }

        /// <summary>
        /// Edita uma consulta existente.
        /// </summary>
        /// <param name="consultaEdicaoDto">Dados da consulta a ser editada.</param>
        /// <response code="200">Consulta editada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Consulta não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("EditarConsulta")]
        [ProducesResponseType(typeof(Response<List<Consulta>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        public async Task<ActionResult<Response<List<Consulta>>>> EditarConsulta(ConsultaEditarDTO consultaEdicaoDto)
        {
            var consultas = await _consultaService.EditarConsulta(consultaEdicaoDto);
            return Ok(consultas);
        }

        /// <summary>
        /// Exclui uma consulta por ID.
        /// </summary>
        /// <param name="idConsulta">ID da consulta a ser excluída.</param>
        /// <response code="200">Consulta excluída com sucesso.</response>
        /// <response code="404">Consulta não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("ExcluirConsulta/{idConsulta}")]
        [ProducesResponseType(typeof(Response<List<Consulta>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<Consulta>>>> ExcluirConsulta(int idConsulta)
        {
            var consultas = await _consultaService.ExcluirConsulta(idConsulta);
            return Ok(consultas);
        }

    }
}


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

        [HttpGet("ListarConsultas")]
        public async Task<ActionResult<Response<List<Consulta>>>> ListarConsultas()
        {
            var consultas = await _consultaService.ListarConsultas();
            return Ok(consultas);
        }

        [HttpGet("BuscarConsultaPorId/{idConsulta}")]
        public async Task<ActionResult<Response<Consulta>>> BuscarConsultaPorId(int idConsulta)
        {
            var consulta = await _consultaService.BuscarConsultaPorId(idConsulta);
            return Ok(consulta);
        }

        [HttpPost("CriarConsulta")]
        public async Task<ActionResult<Response<List<Consulta>>>> CriarConsulta(ConsultaCriacaoDTO consultaCriacaoDto)
        {
            var consultas = await _consultaService.CriarConsulta(consultaCriacaoDto);
            return Ok(consultas);
        }

        [HttpPut("EditarConsulta")]
        public async Task<ActionResult<Response<List<Consulta>>>> EditarConsulta(ConsultaEditarDTO consultaEdicaoDto)
        {
            var consultas = await _consultaService.EditarConsulta(consultaEdicaoDto);
            return Ok(consultas);
        }

        [HttpDelete("ExcluirConsulta/{idConsulta}")]
        public async Task<ActionResult<Response<List<Consulta>>>> ExcluirConsulta(int idConsulta)
        {
            var consultas = await _consultaService.ExcluirConsulta(idConsulta);
            return Ok(consultas);
        }
    }

}


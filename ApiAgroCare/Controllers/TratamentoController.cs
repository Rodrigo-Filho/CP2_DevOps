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

        [HttpGet("ListarTratamentos")]
        public async Task<ActionResult<Response<List<Tratamento>>>> ListarTratamentos()
        {
            var tratamentos = await _tratamentoService.ListarTratamentos();
            return Ok(tratamentos);
        }

        [HttpGet("BuscarTratamentoPorId/{idTratamento}")]
        public async Task<ActionResult<Response<Tratamento>>> BuscarTratamentoPorId(int idTratamento)
        {
            var tratamento = await _tratamentoService.BuscarTratamentoPorId(idTratamento);
            return Ok(tratamento);
        }

        [HttpPost("CriarTratamento")]
        public async Task<ActionResult<Response<List<Tratamento>>>> CriarTratamento(TratamentoCriacaoDTO tratamentoCriacaoDto)
        {
            var tratamentos = await _tratamentoService.CriarTratamento(tratamentoCriacaoDto);
            return Ok(tratamentos);
        }

        [HttpPut("EditarTratamento")]
        public async Task<ActionResult<Response<List<Tratamento>>>> EditarTratamento(TratamentoEditarDTO tratamentoEdicaoDto)
        {
            var tratamentos = await _tratamentoService.EditarTratamento(tratamentoEdicaoDto);
            return Ok(tratamentos);
        }

        [HttpDelete("ExcluirTratamento/{idTratamento}")]
        public async Task<ActionResult<Response<List<Tratamento>>>> ExcluirTratamento(int idTratamento)
        {
            var tratamentos = await _tratamentoService.ExcluirTratamento(idTratamento);
            return Ok(tratamentos);
        }
    }
}


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

        [HttpGet("ListarAvaliacoes")]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> ListarAvaliacoes()
        {
            var avaliacoes = await _avaliacaoService.ListarAvaliacoes();
            return Ok(avaliacoes);
        }

        [HttpGet("BuscarAvaliacaoPorId/{idAvaliacao}")]
        public async Task<ActionResult<Response<Avaliacoes>>> BuscarAvaliacaoPorId(int idAvaliacao)
        {
            var avaliacao = await _avaliacaoService.BuscarAvaliacaoPorId(idAvaliacao);
            return Ok(avaliacao);
        }

        [HttpPost("CriarAvaliacao")]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> CriarAvaliacao(AvaliacaoCriacaoDTO avaliacaoCriacaoDto)
        {
            var avaliacoes = await _avaliacaoService.CriarAvaliacao(avaliacaoCriacaoDto);
            return Ok(avaliacoes);
        }

        [HttpPut("EditarAvaliacao")]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> EditarAvaliacao(AvaliacaoEditarDTO avaliacaoEdicaoDto)
        {
            var avaliacoes = await _avaliacaoService.EditarAvaliacao(avaliacaoEdicaoDto);
            return Ok(avaliacoes);
        }

        [HttpDelete("ExcluirAvaliacao/{idAvaliacao}")]
        public async Task<ActionResult<Response<List<Avaliacoes>>>> ExcluirAvaliacao(int idAvaliacao)
        {
            var avaliacoes = await _avaliacaoService.ExcluirAvaliacao(idAvaliacao);
            return Ok(avaliacoes);
        }
    }
}

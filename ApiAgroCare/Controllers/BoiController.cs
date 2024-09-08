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

        [HttpGet("ListarBois")]
        public async Task<ActionResult<Response<List<Boi>>>> ListarBois()
        {
            var bois = await _boiService.ListarBois();
            return Ok(bois);
        }

        [HttpGet("BuscarBoiPorId/{idBoi}")]
        public async Task<ActionResult<Response<Boi>>> BuscarBoiPorId(int idBoi)
        {
            var boi = await _boiService.BuscarBoiPorId(idBoi);
            return Ok(boi);
        }

        [HttpPost("CriarBoi")]
        public async Task<ActionResult<Response<List<Boi>>>> CriarBoi(BoiCriacaoDTO boiCriacaoDto)
        {
            var bois = await _boiService.CriarBoi(boiCriacaoDto);
            return Ok(bois);
        }

        [HttpPut("EditarBoi")]
        public async Task<ActionResult<Response<List<Boi>>>> EditarBoi(BoiEditarDTO boiEdicaoDto)
        {
            var bois = await _boiService.EditarBoi(boiEdicaoDto);
            return Ok(bois);
        }

        [HttpDelete("ExcluirBoi/{idBoi}")]
        public async Task<ActionResult<Response<List<Boi>>>> ExcluirBoi(int idBoi)
        {
            var bois = await _boiService.ExcluirBoi(idBoi);
            return Ok(bois);
        }
    }

}


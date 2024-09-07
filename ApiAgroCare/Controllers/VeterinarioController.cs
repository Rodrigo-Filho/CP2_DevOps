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
        [HttpGet("ListarVeterinarios")]
        public async Task<ActionResult<Response<List<Veterinario>>>> ListarVeterinarios()
        {
            var veterinarios = await _veterinarioRepository.ListarVeterinarios();
            return Ok(veterinarios);
        }

        [HttpGet("BuscarVeterinarioPorId/{idVeterinario}")]
        public async Task<ActionResult<Response<Veterinario>>> BuscarVeterinarioPorId(int idVeterinario)
        {
            var veterinario = await _veterinarioRepository.BuscarVeterinarioPorId(idVeterinario);
            return Ok(veterinario);
        }

        [HttpPost("CriarVeterinario")]
        public async Task<ActionResult<Response<List<Veterinario>>>> CriarVeterinario(VeterinarioCriacaoDTO veterinarioCriacaoDto)
        {
            var veterinarios = await _veterinarioRepository.CriarVeterinario(veterinarioCriacaoDto);
            return Ok(veterinarios);
        }

        [HttpPut("EditarVeterinario")]
        public async Task<ActionResult<Response<List<Veterinario>>>> EditarVeterinario(VeterinarioEditarDTO veterinarioEdicaoDto)
        {
            var veterinarios = await _veterinarioRepository.EditarVeterinario(veterinarioEdicaoDto);
            return Ok(veterinarios);
        }

        [HttpDelete("ExcluirVeterinario/{idVeterinario}")]
        public async Task<ActionResult<Response<List<Veterinario>>>> ExcluirVeterinario(int idVeterinario)
        {
            var veterinarios = await _veterinarioRepository.ExcluirVeterinario(idVeterinario);
            return Ok(veterinarios);
        }
    }
}


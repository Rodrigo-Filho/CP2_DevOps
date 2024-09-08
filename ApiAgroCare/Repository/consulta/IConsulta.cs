using ApiAgroCare.DTOS.Consulta;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.consulta
{
    public interface IConsulta
    {
        Task<Response<List<Consulta>>> ListarConsultas();
        Task<Response<Consulta>> BuscarConsultaPorId(int idConsulta);
        Task<Response<List<Consulta>>> CriarConsulta(ConsultaCriacaoDTO consultaCriacaoDto);
        Task<Response<List<Consulta>>> EditarConsulta(ConsultaEditarDTO consultaEdicaoDto);
        Task<Response<List<Consulta>>> ExcluirConsulta(int idConsulta);
    }
}

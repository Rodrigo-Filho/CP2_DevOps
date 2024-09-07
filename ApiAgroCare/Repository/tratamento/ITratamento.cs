using ApiAgroCare.DTOS.Tratamento;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.tratamento
{
    public interface ITratamento
    {
        Task<Response<List<Tratamento>>> ListarTratamentos();
        Task<Response<Tratamento>> BuscarTratamentoPorId(int idTratamento);
        Task<Response<List<Tratamento>>> CriarTratamento(TratamentoCriacaoDTO tratamentoCriacaoDto);
        Task<Response<List<Tratamento>>> EditarTratamento(TratamentoEditarDTO tratamentoEdicaoDto);
        Task<Response<List<Tratamento>>> ExcluirTratamento(int idTratamento);
    }
}


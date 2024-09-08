using ApiAgroCare.DTOS.Avaliacoes;
using ApiAgroCare.Model;

namespace ApiAgroCare.Repository.avaliacoes
{
    public interface IAvaliacoes
    {
        Task<Response<List<Avaliacoes>>> ListarAvaliacoes();
        Task<Response<Avaliacoes>> BuscarAvaliacaoPorId(int idAvaliacao);
        Task<Response<List<Avaliacoes>>> CriarAvaliacao(AvaliacaoCriacaoDTO avaliacaoCriacaoDto);
        Task<Response<List<Avaliacoes>>> EditarAvaliacao(AvaliacaoEditarDTO avaliacaoEdicaoDto);
        Task<Response<List<Avaliacoes>>> ExcluirAvaliacao(int idAvaliacao);
    }
}

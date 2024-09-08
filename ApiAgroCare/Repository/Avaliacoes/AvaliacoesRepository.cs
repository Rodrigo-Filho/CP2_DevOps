using ApiAgroCare.Data;
using ApiAgroCare.DTOS.Avaliacoes;
using ApiAgroCare.Model;

using Microsoft.EntityFrameworkCore;


namespace ApiAgroCare.Repository.avaliacoes
{
    public class AvaliacoesRepository : IAvaliacoes
    {
        private readonly dbContext dbContext;

        public AvaliacoesRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<List<Avaliacoes>>> ListarAvaliacoes()
        {
            Response<List<Avaliacoes>> resposta = new Response<List<Avaliacoes>>();
            try
            {
                var avaliacoes = await dbContext.Avaliacoes.ToListAsync();
                resposta.Dados = avaliacoes;
                resposta.Mensagem = "Todas as avaliações foram coletadas!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<Avaliacoes>> BuscarAvaliacaoPorId(int idAvaliacao)
        {
            Response<Avaliacoes> resposta = new Response<Avaliacoes>();
            try
            {
                var avaliacao = await dbContext.Avaliacoes.FirstOrDefaultAsync(a => a.IdAvaliacoes == idAvaliacao);
                if (avaliacao == null)
                {
                    resposta.Mensagem = "Nenhuma avaliação localizada!";
                    return resposta;
                }

                resposta.Dados = avaliacao;
                resposta.Mensagem = "Avaliação localizada!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Avaliacoes>>> CriarAvaliacao(AvaliacaoCriacaoDTO avaliacaoCriacaoDto)
        {
            Response<List<Avaliacoes>> resposta = new Response<List<Avaliacoes>>();

            try
            {
                // Verifique se a consulta e o veterinário existem
                var consulta = await dbContext.Consultas.FindAsync(avaliacaoCriacaoDto.ConsultaID);
                var veterinario = await dbContext.Veterinarios.FindAsync(avaliacaoCriacaoDto.VeterinarioID);
                var user = await dbContext.Users.FindAsync(avaliacaoCriacaoDto.UserID);

                if (consulta == null || veterinario == null || user == null)
                {
                    resposta.Mensagem = "Consulta, Veterinário ou Usuário não encontrados!";
                    return resposta;
                }

                // Criação da nova avaliação
                var novaAvaliacao = new Avaliacoes
                {
                    QtdEstrelas = avaliacaoCriacaoDto.QtdEstrelas,
                    MsgAvaliacao = avaliacaoCriacaoDto.MsgAvaliacao,
                    DataAvaliacao = DateTime.Now,
                    ConsultaID = consulta.ID,
                    VeterinarioID = veterinario.Id,
                    UserID = user.ID
                };

                dbContext.Avaliacoes.Add(novaAvaliacao);
                await dbContext.SaveChangesAsync();

                // Retorne a lista atualizada de avaliações
                resposta.Dados = await dbContext.Avaliacoes.ToListAsync();
                resposta.Mensagem = "Avaliação criada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Avaliacoes>>> EditarAvaliacao(AvaliacaoEditarDTO avaliacaoEdicaoDto)
        {
            Response<List<Avaliacoes>> resposta = new Response<List<Avaliacoes>>();
            try
            {
                var avaliacao = await dbContext.Avaliacoes.FirstOrDefaultAsync(a => a.IdAvaliacoes == avaliacaoEdicaoDto.IdAvaliacoes);

                if (avaliacao == null)
                {
                    resposta.Mensagem = "Nenhuma avaliação localizada!";
                    return resposta;
                }

                avaliacao.QtdEstrelas = avaliacaoEdicaoDto.QtdEstrelas;
                avaliacao.MsgAvaliacao = avaliacaoEdicaoDto.MsgAvaliacao;
                avaliacao.DataAvaliacao = avaliacaoEdicaoDto.DataAvaliacao;
                avaliacao.ConsultaID = avaliacaoEdicaoDto.ConsultaID;
                avaliacao.VeterinarioID = avaliacaoEdicaoDto.VeterinarioID;
                avaliacao.UserID = avaliacaoEdicaoDto.UserID;

                dbContext.Update(avaliacao);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Avaliacoes.ToListAsync();
                resposta.Mensagem = "Avaliação editada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Avaliacoes>>> ExcluirAvaliacao(int idAvaliacao)
        {
            Response<List<Avaliacoes>> resposta = new Response<List<Avaliacoes>>();
            try
            {
                var avaliacao = await dbContext.Avaliacoes.FirstOrDefaultAsync(a => a.IdAvaliacoes == idAvaliacao);

                if (avaliacao == null)
                {
                    resposta.Mensagem = "Nenhuma avaliação localizada!";
                    return resposta;
                }

                dbContext.Avaliacoes.Remove(avaliacao);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Avaliacoes.ToListAsync();
                resposta.Mensagem = "Avaliação excluída com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        
    }
}


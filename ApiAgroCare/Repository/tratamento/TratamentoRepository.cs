using ApiAgroCare.Data;
using ApiAgroCare.DTOS.Tratamento;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAgroCare.Repository.tratamento
{
    public class TratamentoRepository: ITratamento
    {
        private readonly dbContext dbContext;

        public TratamentoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Response<List<Tratamento>>> ListarTratamentos()
        {
            Response<List<Tratamento>> resposta = new Response<List<Tratamento>>();
            try
            {
                var tratamentos = await dbContext.Tratamentos.ToListAsync();
                resposta.Dados = tratamentos;
                resposta.Mensagem = "Todos os tratamentos foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<Tratamento>> BuscarTratamentoPorId(int idTratamento)
        {
            Response<Tratamento> resposta = new Response<Tratamento>();
            try
            {
                var tratamento = await dbContext.Tratamentos.FirstOrDefaultAsync(t => t.IdTratamento == idTratamento);
                if (tratamento == null)
                {
                    resposta.Mensagem = "Nenhum tratamento localizado!";
                    return resposta;
                }

                resposta.Dados = tratamento;
                resposta.Mensagem = "Tratamento localizado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<Response<List<Tratamento>>> CriarTratamento(TratamentoCriacaoDTO tratamentoCriacaoDto)
        {
            Response<List<Tratamento>> resposta = new Response<List<Tratamento>>();

            try
            {
                var tratamento = new Tratamento
                {
                    TipoTratamento = tratamentoCriacaoDto.TipoTratamento,
                    NomeMedicamento = tratamentoCriacaoDto.NomeMedicamento,
                    DoseMedicamentoML = tratamentoCriacaoDto.DoseMedicamentoML,
                    DescricaoTratamento = tratamentoCriacaoDto.DescricaoTratamento,
                    ViaAdministracao = tratamentoCriacaoDto.ViaAdministracao,
                    DuracaoTratamento = tratamentoCriacaoDto.DuracaoTratamento,
                    EfeitoTratamento = tratamentoCriacaoDto.EfeitoTratamento,
                    ObservacaoTratamento = tratamentoCriacaoDto.ObservacaoTratamento,
                    DataTratamento = tratamentoCriacaoDto.DataTratamento,
                    VeterinarioID = tratamentoCriacaoDto.VeterinarioID,
                    ConsultaID = tratamentoCriacaoDto.ConsultaID,
                    UserID = tratamentoCriacaoDto.IdUser,
                    Idboi = tratamentoCriacaoDto.BoiId
                };

                dbContext.Add(tratamento);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Tratamentos.ToListAsync();
                resposta.Mensagem = "Tratamento criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<Response<List<Tratamento>>> EditarTratamento(TratamentoEditarDTO tratamentoEdicaoDto)
        {
            Response<List<Tratamento>> resposta = new Response<List<Tratamento>>();
            try
            {
                var tratamento = await dbContext.Tratamentos.FirstOrDefaultAsync(t => t.IdTratamento == tratamentoEdicaoDto.Id);

                if (tratamento == null)
                {
                    resposta.Mensagem = "Nenhum tratamento localizado!";
                    return resposta;
                }

                tratamento.TipoTratamento = tratamentoEdicaoDto.TipoTratamento;
                tratamento.NomeMedicamento = tratamentoEdicaoDto.NomeMedicamento;
                tratamento.DoseMedicamentoML = tratamentoEdicaoDto.DoseMedicamentoML;
                tratamento.DescricaoTratamento = tratamentoEdicaoDto.DescricaoTratamento;
                tratamento.ViaAdministracao = tratamentoEdicaoDto.ViaAdministracao;
                tratamento.DuracaoTratamento = tratamentoEdicaoDto.DuracaoTratamento;
                tratamento.EfeitoTratamento = tratamentoEdicaoDto.EfeitoTratamento;
                tratamento.ObservacaoTratamento = tratamentoEdicaoDto.ObservacaoTratamento;
                tratamento.DataTratamento = tratamentoEdicaoDto.DataTratamento;
                tratamento.VeterinarioID = tratamentoEdicaoDto.VeterinarioID;
                tratamento.ConsultaID = tratamentoEdicaoDto.ConsultaID;
                tratamento.UserID = tratamentoEdicaoDto.IdUser;
                tratamento.Idboi = tratamentoEdicaoDto.BoiId;

                dbContext.Update(tratamento);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Tratamentos.ToListAsync();
                resposta.Mensagem = "Tratamento editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<Response<List<Tratamento>>> ExcluirTratamento(int idTratamento)
        {
            Response<List<Tratamento>> resposta = new Response<List<Tratamento>>();

            try
            {
                var tratamento = await dbContext.Tratamentos.FirstOrDefaultAsync(t => t.IdTratamento == idTratamento);

                if (tratamento == null)
                {
                    resposta.Mensagem = "Nenhum tratamento localizado!";
                    return resposta;
                }

                dbContext.Remove(tratamento);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Tratamentos.ToListAsync();
                resposta.Mensagem = "Tratamento removido com sucesso!";
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

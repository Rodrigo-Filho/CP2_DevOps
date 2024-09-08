using ApiAgroCare.Data;
using ApiAgroCare.DTOS.Consulta;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAgroCare.Repository.consulta
{
    public class ConsultaRepository : IConsulta
    {
        private readonly dbContext dbContext;

        public ConsultaRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<List<Consulta>>> ListarConsultas()
        {
            Response<List<Consulta>> resposta = new Response<List<Consulta>>();
            try
            {
                var consultas = await dbContext.Consultas.ToListAsync();
                resposta.Dados = consultas;
                resposta.Mensagem = "Todas as consultas foram coletadas!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<Consulta>> BuscarConsultaPorId(int idConsulta)
        {
            Response<Consulta> resposta = new Response<Consulta>();
            try
            {
                var consulta = await dbContext.Consultas.FirstOrDefaultAsync(c => c.ID == idConsulta);
                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada!";
                    return resposta;
                }

                resposta.Dados = consulta;
                resposta.Mensagem = "Consulta localizada!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Consulta>>> CriarConsulta(ConsultaCriacaoDTO consultaCriacaoDto)
        {
            Response<List<Consulta>> resposta = new Response<List<Consulta>>();

            try
            {
                var consulta = new Consulta
                {
                    Descricao = consultaCriacaoDto.Descricao,
                    Observacao = consultaCriacaoDto.Observacao,
                    DataConsulta = consultaCriacaoDto.DataConsulta,
                    IdBoi = consultaCriacaoDto.BoiID,
                    IdUser = consultaCriacaoDto.IdUser,
                    IdVeterinario = consultaCriacaoDto.VeterinarioID
                };

                dbContext.Add(consulta);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Consultas.ToListAsync();
                resposta.Mensagem = "Consulta criada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Consulta>>> EditarConsulta(ConsultaEditarDTO consultaEdicaoDto)
        {
            Response<List<Consulta>> resposta = new Response<List<Consulta>>();
            try
            {
                var consulta = await dbContext.Consultas.FirstOrDefaultAsync(c => c.ID == consultaEdicaoDto.Id);

                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada!";
                    return resposta;
                }

                consulta.Descricao = consultaEdicaoDto.Descricao;
                consulta.Observacao = consultaEdicaoDto.Observacao;
                consulta.DataConsulta = consultaEdicaoDto.DataConsulta;
                consulta.IdBoi = consultaEdicaoDto.BoiID;
                consulta.IdUser = consultaEdicaoDto.UserID;
                consulta.IdVeterinario = consultaEdicaoDto.VeterinarioID;

                dbContext.Update(consulta);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Consultas.ToListAsync();
                resposta.Mensagem = "Consulta editada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Consulta>>> ExcluirConsulta(int idConsulta)
        {
            Response<List<Consulta>> resposta = new Response<List<Consulta>>();

            try
            {
                var consulta = await dbContext.Consultas.FirstOrDefaultAsync(c => c.ID == idConsulta);

                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada!";
                    return resposta;
                }

                dbContext.Remove(consulta);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Consultas.ToListAsync();
                resposta.Mensagem = "Consulta removida com sucesso!";
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


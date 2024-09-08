using ApiAgroCare.Data;
using ApiAgroCare.DTOS.Boi;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace ApiAgroCare.Repository.boi
{
    public class BoiRepository : IBoi
    {
        private readonly dbContext dbContext;

        public BoiRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<List<Boi>>> ListarBois()
        {
            Response<List<Boi>> resposta = new Response<List<Boi>>();
            try
            {
                var bois = await dbContext.Bois.ToListAsync();
                resposta.Dados = bois;
                resposta.Mensagem = "Todos os bois foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<Boi>> BuscarBoiPorId(int idBoi)
        {
            Response<Boi> resposta = new Response<Boi>();
            try
            {
                var boi = await dbContext.Bois.FirstOrDefaultAsync(b => b.Id == idBoi);
                if (boi == null)
                {
                    resposta.Mensagem = "Nenhum boi localizado!";
                    return resposta;
                }

                resposta.Dados = boi;
                resposta.Mensagem = "Boi localizado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Boi>>> CriarBoi(BoiCriacaoDTO boiCriacaoDto)
        {
            Response<List<Boi>> resposta = new Response<List<Boi>>();

            try
            {
                // Verifique se o usuário existe com base no UserID fornecido
                var userDono = await dbContext.Users.FindAsync(boiCriacaoDto.IdUser);
                if (userDono == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                // Criação do novo boi com associação ao UserDono
                var novoBoi = new Boi
                {
                    Saude = boiCriacaoDto.Saude,
                    UltimoDiaAtualizacao = DateTime.Now,
                    SaudeBoi = boiCriacaoDto.SaudeBoi,
                    UserID = userDono.ID,  // Associa o ID do usuário como dono
                    UserDono = userDono,   // Associa a entidade User como dono
                };

                dbContext.Bois.Add(novoBoi);
                await dbContext.SaveChangesAsync();

                // Retorne a lista atualizada de bois
                resposta.Dados = await dbContext.Bois.ToListAsync();
                resposta.Mensagem = "Boi criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<Response<List<Boi>>> EditarBoi(BoiEditarDTO boiEdicaoDto)
        {
            Response<List<Boi>> resposta = new Response<List<Boi>>();
            try
            {
                var boi = await dbContext.Bois.FirstOrDefaultAsync(b => b.Id == boiEdicaoDto.Id);

                if (boi == null)
                {
                    resposta.Mensagem = "Nenhum boi localizado!";
                    return resposta;
                }

                boi.Saude = boiEdicaoDto.Saude;
                boi.UltimoDiaAtualizacao = boiEdicaoDto.UltimoDiaAtualizacao;
                boi.SaudeBoi = boiEdicaoDto.SaudeBoi;
                boi.UserID = boiEdicaoDto.UserID;
                boi.ConsultaID = boiEdicaoDto.ConsultaID;

                dbContext.Update(boi);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Bois.ToListAsync();
                resposta.Mensagem = "Boi editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Boi>>> ExcluirBoi(int idBoi)
        {
            Response<List<Boi>> resposta = new Response<List<Boi>>();

            try
            {
                var boi = await dbContext.Bois.FirstOrDefaultAsync(b => b.Id == idBoi);

                if (boi == null)
                {
                    resposta.Mensagem = "Nenhum boi localizado!";
                    return resposta;
                }

                dbContext.Remove(boi);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Bois.ToListAsync();
                resposta.Mensagem = "Boi removido com sucesso!";
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

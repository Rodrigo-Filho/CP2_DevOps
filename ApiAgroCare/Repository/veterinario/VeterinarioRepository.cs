using ApiAgroCare.Data;
using ApiAgroCare.DTOS.Veterinario;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAgroCare.Repository.veterinario
{
    public class VeterinarioRepository: IVeterinario
    {
        private readonly dbContext dbContext;

        public VeterinarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Response<Veterinario>> BuscarVeterinarioPorId(int idVeterinario)
        {
            Response<Veterinario> resposta = new Response<Veterinario>();
            try
            {
                var veterinario = await dbContext.Veterinarios.FirstOrDefaultAsync(vet => vet.Id == idVeterinario);

                if (veterinario == null)
                {
                    resposta.Mensagem = "Nenhum veterinário localizado!";
                    return resposta;
                }

                resposta.Dados = veterinario;
                resposta.Mensagem = "Veterinário localizado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Veterinario>>> CriarVeterinario(VeterinarioCriacaoDTO veterinarioCriacaoDto)
        {
            Response<List<Veterinario>> resposta = new Response<List<Veterinario>>();

            try
            {
                var veterinario = new Veterinario
                {
                    Name = veterinarioCriacaoDto.Nome,
                    Especialidade = veterinarioCriacaoDto.Especialidade,
                    NumCrmv = veterinarioCriacaoDto.CRMV,
                    Telefone = veterinarioCriacaoDto.Telefone,
                    Email = veterinarioCriacaoDto.Email,
                    Password = veterinarioCriacaoDto.Password
                };

                dbContext.Add(veterinario);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Veterinarios.ToListAsync();
                resposta.Mensagem = "Veterinário criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Veterinario>>> EditarVeterinario(VeterinarioEditarDTO veterinarioEdicaoDto)
        {
            Response<List<Veterinario>> resposta = new Response<List<Veterinario>>();
            try
            {
                var veterinario = await dbContext.Veterinarios.FirstOrDefaultAsync(vet => vet.Id == veterinarioEdicaoDto.Id);

                if (veterinario == null)
                {
                    resposta.Mensagem = "Nenhum veterinário localizado!";
                    return resposta;
                }

                veterinario.Name = veterinarioEdicaoDto.Nome;
                veterinario.Especialidade = veterinarioEdicaoDto.Especialidade;
                veterinario.NumCrmv = veterinarioEdicaoDto.CRMV;
                veterinario.Telefone = veterinarioEdicaoDto.Telefone;
                veterinario.Email = veterinarioEdicaoDto.Email;
                veterinario.Password = veterinarioEdicaoDto.Password;

                dbContext.Update(veterinario);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Veterinarios.ToListAsync();
                resposta.Mensagem = "Veterinário editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Veterinario>>> ExcluirVeterinario(int idVeterinario)
        {
            Response<List<Veterinario>> resposta = new Response<List<Veterinario>>();

            try
            {
                var veterinario = await dbContext.Veterinarios.FirstOrDefaultAsync(vet => vet.Id == idVeterinario);

                if (veterinario == null)
                {
                    resposta.Mensagem = "Nenhum veterinário localizado!";
                    return resposta;
                }

                dbContext.Remove(veterinario);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Veterinarios.ToListAsync();
                resposta.Mensagem = "Veterinário removido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Veterinario>>> ListarVeterinarios()
        {
            Response<List<Veterinario>> resposta = new Response<List<Veterinario>>();
            try
            {
                var veterinarios = await dbContext.Veterinarios.ToListAsync();

                resposta.Dados = veterinarios;
                resposta.Mensagem = "Todos os veterinários foram coletados!";
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


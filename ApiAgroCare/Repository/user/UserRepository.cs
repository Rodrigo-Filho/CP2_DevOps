using ApiAgroCare.Data;
using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAgroCare.Repository.user
{
    public class UserRepository : IUser
    {
        private readonly dbContext dbContext;

        public UserRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<User>> BuscarUsuarioPorId(int idUsuario)
        {
            Response<User> resposta = new Response<User>();
            try
            {
                var usuario = await dbContext.Users.FirstOrDefaultAsync(user => user.ID == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário localizado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<User>>> CriarUsuario(UserCriacaoDTO userCriacaoDto)
        {
            Response<List<User>> resposta = new Response<List<User>>();

            try
            {
                var usuario = new User
                {
                    Name = userCriacaoDto.Name,
                    Number = userCriacaoDto.Number,
                    Endereco = userCriacaoDto.Endereco,
                    NumerosAnimais = userCriacaoDto.NumerosAnimais,
                    Email = userCriacaoDto.Email,
                    Password = userCriacaoDto.Password,
                    Status = userCriacaoDto.Status,
                    Planos = userCriacaoDto.Planos
                };

                dbContext.Add(usuario);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Users.ToListAsync();
                resposta.Mensagem = "Usuário criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<User>>> EditarUsuario(UserEditarDTO userEdicaoDto)
        {
            Response<List<User>> resposta = new Response<List<User>>();
            try
            {
                var usuario = await dbContext.Users.FirstOrDefaultAsync(user => user.ID == userEdicaoDto.Id);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuário localizado!";
                    return resposta;
                }

                usuario.Name = userEdicaoDto.Name;
                usuario.Number = userEdicaoDto.Number;
                usuario.Endereco = userEdicaoDto.Endereco;
                usuario.NumerosAnimais = userEdicaoDto.NumerosAnimais;
                usuario.Email = userEdicaoDto.Email;
                usuario.Password = userEdicaoDto.Password;
                usuario.Status = userEdicaoDto.Status;
                usuario.Planos = userEdicaoDto.Planos;

                dbContext.Update(usuario);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Users.ToListAsync();
                resposta.Mensagem = "Usuário editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<User>>> ExcluirUsuario(int idUsuario)
        {
            Response<List<User>> resposta = new Response<List<User>>();

            try
            {
                var usuario = await dbContext.Users.FirstOrDefaultAsync(user => user.ID == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuário localizado!";
                    return resposta;
                }

                dbContext.Remove(usuario);
                await dbContext.SaveChangesAsync();

                resposta.Dados = await dbContext.Users.ToListAsync();
                resposta.Mensagem = "Usuário removido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<User>>> ListarUsuarios()
        {
            Response<List<User>> resposta = new Response<List<User>>();
            try
            {
                var usuarios = await dbContext.Users.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Mensagem = "Todos os usuários foram coletados!";
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

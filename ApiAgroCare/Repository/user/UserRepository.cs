using ApiAgroCare.Data;
using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAgroCare.Repository.user
{
    public class UserRepository : IUser
    {
        private readonly dbContext dbContext;
        private readonly IConfiguration _configuration;

        public UserRepository(dbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Response<UserDTO>> BuscarUsuarioPorId(int idUsuario)
        {
            Response<UserDTO> resposta = new Response<UserDTO>();
            try
            {
                var usuario = await dbContext.Users.FirstOrDefaultAsync(user => user.ID == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                var usuarioDto = new UserDTO
                {
                    Id = usuario.ID,
                    Name = usuario.Name,
                    Number = usuario.Number,
                    Endereco = usuario.Endereco,
                    NumerosAnimais = usuario.NumerosAnimais,
                    Email = usuario.Email,
                    Status = usuario.Status,
                    Planos = usuario.Planos
                };

                resposta.Dados = usuarioDto;
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

        public async Task<Response<User>> CriarUsuario(UserCriacaoDTO userCriacaoDto)
        {
            Response<User> resposta = new Response<User>(); // Alterado para Response<User>

            try
            {
                // Gerar o hash da senha usando BCrypt
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCriacaoDto.Password);

                // Criar o objeto User com os dados fornecidos e o hash da senha
                var usuario = new User
                {
                    Name = userCriacaoDto.Name,
                    Number = userCriacaoDto.Number,
                    Endereco = userCriacaoDto.Endereco,
                    NumerosAnimais = userCriacaoDto.NumerosAnimais,
                    Email = userCriacaoDto.Email,
                    Password = hashedPassword, // Usar o hash no lugar da senha em texto plano
                    Status = userCriacaoDto.Status,
                    Planos = userCriacaoDto.Planos
                };

                // Adicionar o novo usuário ao contexto do banco de dados
                dbContext.Add(usuario);
                await dbContext.SaveChangesAsync();

                // Não retornar o campo de senha
                var usuarioSemSenha = new User
                {
                    ID = usuario.ID,
                    Name = usuario.Name,
                    Number = usuario.Number,
                    Endereco = usuario.Endereco,
                    NumerosAnimais = usuario.NumerosAnimais,
                    Email = usuario.Email,
                    Status = usuario.Status,
                    Planos = usuario.Planos
                };

                // Preparar a resposta com o usuário criado
                resposta.Dados = usuarioSemSenha; // Atribuindo o usuário criado
                resposta.Mensagem = "Usuário criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna a mensagem de erro
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
                // Buscar o usuário existente no banco de dados pelo ID
                var usuarioExistente = await dbContext.Users.FindAsync(userEdicaoDto.Id);
                if (usuarioExistente == null)
                {
                    resposta.Mensagem = "Usuário não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                // Atualizar os campos fornecidos no DTO
                usuarioExistente.Name = userEdicaoDto.Name;
                usuarioExistente.Number = userEdicaoDto.Number;
                usuarioExistente.Endereco = userEdicaoDto.Endereco;
                usuarioExistente.NumerosAnimais = userEdicaoDto.NumerosAnimais;
                usuarioExistente.Email = userEdicaoDto.Email;
                usuarioExistente.Status = userEdicaoDto.Status;
                usuarioExistente.Planos = userEdicaoDto.Planos;

                // Verificar se a senha foi alterada e, se sim, gerar um novo hash
                if (!string.IsNullOrEmpty(userEdicaoDto.Password))
                {
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userEdicaoDto.Password);
                    usuarioExistente.Password = hashedPassword;
                }

                // Salvar as alterações no banco de dados
                dbContext.Update(usuarioExistente);
                await dbContext.SaveChangesAsync();

                // Preparar a resposta com a lista de usuários atualizada
                resposta.Dados = await dbContext.Users.ToListAsync();
                resposta.Mensagem = "Usuário editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna a mensagem de erro
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

        public async Task<Response<List<UserDTO>>> ListarUsuarios()
        {
            Response<List<UserDTO>> resposta = new Response<List<UserDTO>>();
            try
            {
                var usuarios = await dbContext.Users.ToListAsync();

                var usuariosDto = usuarios.Select(usuario => new UserDTO
                {
                    Id = usuario.ID,
                    Name = usuario.Name,
                    Number = usuario.Number,
                    Endereco = usuario.Endereco,
                    NumerosAnimais = usuario.NumerosAnimais,
                    Email = usuario.Email,
                    Status = usuario.Status,
                    Planos = usuario.Planos
                }).ToList();

                resposta.Dados = usuariosDto;
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
        public async Task<User> BuscarUsuarioPorEmail(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Response<string>> Login(UserLoginDTO userLoginDto)
        {
            Response<string> resposta = new Response<string>();

            // Buscar o usuário pelo e-mail
            var user = await BuscarUsuarioPorEmail(userLoginDto.Email);
            if (user == null)
            {
                resposta.Mensagem = "Usuário não encontrado.";
                resposta.Status = false;
                return resposta;
            }

            // Verificar se a senha está correta usando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                resposta.Mensagem = "Senha inválida.";
                resposta.Status = false;
                return resposta;
            }

            // Gerar o token JWT
            var token = GenerateJwtToken(user);
            resposta.Dados = token;
            resposta.Status = true;
            resposta.Mensagem = "Login realizado com sucesso.";

            return resposta;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}


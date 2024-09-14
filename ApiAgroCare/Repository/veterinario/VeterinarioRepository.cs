using ApiAgroCare.Data;
using ApiAgroCare.DTOS.Veterinario;
using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAgroCare.Repository.veterinario
{
    public class VeterinarioRepository : IVeterinario
    {
        private readonly dbContext dbContext;
        private readonly IConfiguration _configuration;

        public VeterinarioRepository(dbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<Response<VeterinarioDTO>> BuscarVeterinarioPorId(int idVeterinario)
        {
            Response<VeterinarioDTO> resposta = new Response<VeterinarioDTO>();
            try
            {
                var veterinario = await dbContext.Veterinarios.FirstOrDefaultAsync(vet => vet.Id == idVeterinario);

                if (veterinario == null)
                {
                    resposta.Mensagem = "Nenhum veterinário localizado!";
                    return resposta;
                }

                var veterinarioDto = new VeterinarioDTO
                {
                    Id = veterinario.Id,
                    Name = veterinario.Name,
                    Especialidade = veterinario.Especialidade,
                    NumCrmv = veterinario.NumCrmv,
                    Telefone = veterinario.Telefone,
                    Email = veterinario.Email,

                };

                resposta.Dados = veterinarioDto;
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

        public async Task<Response<Veterinario>> CriarVeterinario(VeterinarioCriacaoDTO veterinarioCriacaoDto)
        {
            Response<Veterinario> resposta = new Response<Veterinario>();

            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(veterinarioCriacaoDto.Password);

                var veterinario = new Veterinario
                {
                    Name = veterinarioCriacaoDto.Nome,
                    Especialidade = veterinarioCriacaoDto.Especialidade,
                    NumCrmv = veterinarioCriacaoDto.CRMV,
                    Telefone = veterinarioCriacaoDto.Telefone,
                    Email = veterinarioCriacaoDto.Email,
                    Password = hashedPassword

                };

                dbContext.Add(veterinario);
                await dbContext.SaveChangesAsync();

                // Não retornar o campo de senha
                var veterinarioSemSenha = new Veterinario
                {
                    Id = veterinario.Id,
                    Name = veterinario.Name,
                    Especialidade = veterinario.Especialidade,
                    NumCrmv = veterinario.NumCrmv,
                    Telefone = veterinario.Telefone,
                    Email = veterinario.Email,

                };

                resposta.Dados = veterinarioSemSenha;
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

                if (!string.IsNullOrEmpty(veterinarioEdicaoDto.Password))
                {
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(veterinarioEdicaoDto.Password);
                    veterinario.Password = hashedPassword;
                }

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

        public async Task<Response<List<VeterinarioDTO>>> ListarVeterinarios()
        {
            Response<List<VeterinarioDTO>> resposta = new Response<List<VeterinarioDTO>>();
            try
            {
                var veterinarios = await dbContext.Veterinarios.ToListAsync();

                var veterinariosDto = veterinarios.Select(veterinario => new VeterinarioDTO
                {
                    Id = veterinario.Id,
                    Name = veterinario.Name,
                    Especialidade = veterinario.Especialidade,
                    NumCrmv = veterinario.NumCrmv,
                    Telefone = veterinario.Telefone,
                    Email = veterinario.Email

                }).ToList();

                resposta.Dados = veterinariosDto;
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

        public async Task<Veterinario> BuscarVeterinarioPorEmail(string email)
        {
            return await dbContext.Veterinarios.FirstOrDefaultAsync(vet => vet.Email == email);
        }

        public async Task<Response<string>> Login(VeterinarioLoginDTO veterinarioLoginDto)
        {
            Response<string> resposta = new Response<string>();

            var veterinario = await BuscarVeterinarioPorEmail(veterinarioLoginDto.Email);
            if (veterinario == null)
            {
                resposta.Mensagem = "Veterinário não encontrado.";
                resposta.Status = false;
                return resposta;
            }

            if (!BCrypt.Net.BCrypt.Verify(veterinarioLoginDto.Password, veterinario.Password))
            {
                resposta.Mensagem = "Senha inválida.";
                resposta.Status = false;
                return resposta;
            }

            var token = GenerateJwtToken(veterinario);
            resposta.Dados = token;
            resposta.Status = true;
            resposta.Mensagem = "Login realizado com sucesso.";

            return resposta;
        }

        private string GenerateJwtToken(Veterinario veterinario)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, veterinario.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, veterinario.Email),
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
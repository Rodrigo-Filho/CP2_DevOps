using ApiAgroCare.DTOS.User;
using ApiAgroCare.Model;
using ApiAgroCare.Repository.user;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAgroCare.AuthService
{
    public class AuthService
    {
        private readonly IUser _userRepository;
        private readonly IConfiguration _configuration;


        public AuthService(IUser userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Response<string>> Login(UserLoginDTO userLoginDto)
        {
            // Buscar o usuário pelo e-mail
            var user = await _userRepository.BuscarUsuarioPorEmail(userLoginDto.Email);
            if (user == null)
            {
                return new Response<string> { Status = false, Mensagem = "Usuário não encontrado." };
            }

            // Verificar se a senha está correta usando hash (BCrypt)
            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                return new Response<string> { Status = false, Mensagem = "Senha inválida." };
            }

            // Gerar o token JWT
            var token = GenerateJwtToken(user);

            return new Response<string> { Status = true, Dados = token };
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
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
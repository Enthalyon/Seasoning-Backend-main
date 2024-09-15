using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SeasoningAndCandle.Backend.Application.Services.Interfaces;
using SeasoningAndCandle.Backend.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmployeesAPI2.Application.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly SymmetricSecurityKey key;
        public AuthentificationService(IConfiguration configuration)
        {
            // Obtener la clave secreta
            string secretKey = configuration["JWT:Key"];
            key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        }

        public (string, DateTime) GenerateToken(User user)
        {
            // Definir los claims del token
            Claim[] claims =
            [
                new Claim("user_name", user.Email),
                new Claim("first_Name", user.FirstName),
                new Claim("last_Name", user.LastName),
                new Claim("iat", DateTime.UtcNow.ToLongTimeString())
            ];

            DateTime expirationDate = DateTime.UtcNow.AddHours(24);

            // Definir los parámetros del token
            SecurityTokenDescriptor tokenParams = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256)
            };

            // Crear el token
            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenParams);

            // Obtener el token en formato string
            return (tokenHandler.WriteToken(token), expirationDate);
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
        }
    }
}

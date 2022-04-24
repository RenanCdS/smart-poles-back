using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Services;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SmartPoles.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _config.GetValue<string>("JwtSecret");
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("CondominiumId", user.CondominiumId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
         
        public string GenerateSaltedHash(string plainText, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                        password: plainText,
                        salt: Encoding.UTF8.GetBytes(salt),
                        prf: KeyDerivationPrf.HMACSHA512,
                        iterationCount: 10000,
                        numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public bool IsHashValid(string value, string salt, string hash)
        => GenerateSaltedHash(value, salt) == hash;
    }
}

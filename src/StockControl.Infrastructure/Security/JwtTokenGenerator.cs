using Microsoft.IdentityModel.Tokens;
using StockControl.Domain.Entities;
using StockControl.Domain.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockControl.Infrastructure.Security
{
    internal class JwtTokenGenerator : IAcessTokenGenerator
    {
        private readonly uint _expirationTimeMinutes;
        private readonly string _singinKey;

        public JwtTokenGenerator(uint expirationTimeMinutes, string singinKey)
        {
            _expirationTimeMinutes = expirationTimeMinutes;
            _singinKey = singinKey;
        }

        public string Generate(User user)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var keyBytes = Encoding.UTF8.GetBytes(_singinKey);
            return new SymmetricSecurityKey(keyBytes);
        }
    }
}
using EasyMeterAPP.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyMeterAPP.Services
{
    public class TokenService : ITokenService
    {
        public string GerarToken(string key, string issuer, UserDTO user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.User),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, 
                                             claims: claims, 
                                             expires: DateTime.Now.AddHours(2),
                                             signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;

        }
    }
}

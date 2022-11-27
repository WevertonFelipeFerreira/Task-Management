using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tasking.Management.CrossCutting.Utils;
using Tasking.Management.Domain.Services;

namespace Tasking.Management.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _cfg;
        public AuthService(IConfiguration cfg)
        {
            _cfg = cfg;
        }
        public string ComputeSha256Hash(string password)
        {
            return Encrypt.Sha256(password);
        }

        public string GenerateUserJwtToken(Guid userId, string email, string role)
        {
            var issuer = _cfg["Jwt:Issuer"];
            var audience = _cfg["Jwt:Audience"];
            var key = _cfg["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim("sub", userId.ToString()),
                new Claim("iat", Date.GetCurrentUnixTime()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials,
                claims: claims
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringStoken = tokenHandler.WriteToken(token);

            return stringStoken;
        }
    }
}

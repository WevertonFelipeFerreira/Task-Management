using Microsoft.Extensions.Configuration;
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
            throw new NotImplementedException();
        }

        public string GenerateJwtToken(string email, string role)
        {
            throw new NotImplementedException();
        }
    }
}

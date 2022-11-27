namespace Tasking.Management.Domain.Services
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
        string GenerateUserJwtToken(Guid userId, string email, string role);
    }
}

using Tasking.Management.Domain.Entities;

namespace Tasking.Management.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmail(string email);
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(Guid id);
    }
}

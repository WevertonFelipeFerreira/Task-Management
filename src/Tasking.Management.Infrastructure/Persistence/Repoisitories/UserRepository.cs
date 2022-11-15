using Microsoft.EntityFrameworkCore;
using Tasking.Management.Domain.Entities;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Infrastructure.Persistence.Repoisitories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDbContext _dbContext;
        public UserRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User entity)
        {
            await _dbContext.Users!.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext!.Users!.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

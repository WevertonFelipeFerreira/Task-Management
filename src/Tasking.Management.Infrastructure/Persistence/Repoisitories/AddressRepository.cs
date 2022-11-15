using Microsoft.EntityFrameworkCore;
using Tasking.Management.Domain.Entities;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Infrastructure.Persistence.Repoisitories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public AddressRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address?> GetByUserId(Guid userId)
        {
            return await _dbContext!.Address!.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task Update(Address entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Property(x => x.CreatedAt).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }
    }
}

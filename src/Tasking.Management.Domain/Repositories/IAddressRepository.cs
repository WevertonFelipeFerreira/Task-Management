using Tasking.Management.Domain.Entities;

namespace Tasking.Management.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task<Address?> GetByUserId(Guid userId);
        Task Update(Address entity);
    }
}

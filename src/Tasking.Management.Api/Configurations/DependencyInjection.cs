using Tasking.Management.Domain.Repositories;
using Tasking.Management.Infrastructure.Persistence.Repoisitories;

namespace Tasking.Management.API.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Tasking.Management.Infrastructure;

namespace Tasking.Management.API.Configurations
{
    public static class DbConfig
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("TaskingManagement");

            services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(connectionsString));
        }
    }
}

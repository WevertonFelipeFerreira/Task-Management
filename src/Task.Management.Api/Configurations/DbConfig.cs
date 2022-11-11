using Microsoft.EntityFrameworkCore;
using Task.Management.Infrastructure.Contexts;

namespace Task.Management.API.Configurations
{
    public static class DbConfig
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("TaskManagement");

            services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(connectionsString));
        }
    }
}

using MediatR;
using Tasking.Management.Application.Commands.CreateUser;

namespace Tasking.Management.API.Configurations
{
    public static class MediatorConfig
    {
        public static void AddMediators(this IServiceCollection services)
        {
            services.AddMediatR(
                    typeof(CreateUserCommand)
                );
        }
    }
}

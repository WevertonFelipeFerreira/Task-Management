using MediatR;
using Task.Management.Application.Commands.CreateUser;

namespace Task.Management.API.Configurations
{
    public static class MeadiatorConfig
    {
        public static void AddMediators(this IServiceCollection services)
        {
            services.AddMediatR(
                    typeof(CreateUserCommand)
                );
        }
    }
}

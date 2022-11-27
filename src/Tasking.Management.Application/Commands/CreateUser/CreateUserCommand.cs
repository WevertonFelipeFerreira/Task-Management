using MediatR;
using System.Text.Json.Serialization;
using Tasking.Management.Application.ViewModels;

namespace Tasking.Management.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }

        [JsonIgnore]
        public string? HashPassword { get; set; }
    }
}

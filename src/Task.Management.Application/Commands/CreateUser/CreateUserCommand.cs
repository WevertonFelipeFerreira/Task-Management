using MediatR;

namespace Task.Management.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}

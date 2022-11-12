using MediatR;
using Tasking.Management.Domain.Entities;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User(
                    request.Email!,
                    request.Password!,
                    request.Name!,
                    request.LastName!
                );

            await _userRepository.AddAsync(entity);

            return entity.Id;
        }
    }
}

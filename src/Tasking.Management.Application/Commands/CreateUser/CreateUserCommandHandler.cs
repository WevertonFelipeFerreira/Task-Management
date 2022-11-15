using MediatR;
using Tasking.Management.Application.ViewModels;
using Tasking.Management.Domain.Entities;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO Implement AutoMaper
            //TODO Implement scenario where exists a user with the given email 
            var entity = new User(
                    request.Email!,
                    request.Password!,
                    request.Name!,
                    request.LastName!
                );

            await _userRepository.AddAsync(entity);

            var userVM = new CreateUserViewModel
            {
                UserId = entity.Id,
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
            };

            return userVM;
        }
    }
}

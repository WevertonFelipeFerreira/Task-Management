using AutoMapper;
using MediatR;
using Tasking.Management.Application.ViewModels;
using Tasking.Management.Domain.Entities;
using Tasking.Management.Domain.Exceptions;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email!);
            if (user != null) throw new UserAlreadyExistException();

            var entity = _mapper.Map<User>(request);
            await _userRepository.AddAsync(entity);

            return _mapper.Map<CreateUserViewModel>(entity);
        }
    }
}

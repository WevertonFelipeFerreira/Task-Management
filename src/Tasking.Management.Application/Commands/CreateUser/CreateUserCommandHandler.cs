using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Tasking.Management.Application.Common;
using Tasking.Management.Application.ViewModels;
using Tasking.Management.Domain.Entities;
using Tasking.Management.Domain.Exceptions;
using Tasking.Management.Domain.Repositories;
using Tasking.Management.Domain.Services;

namespace Tasking.Management.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : BaseHandler, IRequestHandler<CreateUserCommand, CreateUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService, IHttpContextAccessor contextAcessor, IMapper mapper) : base(contextAcessor)
        {
            _mapper = mapper;
            _authService = authService;
            _userRepository = userRepository;
            _contextAccessor = contextAcessor;
        }

        public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email!);
            //TODO Create resource message
            if (user != null) throw new UserAlreadyExistException("User Already Exist", "A user with the provided email already exists.", _contextAccessor);

            var hashPassword = _authService.ComputeSha256Hash(request.Password!);

            var entity = _mapper.Map<CreateUserCommand, User>(request, opt =>
                    opt.AfterMap((src, dest) => dest.Password = src.Password = hashPassword));

            await _userRepository.AddAsync(entity);

            //TODO remove after implement login route
            var jwt = _authService.GenerateUserJwtToken(entity.Id, entity.Email, "user");

            return _mapper.Map<CreateUserViewModel>(entity);
        }
    }
}

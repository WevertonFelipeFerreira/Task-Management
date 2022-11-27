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
        private readonly IHttpContextAccessor _contextAcessor;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository,IAuthService authService, IHttpContextAccessor contextAcessor, IMapper mapper)
        {
            _mapper = mapper;
            _authService = authService;
            _contextAcessor = contextAcessor;
            _userRepository = userRepository;
        }

        public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email!);
            if (user != null) throw new UserAlreadyExistException();

            request.HashPassword = _authService.ComputeSha256Hash(request.Password!);

            var entity = _mapper.Map<User>(request);
            await _userRepository.AddAsync(entity);

            #region Excluir depois
            var jwt = _authService.GenerateUserJwtToken(entity.Id, entity.Email, "user");
            
            #endregion

            return _mapper.Map<CreateUserViewModel>(entity);
        }
    }
}

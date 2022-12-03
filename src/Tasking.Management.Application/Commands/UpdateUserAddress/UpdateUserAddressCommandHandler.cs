using MediatR;
using Microsoft.AspNetCore.Http;
using Tasking.Management.Application.Common;
using Tasking.Management.Domain.Exceptions;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Application.Commands.UpdateUserAddress
{
    public class UpdateUserAddressCommandHandler : BaseHandler, IRequestHandler<UpdateUserAddressCommand, Unit>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateUserAddressCommandHandler(IAddressRepository addressRepository, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _addressRepository = addressRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<Unit> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            //TODO create exception for this case
            if (!IsValidUser(request.UserId))
                throw new ArgumentException("deu merda");

            var userAddress = await _addressRepository.GetByUserId(request.UserId);
            if (userAddress is null) throw new UserNotExistException("User Not Exist", "It was not possible to update address for a user that does not exist.", _contextAccessor);

            userAddress!.Update(request.Street, request.Number, request.City, request.State, request.ZipCode);
            await _addressRepository.Update(userAddress);

            return Unit.Value;
        }
    }
}

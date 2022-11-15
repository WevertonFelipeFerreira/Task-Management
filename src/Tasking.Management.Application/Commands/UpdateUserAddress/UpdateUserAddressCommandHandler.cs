using MediatR;
using Tasking.Management.Domain.Repositories;

namespace Tasking.Management.Application.Commands.UpdateUserAddress
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, Unit>
    {
        private readonly IAddressRepository _addressRepository;
        public UpdateUserAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Unit> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _addressRepository.GetByUserId(request.UserId);
            //if(userAddress is null) //TODO Throw error 'User not exist'

            userAddress!.Update(request.Street, request.Number, request.City, request.State, request.ZipCode);
            await _addressRepository.Update(userAddress);

            return Unit.Value;
        }
    }
}

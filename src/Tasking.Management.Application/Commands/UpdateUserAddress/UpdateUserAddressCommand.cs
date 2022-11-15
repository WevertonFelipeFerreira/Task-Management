using MediatR;
using System.Text.Json.Serialization;

namespace Tasking.Management.Application.Commands.UpdateUserAddress
{
    public class UpdateUserAddressCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string? Street { get; set; }
        public long? Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}

using System.Text.Json.Serialization;
using Task.Management.Domain.Common.Entities;

namespace Task.Management.Domain.Entities
{
    public class Address : EntityBase
    {
        public Address()
        {

        }

        public string? Street { get; protected set; }
        public long? Number { get; protected set; }
        public string? City { get; protected set; }
        public string? State { get; protected set; }
        public string? ZipCode { get; protected set; }

        [JsonIgnore]
        public Guid? UserId { get; protected set; }
        [JsonIgnore]
        public User? User { get; protected set; }

    }
}

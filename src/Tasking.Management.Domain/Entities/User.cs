using Tasking.Management.Domain.Common.Entities;
using Tasking.Management.Domain.Interfaces;

namespace Tasking.Management.Domain.Entities
{
    public class User : EntityBase, IAuditable
    {
        public User(string email, string password, string name, string lastName)
        {
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            Address = new Address();

            SetCreatedDate();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

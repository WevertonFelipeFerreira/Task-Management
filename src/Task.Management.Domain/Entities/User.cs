using Task.Management.Domain.Common.Entities;
using Task.Management.Domain.Interfaces;

namespace Task.Management.Domain.Entities
{
    public class User : EntityBase, IAuditable
    {
        public User(string email, string password, string name, string lastName, DateTime deletedAt)
        {
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            Address = new Address();
            DeletedAt = deletedAt;

            SetCreatedDate();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}

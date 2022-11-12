using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasking.Management.Domain.Entities;

namespace Tasking.Management.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithOne(x=> x.Address)
                .HasForeignKey(typeof(Address),"UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Management.Domain.Entities;

namespace Task.Management.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

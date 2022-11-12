using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tasking.Management.Domain.Entities;

namespace Tasking.Management.Infrastructure
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Address>? Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

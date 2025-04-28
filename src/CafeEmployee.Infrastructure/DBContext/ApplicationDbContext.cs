using CafeEmployee.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeEmployee.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Cafe> Cafes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enforce unique constraint on Employee.Id
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Id)
                .IsUnique();

            // One Cafe can have many Employees
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Cafe)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CafeId);
        }
    }
}
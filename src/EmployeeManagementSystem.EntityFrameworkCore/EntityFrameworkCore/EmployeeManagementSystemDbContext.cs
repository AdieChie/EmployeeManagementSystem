using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EmployeeManagementSystem.Authorization.Roles;
using EmployeeManagementSystem.Authorization.Users;
using EmployeeManagementSystem.MultiTenancy;
using EmployeeManagementSystem.Domain.Employees;
using EmployeeManagementSystem.Domain.Addresses;
using EmployeeManagementSystem.Domain.Skills;

namespace EmployeeManagementSystem.EntityFrameworkCore
{
    public class EmployeeManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, EmployeeManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public EmployeeManagementSystemDbContext(DbContextOptions<EmployeeManagementSystemDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(b =>
            {
                b.HasMany(e => e.Skills)
                  .WithOne(s => s.Employee)
                  .HasForeignKey(s => s.EmployeeId);
            });
        }
    }
}

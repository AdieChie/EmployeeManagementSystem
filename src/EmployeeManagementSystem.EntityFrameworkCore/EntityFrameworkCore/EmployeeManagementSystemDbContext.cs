using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EmployeeManagementSystem.Authorization.Roles;
using EmployeeManagementSystem.Authorization.Users;
using EmployeeManagementSystem.MultiTenancy;

namespace EmployeeManagementSystem.EntityFrameworkCore
{
    public class EmployeeManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, EmployeeManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public EmployeeManagementSystemDbContext(DbContextOptions<EmployeeManagementSystemDbContext> options)
            : base(options)
        {
        }
    }
}

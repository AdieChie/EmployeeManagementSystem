using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.EntityFrameworkCore
{
    public static class EmployeeManagementSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EmployeeManagementSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EmployeeManagementSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

using CrudEFbyMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEFbyMigration.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole>UserRoles { get; set; }

    }
}

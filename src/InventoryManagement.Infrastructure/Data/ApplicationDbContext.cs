using Microsoft.EntityFrameworkCore;
using InventoryManagement.Core.Models.Entities;

namespace InventoryManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

    }
}

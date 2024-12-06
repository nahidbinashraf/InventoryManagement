using Microsoft.EntityFrameworkCore;
using InventoryManagement.Core.Models.Entities;

namespace InventoryManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SalesDetail> SalesDetails { get; set; }

        public DbSet<StockAdjustment> StockAdjustments { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

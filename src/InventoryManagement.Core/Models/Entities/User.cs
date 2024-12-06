using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Role { get; set; } = null!;

    public bool IsActive { get; set; }


    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }


    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [InverseProperty("CreateUserNavigation")]
    public ICollection<AuditLog> AuditLogCreateUserNavigations { get; set; } = new List<AuditLog>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<AuditLog> AuditLogLastUpdateUserNavigations { get; set; } = new List<AuditLog>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Category> CategoryCreateUserNavigations { get; set; } = new List<Category>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Category> CategoryLastUpdateUserNavigations { get; set; } = new List<Category>();

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("InverseCreateUserNavigation")]
    public User CreateUserNavigation { get; set; } = null!;

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Customer> CustomerCreateUserNavigations { get; set; } = new List<Customer>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Customer> CustomerLastUpdateUserNavigations { get; set; } = new List<Customer>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Inventory> InventoryCreateUserNavigations { get; set; } = new List<Inventory>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Inventory> InventoryLastUpdateUserNavigations { get; set; } = new List<Inventory>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<User> InverseCreateUserNavigation { get; set; } = new List<User>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<User> InverseLastUpdateUserNavigation { get; set; } = new List<User>();

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("InverseLastUpdateUserNavigation")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("CreateUserNavigation")]
    public ICollection<PaymentType> PaymentTypeCreateUserNavigations { get; set; } = new List<PaymentType>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<PaymentType> PaymentTypeLastUpdateUserNavigations { get; set; } = new List<PaymentType>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Product> ProductCreateUserNavigations { get; set; } = new List<Product>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Product> ProductLastUpdateUserNavigations { get; set; } = new List<Product>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<PurchaseOrder> PurchaseOrderCreateUserNavigations { get; set; } = new List<PurchaseOrder>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<PurchaseOrderDetail> PurchaseOrderDetailCreateUserNavigations { get; set; } = new List<PurchaseOrderDetail>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<PurchaseOrderDetail> PurchaseOrderDetailLastUpdateUserNavigations { get; set; } = new List<PurchaseOrderDetail>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<PurchaseOrder> PurchaseOrderLastUpdateUserNavigations { get; set; } = new List<PurchaseOrder>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Role> RoleCreateUserNavigations { get; set; } = new List<Role>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Role> RoleLastUpdateUserNavigations { get; set; } = new List<Role>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Sale> SaleCreateUserNavigations { get; set; } = new List<Sale>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Sale> SaleLastUpdateUserNavigations { get; set; } = new List<Sale>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<SalesDetail> SalesDetailCreateUserNavigations { get; set; } = new List<SalesDetail>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<SalesDetail> SalesDetailLastUpdateUserNavigations { get; set; } = new List<SalesDetail>();

    [InverseProperty("AdjustedByNavigation")]
    public ICollection<StockAdjustment> StockAdjustmentAdjustedByNavigations { get; set; } = new List<StockAdjustment>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<StockAdjustment> StockAdjustmentCreateUserNavigations { get; set; } = new List<StockAdjustment>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<StockAdjustment> StockAdjustmentLastUpdateUserNavigations { get; set; } = new List<StockAdjustment>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Supplier> SupplierCreateUserNavigations { get; set; } = new List<Supplier>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Supplier> SupplierLastUpdateUserNavigations { get; set; } = new List<Supplier>();

    [InverseProperty("CreateUserNavigation")]
    public ICollection<Unit> UnitCreateUserNavigations { get; set; } = new List<Unit>();

    [InverseProperty("LastUpdateUserNavigation")]
    public ICollection<Unit> UnitLastUpdateUserNavigations { get; set; } = new List<Unit>();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string SKU { get; set; } = null!;

    public string? Description { get; set; }

    public int UnitId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal VAT { get; set; }

    public int CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CategoryId))]
    [InverseProperty("Products")]
    public Category Category { get; set; } = null!;

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("ProductCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [InverseProperty("Product")]
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("ProductLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("Product")]
    public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    [InverseProperty("Product")]
    public ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();

    [InverseProperty("Product")]
    public ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();

    [ForeignKey(nameof(UnitId))]
    [InverseProperty("Products")]
    public Unit Unit { get; set; } = null!;
}
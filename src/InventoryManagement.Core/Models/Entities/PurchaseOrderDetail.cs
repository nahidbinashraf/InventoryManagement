using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class PurchaseOrderDetail
{
    [Key]
    public int PurchaseOrderDetailId { get; set; }

    public int PurchaseOrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal VAT { get; set; }


    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }


    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("PurchaseOrderDetailCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("PurchaseOrderDetailLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("PurchaseOrderDetails")]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(PurchaseOrderId))]
    [InverseProperty("PurchaseOrderDetails")]
    public PurchaseOrder PurchaseOrder { get; set; } = null!;
}
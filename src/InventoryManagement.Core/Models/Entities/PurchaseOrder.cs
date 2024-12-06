using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class PurchaseOrder
{
    [Key]
    public int PurchaseOrderId { get; set; }


    public DateTime OrderDate { get; set; }

    public int SupplierId { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }


    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("PurchaseOrderCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("PurchaseOrderLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("PurchaseOrder")]
    public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    [ForeignKey(nameof(SupplierId))]
    [InverseProperty("PurchaseOrders")]
    public Supplier Supplier { get; set; } = null!;
}
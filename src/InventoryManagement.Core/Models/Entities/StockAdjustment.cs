using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class StockAdjustment
{
    [Key]
    public int StockAdjustmentId { get; set; }

    public int ProductId { get; set; }

    [StringLength(50)]
    public string AdjustmentType { get; set; } = null!;

    public int Quantity { get; set; }

    [StringLength(255)]
    public string? Reason { get; set; }

    public int AdjustedBy { get; set; }


    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }


    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(AdjustedBy))]
    [InverseProperty("StockAdjustmentAdjustedByNavigations")]
    public User AdjustedByNavigation { get; set; } = null!;

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("StockAdjustmentCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("StockAdjustmentLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("StockAdjustments")]
    public Product Product { get; set; } = null!;
}
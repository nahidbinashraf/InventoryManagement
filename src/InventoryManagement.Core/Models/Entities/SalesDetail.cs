
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class SalesDetail
{
    [Key]
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

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
    [InverseProperty("SalesDetailCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("SalesDetailLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("SalesDetails")]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(SaleId))]
    [InverseProperty("SalesDetails")]
    public Sale Sale { get; set; } = null!;
}
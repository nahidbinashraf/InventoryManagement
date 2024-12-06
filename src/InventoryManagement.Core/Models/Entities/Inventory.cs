using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryManagement.Core.Models.Entities;

public class Inventory
{
    [Key]
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime LastUpdated { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("InventoryCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("InventoryLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("Inventories")]
    public Product Product { get; set; } = null!;
}
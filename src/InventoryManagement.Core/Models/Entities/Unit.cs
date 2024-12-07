using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class Unit
{
    [Key]
    public int UnitId { get; set; }

    [StringLength(50)]
    public string UnitName { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }


    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }


    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("UnitCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("UnitLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("Unit")]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
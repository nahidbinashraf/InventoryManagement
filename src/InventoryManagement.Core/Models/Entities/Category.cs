using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("CategoryCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("CategoryLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("Category")]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
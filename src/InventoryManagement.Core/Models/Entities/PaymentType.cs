using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

[Index(nameof(Name), IsUnique = true)]
public class PaymentType
{
    [Key]
    public int PaymentTypeId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("PaymentTypeCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("PaymentTypeLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("PaymentType")]
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
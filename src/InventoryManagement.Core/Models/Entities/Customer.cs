using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("CustomerCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("CustomerLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [InverseProperty("Customer")]
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
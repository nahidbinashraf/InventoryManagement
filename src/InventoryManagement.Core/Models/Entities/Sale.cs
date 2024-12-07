
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    public DateTime SaleDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    public int? CustomerId { get; set; }

    public int PaymentTypeId { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;


    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }


    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("SaleCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(CustomerId))]
    [InverseProperty("Sales")]
    public Customer? Customer { get; set; }

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("SaleLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(PaymentTypeId))]
    [InverseProperty("Sales")]
    public PaymentType PaymentType { get; set; } = null!;

    [InverseProperty("Sale")]
    public ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities;

public class AuditLog
{
    [Key]
    public int AuditLogId { get; set; }

    [StringLength(50)]
    public string Action { get; set; } = null!;

    [StringLength(100)]
    public string Entity { get; set; } = null!;

    public string? PreviousData { get; set; }

    public string? RecentData { get; set; }

    [StringLength(50)]
    public string? IPAddress { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateUser { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdateUser { get; set; }

    [ForeignKey(nameof(CreateUser))]
    [InverseProperty("AuditLogCreateUserNavigations")]
    public User CreateUserNavigation { get; set; } = null!;

    [ForeignKey(nameof(LastUpdateUser))]
    [InverseProperty("AuditLogLastUpdateUserNavigations")]
    public User LastUpdateUserNavigation { get; set; } = null!;
}
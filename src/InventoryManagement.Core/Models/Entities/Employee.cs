using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models.Entities
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public long DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; } = null!;

        [Required]
        public long DesignationId { get; set; }

        [ForeignKey(nameof(DesignationId))]
        public Designation Designation { get; set; } = null!;
    }

}

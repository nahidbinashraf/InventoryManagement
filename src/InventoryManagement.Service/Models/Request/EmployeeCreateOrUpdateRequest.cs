using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Service.Models.Request
{
    public class EmployeeCreateOrUpdateRequest
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        public long DepartmentId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

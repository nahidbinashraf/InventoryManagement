using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Core.Models.Entities
{
    public class Department
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];
    }

}

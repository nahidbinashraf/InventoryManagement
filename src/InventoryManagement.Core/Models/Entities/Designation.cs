using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Core.Models.Entities
{
    public class Designation
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];
    }
}

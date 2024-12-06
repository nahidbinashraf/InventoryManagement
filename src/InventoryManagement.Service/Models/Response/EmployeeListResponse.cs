namespace InventoryManagement.Service.Models.Response
{
    public class EmployeeListResponse
    {
        public long Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Department { get; set; }

        public string? Designation { get; set; }
    }
}

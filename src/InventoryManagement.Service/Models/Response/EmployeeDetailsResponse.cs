namespace InventoryManagement.Service.Models.Response
{
    public class EmployeeDetailsResponse
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Department { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}

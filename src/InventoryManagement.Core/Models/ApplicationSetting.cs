namespace InventoryManagement.Core.Models
{
    public class ApplicationSetting
    {
        public ConnectionStrings ConnectionStrings { get; set; } = null!;
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; } = null!;
    }
}

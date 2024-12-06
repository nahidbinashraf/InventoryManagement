namespace InventoryManagement.Service.Models.Response
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}

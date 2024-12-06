using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Service.Models.Request
{
    public class SearchRequest<T>
    {
        public T? SearchModelRequest { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "PageIndex cannot be less than 0.")]
        public int PageIndex { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "PageSize must be at least 1.")]
        public int PageSize { get; set; } = 10;

        public string OrderBy { get; set; } = "Id";

        public bool Ascending { get; set; } = true;
    }
}

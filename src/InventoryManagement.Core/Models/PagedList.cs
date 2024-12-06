namespace InventoryManagement.Core.Models
{
    public class PagedList<TEntity>
    {
        public PagedList(IEnumerable<TEntity> data, int totalCount, int pageIndex, int pageSize)
        {
            Data = data;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        }

        public IEnumerable<TEntity> Data { get; private set; }

        public int TotalCount { get; private set; }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }
    }
}

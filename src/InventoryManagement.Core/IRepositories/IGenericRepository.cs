using InventoryManagement.Core.Models;
using System.Linq.Expressions;

namespace InventoryManagement.Core.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> projection,
            bool trackChanges = false);

        Task<PagedList<TResult>> GetPagedAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> projection,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            Expression<Func<TResult, object>>? orderBy = null,
            bool ascending = true,
            bool trackChanges = false);

        Task<TEntity?> GetByIdAsync(long id);

        Task<TResult?> GetByIdAsync<TResult>(long id, Func<TEntity, TResult> projector);

        Task<IEnumerable<TResult>> ExecuteRawSqlAsync<TResult>(FormattableString sqlQuery);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity, params Expression<Func<TEntity, object>>[] propertiesToUpdate);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}

using Microsoft.EntityFrameworkCore;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
using InventoryManagement.Infrastructure.Data;
using System.Linq.Expressions;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entitySet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Entities => _entitySet;

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> queryProjector,
            bool trackChanges = false)
        {
            var query = trackChanges ? _entitySet : _entitySet.AsNoTracking();
            return await queryProjector(query).ToListAsync();
        }

        public async Task<PagedList<TResult>> GetPagedAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> queryProjector,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            Expression<Func<TResult, object>>? orderBy = null,
            bool ascending = true,
            bool trackChanges = false)
        {
            var query = trackChanges ? _entitySet : _entitySet.AsNoTracking();
            var projectedQuery = queryProjector(query);

            if (orderBy != null)
            {
                projectedQuery = ascending
                    ? projectedQuery.OrderBy(orderBy)
                    : projectedQuery.OrderByDescending(orderBy);
            }

            var pagedQuery = projectedQuery
                .Skip(pageIndex * pageSize)
                .Take(pageSize);

            var totalCount = await projectedQuery.CountAsync();
            var results = await pagedQuery.ToListAsync();

            return new PagedList<TResult>(results, totalCount, pageIndex, pageSize);
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return await _entitySet.FindAsync(id);
        }

        public async Task<TResult?> GetByIdAsync<TResult>(long id, Func<TEntity, TResult> projector)
        {
            TEntity? foundEntity = await _entitySet.FindAsync(id);
            return foundEntity != null ? projector(foundEntity) : default;
        }

        public async Task<IEnumerable<TResult>> ExecuteRawSqlAsync<TResult>(FormattableString sqlQuery)
        {
            return await _context
                .Database
                .SqlQuery<TResult>(sqlQuery)
                .ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entitySet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entitySet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (updatedProperties is null)
            {
                throw new ArgumentNullException(nameof(updatedProperties));
            }

            var entityEntry = _context.Entry(entity);

            if (entityEntry.State == EntityState.Detached)
            {
                _entitySet.Attach(entity);
            }

            if (updatedProperties.Length == 0)
            {
                entityEntry.State = EntityState.Modified;
            }
            else
            {
                foreach (var property in updatedProperties)
                {
                    entityEntry.Property(property).IsModified = true;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            _entitySet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _entitySet.RemoveRange(entities);
        }
    }
}

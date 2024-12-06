using Microsoft.EntityFrameworkCore.Storage;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Infrastructure.Data;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction? _currentTransaction;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new GenericRepository<T>(_dbContext);
            }

            return (IGenericRepository<T>)_repositories[typeof(T)];
        }

        public void BeginTransaction()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = _dbContext.Database.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            _currentTransaction?.Commit();
        }

        public void RollbackTransaction()
        {
            _currentTransaction?.Rollback();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _currentTransaction?.Dispose();
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}

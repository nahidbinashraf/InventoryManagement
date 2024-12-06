namespace InventoryManagement.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        Task SaveAsync();
    }

}

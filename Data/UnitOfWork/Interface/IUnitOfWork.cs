using TaskTracker.Data.Repository.Interface;

namespace TaskTracker.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Repository { get; }

        Task<bool> SaveAsync();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}

using TaskTracker.Data.Context;
using TaskTracker.Data.Repository.Interface;
using TaskTracker.Data.UnitOfWork.Interface;

namespace TaskTracker.Data.UnitOfWork.Implementation
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly TaskTrackerDbContext _dbContext;
        private IGenericRepository<T> _repository;

        public UnitOfWork(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> Repository => _repository;

        public void BeginTransaction() => _dbContext.Database.BeginTransaction();

        public void CommitTransaction() => _dbContext.Database.CommitTransaction();

        public void RollbackTransaction() => _dbContext.Database.RollbackTransaction();

        public async Task<bool> SaveAsync()
        {
            bool result = false;

            try
            {
                result = await _dbContext.SaveChangesAsync() >= 0;
            }
            catch { throw; }

            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskTracker.Data.Context;
using TaskTracker.Data.Repository.Interface;
using TaskTracker.Entities;

namespace TaskTracker.Data.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly TaskTrackerDbContext _dbContext;
        private readonly DbSet<T> table;

        public GenericRepository(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            entity.IsActive = true;
            entity.CreatedAt = DateTime.UtcNow;
            entity.LastModifiedAt = DateTime.UtcNow;

            await table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await table.AddRangeAsync(entities.Select(x =>
            {
                x.IsActive = true;
                x.CreatedAt = DateTime.UtcNow;
                x.LastModifiedAt = DateTime.UtcNow;
                return x;
            }));
        }

        public async Task DeleteAsync(Guid EntityId)
        {
            var entity = await ReadSingleAsync(EntityId);
            table.Remove(entity);
        }

        public void DeleteRange(IList<T> entities)
        {
            table.RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await table.Where(x => x.IsActive)
                              .OrderByDescending(e => e.CreatedAt)
                              .ToListAsync();
        }

        public IQueryable<T> ReadAllQuery()
        {
            return table.Where(x => x.IsActive)
                        .OrderByDescending(e => e.CreatedAt)
                        .AsQueryable();
        }

        public async Task<T> ReadSingleAsync(Guid EntityId)
        {
            return await table.FindAsync(EntityId);
        }

        public void Update(T entity)
        {
            entity.LastModifiedAt = DateTime.UtcNow;

            table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IList<T> entities)
        {
            table.UpdateRange(entities.Select(e => { e.LastModifiedAt = DateTime.UtcNow; return e; }));
        }

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

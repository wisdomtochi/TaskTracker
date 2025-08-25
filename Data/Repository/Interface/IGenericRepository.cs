namespace TaskTracker.Data.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {

        Task AddAsync(T entity);

        Task AddRangeAsync(IList<T> entities);


        Task<T> ReadSingleAsync(Guid EntityId);

        IQueryable<T> ReadAllQuery();

        Task<IEnumerable<T>> ReadAllAsync();


        void UpdateAsync(T entity);
        void UpdateRangeAsync(IList<T> entities);

        Task DeleteAsync(Guid EntityId);
        void DeleteRange(IList<T> entities);
    }
}

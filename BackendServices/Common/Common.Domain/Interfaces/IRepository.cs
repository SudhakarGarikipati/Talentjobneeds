namespace Common.Domain.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(long id);

        Task<List<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(long id);

        Task SaveChanges();
    }
}

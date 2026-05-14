namespace Common.Domain.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(long id);

        Task<List<TEntity>> GetAllAsync();

        Task<(List<TEntity>, int)> GetAllAsync(int pageNumber, int pageSize, string? sortBy);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(long id);

        Task SaveChanges();
    }
}

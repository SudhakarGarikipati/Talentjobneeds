using Common.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Common.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(DbContext context, IMemoryCache memoryCache, ILogger<Repository<TEntity>> logger)
        {
            _context = context;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            var cacheKey = $"{typeof(TEntity).Name}_All";
            _memoryCache.Remove(cacheKey);
        }

        public async Task DeleteAsync(long id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);
            if (result != null)
            {
                _context.Set<TEntity>().Remove(result);
                var cacheKey = $"{typeof(TEntity).Name}_All";
                _memoryCache.Remove(cacheKey);
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var cacheKey = $"{typeof(TEntity).Name}_All";
            _logger.LogInformation($"GetAllAsync {typeof(TEntity).Name} {DateTime.Now} started. ");
            var list = await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.SetSize(1);
                // Log cache miss for debugging purposes 
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            });
            _logger.LogInformation($"GetAllAsync {typeof(TEntity).Name} {DateTime.Now} ended. ");
            return list;
        }

        public async Task<(List<TEntity>, int)> GetAllAsync(int pageNumber, int pageSize, string? sortBy)
        {
            var _pageNumber = Math.Max(1, pageNumber);
            var _pageSize = Math.Clamp(pageSize, 1, 50);

            var query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            // 1. Apply search filter (reduces the dataset)
            //query = query.ApplySearch(filter.Search);

            // 2. Count total records AFTER filtering, BEFORE pagination
            var totalRecords = await query.CountAsync();

            // 3. Apply sorting (optional, but should be before pagination)
            query = query.ApplySorting(
                    string.IsNullOrWhiteSpace(sortBy) ? "JobType" : sortBy);

            // 4. Apply pagination (after sorting)
            query = query.ApplyPagination(_pageNumber, _pageSize);
            return (await query.ToListAsync(), totalRecords);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            var cacheKey = $"{typeof(TEntity).Name}_All";
            _memoryCache.Remove(cacheKey);
        }
    }
}

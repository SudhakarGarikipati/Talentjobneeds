using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain.Entities;
using JobsModule.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
        public EmployerRepository(TalentjobneedsDbContext context, IMemoryCache memoryCache, ILogger<EmployerRepository> logger) : base(context, memoryCache, logger) { }
    }
}

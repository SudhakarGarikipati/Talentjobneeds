using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain;
using JobsModule.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class JobApplicationRepository(TalentjobneedsDbContext context, IMemoryCache memoryCache, ILogger<JobApplicationRepository> logger ) : Repository<JobApplication>(context, memoryCache, logger), IJobApplicationRepository
    {
    }
}

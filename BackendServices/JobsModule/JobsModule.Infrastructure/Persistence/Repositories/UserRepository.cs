using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain.Entities;
using JobsModule.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class UserRepository(TalentjobneedsDbContext context, IMemoryCache memoryCache, ILogger<UserRepository> logger) : Repository<User>(context, memoryCache, logger), IUserRepository
    {
    }
}

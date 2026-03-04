using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain.Entities;
using JobsModule.Domain.Interfaces;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class UserRepository(TalentjobneedsDbContext context) : Repository<User>(context), IUserRepository
    {
    }
}

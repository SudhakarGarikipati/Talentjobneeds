using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain;
using JobsModule.Domain.Entities;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class JobApplicationRepository(TalentjobneedsDbContext context) : Repository<JobApplication>(context), IJobApplicationRepository
    {
    }
}

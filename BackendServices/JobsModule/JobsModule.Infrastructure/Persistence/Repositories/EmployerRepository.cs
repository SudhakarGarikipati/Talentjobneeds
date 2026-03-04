using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain.Entities;
using JobsModule.Domain.Interfaces;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
        public EmployerRepository(TalentjobneedsDbContext context) : base(context) { }
    }
}

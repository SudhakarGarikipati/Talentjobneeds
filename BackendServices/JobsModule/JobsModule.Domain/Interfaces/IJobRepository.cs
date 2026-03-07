using Common.Domain.Interfaces;
using JobsModule.Domain.Entities;

namespace JobsModule.Domain.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<bool> ApplyForJobAsync(long jobId, long userId);

        Task<IEnumerable<Job>> GetJobsAsync(string? title, string ? location, int page, int pageSize);

        Task<IEnumerable<Job>> GetEmployerJobsAsync(long employerId, int page, int pageSize);

        Task<Job> GetJobDetailsAsync(string strUrl);

        Task<Job> GetJobByIdAsync(long jobid);
    }
}

using JobsModule.Application.DTOs;

namespace JobsModule.Application.Service.Abstraction
{
    public interface IJobApplicationQueries
    {
        Task<IEnumerable<JobApplicationDTO>> GetJobApplications();
    }
}

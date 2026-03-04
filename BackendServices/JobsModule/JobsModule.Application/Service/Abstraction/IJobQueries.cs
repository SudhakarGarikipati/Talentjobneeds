using JobsModule.Application.DTOs;

namespace JobsModule.Application.Service.Abstraction
{
    public interface IJobQueries
    {
        Task<IEnumerable<JobDTO>> GetAllJobAsync();
    }
}

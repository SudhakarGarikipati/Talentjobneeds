using JobsModule.Application.DTOs;
using JobsModule.Domain.Entities;

namespace JobsModule.Application.Service.Abstraction
{
    public interface IJobQueries
    {
        Task<IEnumerable<JobDTO>> GetAllJobAsync();

        Task<Employer> GetEmployerAsync(long employerId);
    }
}

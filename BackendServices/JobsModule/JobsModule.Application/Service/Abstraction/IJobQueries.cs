using JobsModule.Application.DTOs;
using JobsModule.Application.DTOs.Common;
using JobsModule.Domain.Entities;

namespace JobsModule.Application.Service.Abstraction
{
    public interface IJobQueries
    {
        Task<PagedResponse<JobDTO>> GetAllJobAsync(QueryFilter queryFilter);

        Task<IEnumerable<JobDTO>> GetAllJobAsync();

        Task<Employer> GetEmployerAsync(long employerId);
    }
}

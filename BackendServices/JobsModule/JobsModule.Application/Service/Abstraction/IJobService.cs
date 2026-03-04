using Common.Domain.Enums;
using JobsModule.Application.DTOs;

namespace JobsModule.Application.Service.Abstraction
{
    public interface IJobService
    {
       Task<EnumJobApplyStatus> ApplyForJobAsync(long JobId, long UserId);

        Task<IEnumerable<JobDTO>> GetEmployerJobsAsync(long employerID, int page, int pageSize);

        IEnumerable<JobDTO> GetJobsAsync(string title, string location, int page, int pageSize);

        Task<JobDTO> GetJobByIdAsync(long jobID);

        Task<JobDTO> GetJobByURLAsync(string Url);

        Task<bool> AddJobAsync(JobDTO job);

        Task<bool> DeleteJobAsync(long jobID);

        Task<bool> UpdateJobAsync(long jobid, JobDTO job);

        Task<IEnumerable<JobDTO>> GetAllJobsAsync();
    }
}

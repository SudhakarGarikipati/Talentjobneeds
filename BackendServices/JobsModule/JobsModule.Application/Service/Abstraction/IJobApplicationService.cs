using JobsModule.Application.DTOs;

namespace JobsModule.Application.Service.Abstraction
{
    public interface IJobApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <<returns></returns>
        Task<IEnumerable<JobApplicationDTO>> GetJobApplications();

        
        JobApplicationDTO JobApplicationDTO(long applicationId);
    }
}

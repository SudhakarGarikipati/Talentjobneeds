using JobsModule.Application.DTOs;
using JobsModule.Application.Service.Abstraction;
using JobsModule.Domain;
using MapsterMapper;

namespace JobsModule.Application.Service.Implementation
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;
        private readonly IJobApplicationQueries _jobApplicationQueries;

        public JobApplicationService(IJobApplicationRepository jobApplicationRepository
            , IMapper mapper, IJobApplicationQueries jobApplicationQueries) { 
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
            _jobApplicationQueries = jobApplicationQueries;
        }

        public async Task<IEnumerable<JobApplicationDTO>> GetJobApplications()
        {
            return await _jobApplicationQueries.GetJobApplications();
        }

        public JobApplicationDTO JobApplicationDTO(long applicationId)
        {
            var jobApplication = _jobApplicationRepository.GetByIdAsync(applicationId);
            return _mapper.Map<JobApplicationDTO>(jobApplication);
        }
    }
}

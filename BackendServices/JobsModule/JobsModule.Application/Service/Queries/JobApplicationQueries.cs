using Common.Domain.Enums;
using JobsModule.Application.DTOs;
using JobsModule.Application.Service.Abstraction;
using JobsModule.Domain;
using JobsModule.Domain.Interfaces;
using MapsterMapper;

namespace JobsModule.Application.Service.Queries
{
    public class JobApplicationQueries : IJobApplicationQueries
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;

        public JobApplicationQueries(IJobApplicationRepository jobApplicationRepository, IMapper mapper
            , IJobRepository jobRepository, IUserRepository userRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<JobApplicationDTO>> GetJobApplications()
        {
            var jobApplications = await _jobApplicationRepository.GetAllAsync();
            var jobs = await _jobRepository.GetAllAsync();
            var users = await _userRepository.GetAllAsync();

            var result = (from ja in jobApplications
                          join j in jobs on ja.JobId equals j.JobId
                          join u in users on ja.UserId equals u.UserId
                          select new JobApplicationDTO
                          {
                              ApplicationId = ja.ApplicationId,
                              JobId = ja.JobId,
                              UserId = ja.UserId,
                              JobTitle = j.JobTitle,
                              UserName = u.FirstName,
                              ApplicationDate = ja.ApplicationDate,
                              Status = (EnumJobApplyStatus)ja.Status
                          }).ToList();
            return result;

        }
    }
}

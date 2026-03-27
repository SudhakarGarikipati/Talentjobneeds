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
        private readonly IEmployerRepository _employerRepository;

        public JobApplicationQueries(IJobApplicationRepository jobApplicationRepository, IMapper mapper
            , IJobRepository jobRepository, IUserRepository userRepository, IEmployerRepository employerRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _employerRepository = employerRepository;
        }

        public async Task<IEnumerable<JobApplicationDTO>> GetJobApplications()
        {
            var jobApplications = await _jobApplicationRepository.GetAllAsync();
            var jobs = await _jobRepository.GetAllAsync();
            var users = await _userRepository.GetAllAsync();
            var employers = await _employerRepository.GetAllAsync();    

            var result = (from ja in jobApplications
                          join j in jobs on ja.JobId equals j.JobId
                          join u in users on ja.UserId equals u.UserId
                          join e in employers on j.EmployerId equals e.EmployerId
                          select new JobApplicationDTO
                          {
                              ApplicationId = ja.ApplicationId,
                              JobId = ja.JobId,
                              UserId = ja.UserId,
                              JobTitle = j.JobTitle,
                              Skills = j.Skills,
                              UserName = u.FirstName,
                              CompanyName = e.CompanyName,
                              ApplicationDate = ja.ApplicationDate,
                              EmployerId = j.EmployerId,
                              Status = (EnumJobApplyStatus)ja.Status
                          }).ToList();
            return result;

        }
    }
}

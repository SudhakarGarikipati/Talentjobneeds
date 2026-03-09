using Common.Domain.Enums;
using JobsModule.Application.DTOs;
using JobsModule.Application.Service.Abstraction;
using JobsModule.Domain.Entities;
using JobsModule.Domain.Interfaces;
using MapsterMapper;
using Microsoft.Extensions.Configuration;

namespace JobsModule.Application.Service.Implementation
{
    public class JobService : IJobService
    {
       private readonly IJobRepository _jobRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IJobQueries _jobQueries;

        public JobService(IJobRepository jobRepository, IConfiguration configuration, IMapper mapper, IJobQueries jobQueries ) {
            _jobRepository = jobRepository;
            _configuration = configuration;
            _mapper = mapper;
            _jobQueries = jobQueries;
        }

        public async Task<bool> AddJobAsync(JobDTO jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            await _jobRepository.AddAsync(job);
            await _jobRepository.SaveChanges();
            return true;
        }

        public async Task<EnumJobApplyStatus> ApplyForJobAsync(ApplyJobDto applyJobDto)
        {
            
            var status = await _jobRepository.ApplyForJobAsync(applyJobDto.JobId, applyJobDto.UserId);
            if (status)
            {
                return EnumJobApplyStatus.Applied;
            }
            return EnumJobApplyStatus.AlreadyApplied;
        }

        public async Task<bool> DeleteJobAsync(long jobID)
        {
            await _jobRepository.DeleteAsync(jobID);
            await _jobRepository.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<JobDTO>> GetEmployerJobsAsync(long employerID, int page, int pageSize)
        {
            var jobs = await _jobRepository.GetEmployerJobsAsync(employerID,  page, pageSize);
            var imageBaseAddress = _configuration["ImageBaseAddress"];

            // Map jobs to JobDTO and append ImageBaseAddress to CompanyLogo
            var jobDTOs = _mapper.Map<IList<JobDTO>>(jobs).Select(job =>
            {
                job.CompanyLogo = !string.IsNullOrEmpty(job.CompanyLogo)
                    ? $"{imageBaseAddress}{job.CompanyLogo}"
                    : null;
                return job;
            });
            return jobDTOs;
            throw new NotImplementedException();
        }

        public async Task<JobDTO> GetJobByIdAsync(long jobId)
        {
            var foundJob = await _jobRepository.GetJobByIdAsync(jobId);
            if(foundJob == null)
            {
                throw new Exception("Job not found.");
            }
            var employer = await _jobQueries.GetEmployerAsync(foundJob.EmployerId);
            foundJob.Employer = employer;
            var imageBaseAddress = _configuration["ImageBaseAddress"];
            // Map jobs to JobDTO and append ImageBaseAddress to CompanyLogo
            var jobDTO = _mapper.Map<JobDTO>(foundJob);
            jobDTO.CompanyLogo = !string.IsNullOrEmpty(jobDTO.CompanyLogo)
                    ? $"{imageBaseAddress}{jobDTO.CompanyLogo}"
                    : null;
            return jobDTO;
        }

        public async Task<JobDTO> GetJobByURLAsync(string Url)
        {
            var foundJob = await _jobRepository.GetJobDetailsAsync(Url);
            if (foundJob == null)
                throw new Exception("Job not found");
            var employer = await _jobQueries.GetEmployerAsync(foundJob.EmployerId);
            foundJob.Employer = employer;
            var imageBaseAddress = _configuration["ImageBaseAddress"];
            // Map jobs to JobDTO and append ImageBaseAddress to CompanyLogo
            var jobDTO = _mapper.Map<JobDTO>(foundJob);
            jobDTO.CompanyLogo = !string.IsNullOrEmpty(jobDTO.CompanyLogo)
                    ? $"{imageBaseAddress}{jobDTO.CompanyLogo}"
                    : null;
            return jobDTO;
        }

        public async Task<IEnumerable<JobDTO>> GetJobsAsync(string? title, string?  location, int page, int pageSize)
        {
            var jobs = await _jobRepository.GetJobsAsync(title, location, page, pageSize);
            var imageBaseAddress = _configuration["ImageBaseAddress"];

            // Map jobs to JobDTO and append ImageBaseAddress to CompanyLogo
            var jobDTOs = _mapper.Map<IList<JobDTO>>(jobs).Select(job =>
            {
                job.CompanyLogo = !string.IsNullOrEmpty(job.CompanyLogo)
                    ? $"{imageBaseAddress}{job.CompanyLogo}"
                    : null;
                return job;
            });
            return jobDTOs;
        }

        public async Task<bool> UpdateJobAsync(long jobId, JobDTO jobDto)
        {
            var isJobExist = await _jobRepository.GetJobByIdAsync(jobId);
            if (isJobExist == null)
            {
                throw new Exception($"Job not found with the provided details {jobId}");
            }
            var job = _mapper.Map<Job>(jobDto);
            await _jobRepository.SaveChanges();//_jobRepository.UpdateAsync(job);
            return true;
        }

        public async Task<IEnumerable<JobDTO>> GetAllJobsAsync()
        {
            var jobDTOs = await _jobQueries.GetAllJobAsync();
            return jobDTOs;
        }
    }
}

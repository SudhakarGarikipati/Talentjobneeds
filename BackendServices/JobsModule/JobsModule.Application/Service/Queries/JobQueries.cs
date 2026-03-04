using JobsModule.Application.DTOs;
using JobsModule.Application.Service.Abstraction;
using JobsModule.Domain.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;

namespace JobsModule.Application.Service.Queries
{
    public class JobQueries : IJobQueries
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly IEmployerRepository _employerRepository;
        private readonly IConfiguration _configuration;

        public JobQueries(IJobRepository jobRepository, IMapper mapper, IEmployerRepository employerRepository, IConfiguration configuration)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _employerRepository = employerRepository;
            _configuration = configuration;
        }

        public async Task<IEnumerable<JobDTO>> GetAllJobAsync()
        {
            var imageBaseAddress = _configuration["ImageBaseAddress"];
            var jobs = await _jobRepository.GetAllAsync();
            var employers = await _employerRepository.GetAllAsync();

            var result = (from job in jobs
                          join employer in employers on job.EmployerId equals employer.EmployerId
                          select (job, employer));

            // Map jobs to JobDTO and append ImageBaseAddress to CompanyLogo
            var jobDTOs =  _mapper.Map<List<JobDTO>>(result).Select(job =>
            {
                job.CompanyLogo = !string.IsNullOrEmpty(job.CompanyLogo)
                    ? $"{imageBaseAddress}{job.CompanyLogo}"
                    : null;
                return job;
            }); ;
            return jobDTOs;
        }
    }
}

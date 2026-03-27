using JobsModule.Application.DTOs;
using JobsModule.Application.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace JobsModule.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]/[action]")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IJobApplicationService _jobApplicationService;
        public JobController(IJobService jobService, IJobApplicationService jobApplicationService)
        {
            _jobService = jobService;
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            if (jobs == null)
            {
                return NotFound();
            }
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid job ID.");
            }
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyJob([FromBody] ApplyJobDto applyJobDto)
        {
            var applyStatus = await _jobService.ApplyForJobAsync(applyJobDto);
            return Ok(applyStatus);
        }

        [HttpPost]
        public async Task<IActionResult> GetJobs([FromBody] SearchJobDto searchJobDto)
        {
            if (string.IsNullOrEmpty(searchJobDto.Title) && string.IsNullOrEmpty(searchJobDto.Location) && string.IsNullOrEmpty(searchJobDto.Title))
            {
                return BadRequest("At least one search criteria must be provided.");
            }
            var jobs = await _jobService.GetJobsAsync(searchJobDto.Title, searchJobDto.Location, searchJobDto.Page, searchJobDto.PageSize);
            if (jobs == null || !jobs.Any())
            {
                return NotFound();
            }
            return Ok(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployerJobs([FromBody] EmployerSearchDTO searchJobDto)
        {
            if (searchJobDto.EmployerID == 0)
            {
                return BadRequest("Please provided valid employer id.");
            }
            var jobs = await _jobService.GetEmployerJobsAsync(searchJobDto.EmployerID, searchJobDto.Page, searchJobDto.PageSize);
            if (jobs == null || !jobs.Any())
            {
                return NotFound();
            }
            return Ok(jobs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid job ID.");
            }
            var result = await _jobService.DeleteJobAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob([FromBody] JobDTO jobDto)
        {
            if (jobDto == null || jobDto.JobId <= 0)
            {
                return BadRequest("Invalid job data.");
            }
            var result = await _jobService.UpdateJobAsync(jobDto.JobId, jobDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Update completed successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] JobDTO jobDto)
        {
            if (jobDto == null || string.IsNullOrEmpty(jobDto.JobTitle) || jobDto.EmployerId <= 0)
            {
                return BadRequest("Invalid job data. Please provide all required fields.");
            }
            var result = await _jobService.AddJobAsync(jobDto);
            if (!result)
            {
                return StatusCode(500, "An error occurred while adding the job. Please try again later.");
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<JobApplicationDTO>> GetApplications(long id)
        {
            var jobApplications = await _jobApplicationService.GetUserApplications(id);
            return jobApplications;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<JobApplicationDTO>> GetAllApplications(long id)
        {
            var jobApplications = await _jobApplicationService.GetEmployerApplications(id);
            return jobApplications;
        }
    }
}

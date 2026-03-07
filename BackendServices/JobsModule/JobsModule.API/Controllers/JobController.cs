using JobsModule.Application.DTOs;
using JobsModule.Application.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace JobsModule.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
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
    }
}

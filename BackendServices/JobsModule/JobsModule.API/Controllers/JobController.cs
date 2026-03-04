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
    }
}

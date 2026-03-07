using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobNeedsWebApp.Areas.Jobseeker.Controllers
{
    public class JobsController : BaseController
    {
        private readonly JobsHttpClient _jobsHttpClient;

        public JobsController(JobsHttpClient jobsHttpClient)
        {
            _jobsHttpClient = jobsHttpClient;
        }

        [Authorize]
        [HttpGet("Jobseeker/Jobs/Apply/{jobId}")]
        public async Task<IActionResult> Apply(long jobId)
        {
            var userData = User.FindFirst(ClaimTypes.UserData)?.Value;
            var applyJobDto = new ApplyJobViewModel
            {
                JobId = jobId,
                UserId = 2
            };
            var result = await _jobsHttpClient.ApplyForJobAsync(applyJobDto);
            return View(model:result);
        }

        [Authorize]
        public IActionResult Browse()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Browse(SearchViewModel searchViewModel)
        {
            var searchResults = await _jobsHttpClient.SearchJobsAsync(searchViewModel);
            if(searchResults == null || !searchResults.Any())
            {
                ViewBag.Message = "No jobs found matching your criteria.";
                return View();
            }
            return View("SearchResults", searchResults);
        }
    }
}

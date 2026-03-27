using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

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
            if(userData == null)
            {
                return View(model: "Unable to complete application");
            }
            var user = JsonSerializer.Deserialize<UserViewModel>(userData);
            if (user == null)
            {
                return View(model: "Unable to complete application");
            }
            var applyJobDto = new ApplyJobViewModel
            {
                JobId = jobId,
                UserId = user.UserId
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

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var selectedJob = await _jobsHttpClient.GetJobByIdAsync(id);
            return View(selectedJob);
        }
    }
}

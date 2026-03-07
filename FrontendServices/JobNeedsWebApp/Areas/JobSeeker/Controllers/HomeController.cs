using JobNeedsWebApp.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Jobseeker.Controllers
{
    public class HomeController : BaseController
    {
        private readonly JobsHttpClient _jobsHttpClient;

        public HomeController(JobsHttpClient jobsHttpClient)
        {
            _jobsHttpClient = jobsHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            //var allOpenJobs = await _jobsHttpClient.GetAllJobsAsync();
            //return View(allOpenJobs);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var selectedJob = await _jobsHttpClient.GetJobByIdAsync(id);
            return View(selectedJob);
        }
    }
}

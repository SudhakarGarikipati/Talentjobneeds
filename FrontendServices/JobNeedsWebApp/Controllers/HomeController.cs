using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobNeedsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JobsHttpClient _jobsHttpClient;

        public HomeController(ILogger<HomeController> logger, JobsHttpClient jobsHttpClient)
        {
            _logger = logger;
            _jobsHttpClient = jobsHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var allOpenJobs = await _jobsHttpClient.GetAllJobsAsync();
            return View(allOpenJobs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var selectedJob = await _jobsHttpClient.GetJobByIdAsync(id);
            return View(selectedJob);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

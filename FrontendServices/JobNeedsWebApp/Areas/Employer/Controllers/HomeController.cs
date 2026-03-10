using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace JobNeedsWebApp.Areas.Employer.Controllers
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
            var empId = 1;// = GetCurrentUserId();
            var applications = await _jobsHttpClient.GetAllApplicationsAsync(empId);
            return View(applications);
        }
       
    }
}

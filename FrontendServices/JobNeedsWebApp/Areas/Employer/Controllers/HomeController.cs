using JobNeedsWebApp.HttpClients;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var token = GetAccessToken();

            var empId = 1;// = GetCurrentUserId();
            var applications = await _jobsHttpClient.GetAllApplicationsAsync(empId, token);
            return View(applications);
        }

        private string GetAccessToken()
        {
            var token = User.FindFirst("access_token")?.Value;
            return token != null ? token : string.Empty;
        }

    }
}

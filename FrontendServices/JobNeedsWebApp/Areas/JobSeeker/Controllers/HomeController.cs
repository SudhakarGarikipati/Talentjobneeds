using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

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
            var userId = GetCurrentUserId();
            var applications = await _jobsHttpClient.GetJobApplicationsAsync(userId);
            return View(applications);
        }

        private long  GetCurrentUserId()
        {
            var userData = User.FindFirst(ClaimTypes.UserData)?.Value;
            var user = JsonSerializer.Deserialize<UserViewModel>(userData);
            return user != null ? user.UserId : 0;

        }
    }
}

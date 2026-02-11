using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.JobSeeker.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

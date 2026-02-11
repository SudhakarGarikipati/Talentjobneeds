using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.JobSeeker.Controllers
{
    [Area("JobSeeker")]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

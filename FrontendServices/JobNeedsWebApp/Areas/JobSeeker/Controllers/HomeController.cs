using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Jobseeker.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

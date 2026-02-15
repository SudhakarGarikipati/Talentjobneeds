using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Employer.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

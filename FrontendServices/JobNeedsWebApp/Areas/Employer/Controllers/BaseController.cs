using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

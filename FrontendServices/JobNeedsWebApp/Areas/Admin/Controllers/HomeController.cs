using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

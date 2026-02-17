using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthHttpClient _authHttpClient;

        public AccountController(AuthHttpClient authHttpClient)
        {
            _authHttpClient = authHttpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            try
            {
                var user = await _authHttpClient.LoginAsync(loginViewModel);
                //// Store user information in session or cookie as needed
                //HttpContext.Session.SetString("UserId", user.UserId.ToString());
                //HttpContext.Session.SetString("FirstName", user.FirstName);
                //HttpContext.Session.SetString("LastName", user.LastName);
                //HttpContext.Session.SetString("Email", user.Email);
                //HttpContext.Session.SetString("Token", user.Token);
                if (user != null && user.Roles.Count > 0)
                {
                    HttpContext.Session.SetString("UserRole", user.Roles[0]);
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("Employer"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Employer" });
                    }
                    else if (user.Roles.Contains("JobSeeker"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "JobSeeker" });
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(loginViewModel);
            }
        }
    }
}

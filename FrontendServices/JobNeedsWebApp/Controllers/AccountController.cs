using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace JobNeedsWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthHttpClient _authHttpClient;

        public AccountController(AuthHttpClient authHttpClient)
        {
            _authHttpClient = authHttpClient;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

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
                // Store user information in session or cookie as needed
                if (user != null && user.Roles.Count > 0)
                {
                    await GenerateTicket(user);
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("Employer"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Employer" });
                    }
                    else if (user.Roles.Contains("Jobseeker"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Jobseeker" });
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


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // Creates an authentication cookie for the logged‑in user.
        // This cookie contains claims(user data, email, roles) and is stored in the browser.
        // ASP.NET Core will then treat the user as authenticated on every subsequent request until the cookie expires.

        private async Task GenerateTicket(UserViewModel user)
        {
            string userData = JsonSerializer.Serialize(user);
            //Create a list of claims to store user information in the authentication cookie
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.UserData, userData),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, string.Join(',', user.Roles))
                };
            // Create a ClaimsIdentity with the specified claims and authentication scheme (cookie)
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            // Sign in the user by creating an authentication cookie with the ClaimsPrincipal containing the user's claims
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1),
                });
        }
    }
}

using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace JobNeedsWebApp.HttpClients
{
    public class AuthHttpClient
    {
        private readonly HttpClient _httpClient;

        public AuthHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/jobneeds/login", loginViewModel);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<UserViewModel>();
                return data;
            }
            throw new Exception("Login failed. Please check your credentials and try again.");
        }

        public async Task<UserViewModel> RefreshToken(string refreshToken)
        {
            var response = await _httpClient.PostAsJsonAsync("/jobneeds/refresh", refreshToken);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<UserViewModel>();
                return data;
            }
            throw new Exception("Refresh failed. Please check your credentials and try again.");
        }

        public async Task<bool> RegisterAsync(SignUpViewModel signUpViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/jobneeds/RegisterUser", signUpViewModel);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data == "Registration successful";
            }
            throw new Exception("Registration failed. Please check your details and try again.");
        }

        public async Task UpdateAuthCookiesAsync(HttpContext context, UserViewModel tokens)
        {
            // Update refresh token cookie
            context.Response.Cookies.Append("refreshToken", tokens.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            // Update access token in claims
            var identity = context.User.Identity as ClaimsIdentity;
            identity.RemoveClaim(identity.FindFirst("access_token"));
            identity.AddClaim(new Claim("access_token", tokens.Token));

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}

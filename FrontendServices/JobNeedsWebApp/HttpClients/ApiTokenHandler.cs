
using System.Net.Http.Headers;

namespace JobNeedsWebApp.HttpClients
{
    public class ApiTokenHandler : DelegatingHandler
    {
        private readonly AuthHttpClient _authHttpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApiTokenHandler(AuthHttpClient authHttpClient, IHttpContextAccessor contextAccessor)
        {
            _authHttpClient = authHttpClient;
            _contextAccessor = contextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _contextAccessor.HttpContext;
            var accessToken = httpContext.User.FindFirst("access_token")?.Value;
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var refreshToken = httpContext.Request.Cookies["RefreshToken"];
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    try
                    {
                        var userViewModel = await _authHttpClient.RefreshToken(refreshToken);
                        if (userViewModel != null)
                        {
                        }

                        await _authHttpClient.UpdateAuthCookiesAsync(httpContext, userViewModel);

                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userViewModel.Token);

                        response = await base.SendAsync(request, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        // Handle token refresh failure (e.g., log the error, clear session, redirect to login, etc.)
                        Console.WriteLine($"Token refresh failed: {ex.Message}");
                    }
                }
            }
            return response;
        }
    }
}

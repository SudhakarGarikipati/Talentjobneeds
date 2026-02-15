using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Claims;
using System.Text.Json;

namespace JobNeedsWebApp.Helpers
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        public UserViewModel CurrentUser
        {
            get
            {
                if (User.Claims.Any())
                {
                    var userClaims = Context.User.Claims;
                    var userData = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;
                    if(userData != null)
                    {
                        return JsonSerializer.Deserialize<UserViewModel>(userData);
                    }
                }
                return null;
            }
        }
    }
}

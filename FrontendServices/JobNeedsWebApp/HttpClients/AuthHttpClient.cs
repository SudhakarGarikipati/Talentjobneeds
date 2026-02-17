using JobNeedsWebApp.Models;

namespace JobNeedsWebApp.HttpClients
{
    public class AuthHttpClient
    {
        private readonly HttpClient httpClient;

        public AuthHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var response = await httpClient.PostAsJsonAsync("/jobneeds/login", loginViewModel);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<UserViewModel>();
                return data;
            }
            throw new Exception("Login failed. Please check your credentials and try again.");
        }

        public async Task<bool> RegisterAsync(SignUpViewModel signUpViewModel)
        {
            var response = await httpClient.PostAsJsonAsync("/jobneeds/RegisterUser", signUpViewModel);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data == "Registration successful";
            }
            throw new Exception("Registration failed. Please check your details and try again.");
        }
    }
}

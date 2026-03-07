using Common.Domain.Enums;
using JobNeedsWebApp.Models;

namespace JobNeedsWebApp.HttpClients
{
    public class JobsHttpClient
    {
        private readonly HttpClient _httpClient;

        public JobsHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<JobViewModel>> GetAllJobsAsync()
        {
            var response = await _httpClient.GetAsync("/job/GetAllJobs");
            response.EnsureSuccessStatusCode();
            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<JobViewModel>>();
                return data;
            }
            throw new Exception("Failed to fetch jobs. Please try again later.");

        }

        public async Task<JobViewModel> GetJobByIdAsync(long id)
        {
            var response = await _httpClient.GetAsync($"/job/GetJobById/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<JobViewModel>();
                return data;
            }
            throw new Exception("Failed to fetch job details. Please try again later.");
        }

        public async Task<string> ApplyForJobAsync(ApplyJobViewModel applyJobViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"/job/ApplyJob", applyJobViewModel);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<EnumJobApplyStatus>();
                return data.ToString();
            }
            throw new Exception("Failed to fetch job details. Please try again later.");
        }

        public async Task<List<JobViewModel>> SearchJobsAsync(SearchViewModel searchViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"/job/GetJobs", searchViewModel);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<JobViewModel>>();
                return data;
            }
            throw new Exception("Failed to fetch job details. Please try again later.");
        }
    }
}

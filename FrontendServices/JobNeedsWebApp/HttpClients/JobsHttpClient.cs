using Common.Domain.Enums;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            if (response.IsSuccessStatusCode)
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

        public async Task<List<JobViewModel>> EmployerSearchJobsAsync(EmploySearchViewModel searchViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"/job/GetEmployerJobs", searchViewModel);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<JobViewModel>>();
                return data;
            }
            throw new Exception("Failed to fetch job details. Please try again later.");
        }

        public async Task<string> UpdateJobAsync(JobViewModel jobViewModel)
        {
            var json = JsonSerializer.Serialize(jobViewModel);
            var response = await _httpClient.PutAsJsonAsync($"/job/UpdateJob", jobViewModel);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            throw new Exception("Failed to update job details. Please try again later.");
        }

        public async Task<bool> DeleteJobAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"/job/DeleteJob/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception("Failed to delete job. Please try again later.");
        }

        public async Task<bool> AddJobAsync(JobViewModel jobViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"/job/AddJob", jobViewModel);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception("Failed to add job. Please try again later.");
        }

        public async Task<List<JobApplicationViewModel>> GetJobApplicationsAsync(long id)
        {
            var response = await _httpClient.GetAsync($"/job/GetApplications/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<JobApplicationViewModel>>();
                return data;
            }
            throw new Exception("Failed to fetch job applications. Please try again later.");
        }

        public async Task<List<JobApplicationViewModel>> GetAllApplicationsAsync(long id)
        {
            var response = await _httpClient.GetAsync($"/job/GetAllApplications/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<JobApplicationViewModel>>();
                return data;
            }
            throw new Exception("Failed to fetch job applications. Please try again later.");
        }
    }
}

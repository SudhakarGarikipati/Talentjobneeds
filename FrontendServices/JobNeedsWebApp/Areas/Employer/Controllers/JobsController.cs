using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobNeedsWebApp.Areas.Employer.Controllers
{
    public class JobsController : BaseController
    {
        private readonly JobsHttpClient _httpClient;

        public JobsController(JobsHttpClient jobsHttpClient)
        {
            _httpClient = jobsHttpClient;
        }

        public IActionResult Browse()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Browse(EmploySearchViewModel employSearchViewModel)
        {
            var searchResults = await _httpClient.EmployerSearchJobsAsync(employSearchViewModel);
            if (searchResults == null || searchResults.Count == 0)
            {
                ViewBag.Message = "No jobs found matching your search criteria.";
                return View();
            }
            // You can add logic here to handle the search parameters and return the appropriate view or data
            return View("SearchResults", searchResults);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jobDetails = await _httpClient.GetJobByIdAsync(id);
            if (jobDetails == null)
            {
                return View("Browse");
            }
            return View(jobDetails);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(JobViewModel jobViewModel)
        {
            var jobDetails = await _httpClient.UpdateJobAsync(jobViewModel);
            if (jobDetails == "Update completed successfully.")
            {
                return  View("Browse");
            }
            return View(jobDetails);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var jobDetails = await _httpClient.GetJobByIdAsync(id);
            if (jobDetails == null)
            {
                return View();
            }
            return View(jobDetails);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var jobDetails = await _httpClient.DeleteJobAsync(id);
            if (jobDetails == null)
            {
                return View();
            }
            return View(jobDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(JobViewModel jobViewModel)
        {
            var created = await _httpClient.AddJobAsync(jobViewModel);
            if (!created)
            {
                return View(jobViewModel);
            }
            return View("Browse");
        }
    }
}

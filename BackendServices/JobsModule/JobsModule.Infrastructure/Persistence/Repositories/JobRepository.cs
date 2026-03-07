using Common.Domain.Enums;
using Common.Infrastructure.Persistence.Repositories;
using JobsModule.Domain.Entities;
using JobsModule.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobsModule.Infrastructure.Persistence.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {

        private readonly TalentjobneedsDbContext _context;

        public JobRepository(TalentjobneedsDbContext db) : base(db)
        {
            _context = db;
        }

        public async Task<bool> ApplyForJobAsync(long jobId, long userId)
        {
            JobApplication jobApplication = new()
            {
                JobId = jobId,
                UserId = userId,
                ApplicationDate = DateTime.Now,
                Status = (int)EnumApplicationStatus.Open
            };
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Job>> GetEmployerJobsAsync(long employerId, int page, int pageSize)
        {
            var jobs = await _context.Jobs
                .Where(j => j.EmployerId == employerId)
                .OrderBy(j => j.JobId )
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return jobs;
        }

        public async Task<Job> GetJobByIdAsync(long jobId)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == jobId);
            return job;
        }

        public async Task<Job> GetJobDetailsAsync(string strUrl)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Url == strUrl);
            return job;
        }

        public async Task<IEnumerable<Job>> GetJobsAsync(string? title, string? location, int page, int pageSize)
        {
            var jobs = await _context.Jobs
                .Include(job => job.Employer).ToListAsync();

            // Applying filter based on the available parameters.
            if (title != null)
            {
                jobs = jobs.Where(job => job.JobTitle.Contains(title)).ToList();
            }

            if (location != null)
            {
                jobs = jobs.Where(job => job.Location.Contains(location)).ToList();
            }

            //Apply pagination
            jobs = jobs.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return jobs;
        }
    }
}

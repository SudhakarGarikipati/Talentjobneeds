namespace JobsModule.Application.DTOs
{
    public class JobDTO
    {
        public long JobId { get; set; }

        public long EmployerId { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public string Location { get; set; }

        public string JobType { get; set; }

        public int? MinExperience { get; set; }

        public int? MaxExperience { get; set; }

        public int? MinSalary { get; set; }

        public int? MaxSalary { get; set; }

        public string Currency { get; set; }

        public string Skills { get; set; }

        public DateTime? PostedDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string Status { get; set; }

        public bool IsActive { get; set; }

        public string Url { get; set; }

        public string CompanyName { get; set; }
        public string? CompanyLogo { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace JobNeedsWebApp.Models
{
    public class JobApplicationViewModel
    {
        public long ApplicationId { get; set; }
        public long JobId { get; set; }

        public string JobTitle { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public DateTime? ApplicationDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Common.Domain.Enums.EnumJobApplyStatus Status { get; set; }
        public string Skills { get;  set; }
        public string CompanyName { get;  set; }
    }
}

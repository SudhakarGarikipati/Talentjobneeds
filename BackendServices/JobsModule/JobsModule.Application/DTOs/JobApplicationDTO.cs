using Common.Domain.Enums;
using System.Text.Json.Serialization;

namespace JobsModule.Application.DTOs
{
    public class JobApplicationDTO
    {
        public long ApplicationId { get; set; }
        public long JobId { get; set; }

        public string JobTitle { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public DateTime? ApplicationDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumJobApplyStatus Status { get; set; }
        public string Skills { get; internal set; }
        public string CompanyName { get; internal set; }
        public long EmployerId { get;  set; }
    }
}

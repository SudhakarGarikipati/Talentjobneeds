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
        public Common.Domain.Enums.EnumJobApplyStatus Status { get; set; }
    }
}

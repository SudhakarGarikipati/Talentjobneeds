using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsModule.Application.DTOs
{
    public class ApplyJobDto
    {
        public long JobId { get; set; }
        public long UserId { get; set; }
    }
}

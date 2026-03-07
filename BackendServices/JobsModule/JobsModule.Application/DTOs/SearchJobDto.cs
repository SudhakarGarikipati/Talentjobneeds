using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsModule.Application.DTOs
{
    public class SearchJobDto
    {
        public string? Title { get; set; }
        public string? Location { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

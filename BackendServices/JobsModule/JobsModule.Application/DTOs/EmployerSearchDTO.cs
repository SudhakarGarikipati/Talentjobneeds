using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsModule.Application.DTOs
{
    public class EmployerSearchDTO
    {
        public long EmployerID { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

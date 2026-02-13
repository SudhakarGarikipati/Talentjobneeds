using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDto
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }

        public string Token { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsActive { get; set; }

    }
}

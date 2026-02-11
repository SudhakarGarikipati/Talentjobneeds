using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthServiceRepo
    {
        Task<bool> Register(User user, string role);

        User GetUserByEmail(string email);
    }
}

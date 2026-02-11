using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class AuthServiceRepo : IAuthServiceRepo
    {
        private readonly AuthServiceDbContext _authServiceDbContext;

        public AuthServiceRepo(AuthServiceDbContext authServiceDbContext)
        {
            _authServiceDbContext = authServiceDbContext;
        }

        public User GetUserByEmail(string email)
        {
            var user = _authServiceDbContext.Users.FirstOrDefault(u => u.Email == email);
            return user ?? throw new Exception("User not found");
        }

        public Task<bool> Register(User user, string roleName)
        {
            var role = _authServiceDbContext.Roles.FirstOrDefault(r => r.Name == roleName) ?? throw new Exception("Role not found");
            user.Roles.Add(role);
            _authServiceDbContext.Users.Add(user);
            _authServiceDbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}

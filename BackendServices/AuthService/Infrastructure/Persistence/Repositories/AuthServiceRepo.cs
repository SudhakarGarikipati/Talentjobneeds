using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AuthServiceRepo : IAuthServiceRepo
    {
        private readonly TalentjobneedsDbContext _authServiceDbContext;

        public AuthServiceRepo(TalentjobneedsDbContext authServiceDbContext)
        {
            _authServiceDbContext = authServiceDbContext;
        }

        public User GetUserByEmail(string email)
        {
            var user = _authServiceDbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByRefreshToken(string refreshToken)
        {
            var user = await _authServiceDbContext.Users
                .Include(u => u.RefreshTokens)
                .SingleOrDefaultAsync(u => u.RefreshTokens.Any(t=>t.Token == refreshToken));
            return user;
        }

        public async Task SaveRefreshToken(RefreshToken refreshToken, User user)
        {
            refreshToken.UserId = user.UserId;
            _authServiceDbContext.RefreshTokens.Add(refreshToken);
            await _authServiceDbContext.SaveChangesAsync();
        }

        public Task<bool> Register(User user, string roleName)
        {
            var role = _authServiceDbContext.Roles.FirstOrDefault(r => r.RoleName == roleName) ?? throw new Exception("Role not found");
            user.Roles.Add(role);
            _authServiceDbContext.Users.Add(user);
            _authServiceDbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}

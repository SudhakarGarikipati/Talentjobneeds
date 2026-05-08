using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAuthServiceRepo
    {
        Task<bool> Register(User user, string role);

        User GetUserByEmail(string email);

        Task SaveRefreshToken(RefreshToken refreshToken, User user);

        Task<User> GetUserByRefreshToken(string refreshToken);
    }
}

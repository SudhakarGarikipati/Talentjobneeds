using Application.DTOs;

namespace Application.Service.Abstraction
{
    public interface IAuthAppService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<bool> RegisterUser(SignupDto signupDto, string role);
        Task<UserDto> GetUserByMailId(string mailId);
    }
}

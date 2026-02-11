using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public interface IAuthAppService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<bool> RegisterUser(SignupDto signupDto, string role);
        Task<UserDto> GetUserByMailId(string mailId);
    }
}

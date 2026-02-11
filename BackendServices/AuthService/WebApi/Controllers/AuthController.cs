using Application.DTOs;
using Application.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
           var user = await _authAppService.Login(loginDto);
           if (user == null)
           {
               return Unauthorized();
           }
           return Ok(user);
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody]SignupDto signupDto)
        {
            var user = _authAppService.GetUserByMailId(signupDto.Email).Result;
            if (user != null)
            {
                return BadRequest("User already exists");
            }
            var result = _authAppService.RegisterUser(signupDto, signupDto.Role).Result;
            if (!result)
            {
                return BadRequest("Registration failed");
            }
            return Ok("Registration successful");
        }
    }
}

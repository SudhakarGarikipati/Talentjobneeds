using Application.DTOs;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Application.Service.Implementation
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthServiceRepo _authServiceRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public AuthAppService(IAuthServiceRepo authServiceRepo, IMapper mapper, IConfiguration configuration)
        {
            _authServiceRepo = authServiceRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Task<bool> RegisterUser(SignupDto signupDto, string role)
        {
            var user = _mapper.Map<User>(signupDto);
            user.Password = HashPassword(signupDto.Password);
            return _authServiceRepo.Register(user, role);
        }

        public Task<UserDto> GetUserByMailId(string mailId)
        {
            var user = _authServiceRepo.GetUserByEmail(mailId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return Task.FromResult(_mapper.Map<UserDto>(user));
        }

        private string HashPassword(string password) => BC.HashPassword(password);

        public Task<UserDto> Login(LoginDto loginDto)
        {
            var user = _authServiceRepo.GetUserByEmail(loginDto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!IsPasswordMatched(loginDto.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }
            var userDto = _mapper.Map<UserDto>(user);
            string token = GenerateJwtToken(user);
            userDto.Token = token;
            return Task.FromResult(userDto);
        }

        private bool IsPasswordMatched(string password, string storedHash)
        {
            // Implement password verification logic here (e.g., using BCrypt)
            var isMatch = BC.Verify(password, storedHash);
            return isMatch;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiry = Convert.ToInt32(_configuration["Jwt:Expiry"]);
            // Implement token generation logic here (e.g., using JWT)
            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "JobPortal",
                audience: "JobPortal.Api",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiry),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

using Application.DTOs;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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
            return Task.FromResult(_mapper.Map<UserDto>(user));
        }

        private string HashPassword(string password) => BC.HashPassword(password);

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = _authServiceRepo.GetUserByEmail(loginDto.Email) ?? throw new Exception("User not found");
            if (!IsPasswordMatched(loginDto.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }
            var userDto = _mapper.Map<UserDto>(user);
            string token = GenerateJwtToken(user);
            RefreshToken refreshToken = GetRefreshToken("127.0.0.0");
            await _authServiceRepo.SaveRefreshToken(refreshToken, user);
            userDto.Token = token;
            userDto.RefreshToken = refreshToken.Token;
            return userDto;
        }

        public async Task<UserDto> RefreshToken(string refreshToken)
        {
            var user = await _authServiceRepo.GetUserByRefreshToken(refreshToken);

            var rToken = user.RefreshTokens.Single(x => x.Token == refreshToken);
            if (rToken.IsRevoked || rToken.Expires < DateTime.UtcNow)
                throw new UnauthorizedAccessException();

            // generate new tokens
            var newAccessToken = GenerateJwtToken(user);
            var newRefreshToken = GetRefreshToken("127.0.0.0");

            rToken.IsRevoked = true;

            await _authServiceRepo.SaveRefreshToken(newRefreshToken, user);
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = newAccessToken;
            userDto.RefreshToken = newRefreshToken.Token;

            return userDto;
        }

        private RefreshToken GetRefreshToken(string IpAddress)
        {
            return new RefreshToken
            {
                //Id = RandomNumberGenerator.GetInt32(200),
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = IpAddress
            };
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
            // Include necessary claims such as user ID, email, and role
            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, user.FirstName+user.LastName), // Subject claim (can be user ID or username)
                new Claim(JwtRegisteredClaimNames.Email,user.Email), // Email claim
                new Claim(ClaimTypes.Role, user.Roles.FirstOrDefault().RoleName), // Add roles as a claim
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())// Unique identifier for the token
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiry),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

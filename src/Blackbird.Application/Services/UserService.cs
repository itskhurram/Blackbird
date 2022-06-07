using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;
using Blackbird.Domain.Interfaces;
using Blackbird.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blackbird.Application.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration) {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<IList<User>> GetAllUsers(bool? isActive = null) {
            return await _userRepository.GetAllUsers(isActive);
        }

        public async Task<User> GetById(long userId) {
            return await _userRepository.GetById(userId);
        }

        public async Task<User> Login(string loginName, string loginPassword) {
            return await _userRepository.Login(loginName, loginPassword);
        }

        public async Task<long> Signup(User user) {
            return await _userRepository.Signup(user);
        }
        public JWToken GenerateToken(Int64 userId, string userName) {
            var dateTimeNow = DateTime.Now;
            var tokenExpireTime = dateTimeNow.AddMinutes(Convert.ToDouble(_configuration["TokenAuthentication:JWTTokenExpirationTimeInMinutes"]));
            var refreshTokenExpirationTime = dateTimeNow.AddMinutes(Convert.ToDouble(_configuration["TokenAuthentication:JWTRefreshTokenExpirationTimeInMinutes"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
             };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["TokenAuthentication:SecretKey"]));

            var jwt = new JwtSecurityToken(
                issuer: _configuration["TokenAuthentication:Issuer"],
                audience: _configuration["TokenAuthentication:Audience"],
                claims: claims,
                notBefore: dateTimeNow,
                expires: tokenExpireTime,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return new JWToken() {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                RefreshToken = GenerateRefreshTokenKey(),
                TokenExpirationTimeInMinutes = tokenExpireTime,
                RefreshTokenExpirationTimeInMinutes = refreshTokenExpirationTime
            };
        }
        public string GenerateRefreshTokenKey() {
            var refreshKey = _configuration["TokenAuthentication:JWTRefreshTokenKey"];
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Concat(refreshKey, Guid.NewGuid().ToString())));
        }
    }
}

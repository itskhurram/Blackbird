using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;
using Blackbird.Domain.Models;
using Blackbird.Domain.ViewModels;
using Blackbird.Infrastructure.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blackbird.API.Controllers {

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AccountController : BaseController {
        #region Properties and Data Members
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenService _jwtRefreshTokenService;
        private readonly ILoginLogService _loginLogService;
        #endregion

        #region Constructor
        public AccountController(IUserService userService, IConfiguration configuration, IRefreshTokenService jWTRefreshTokenService, ILoginLogService loginLogService) {
            _userService = userService;
            _configuration = configuration;
            _jwtRefreshTokenService = jWTRefreshTokenService;
            _loginLogService = loginLogService;
        }
        #endregion

        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        public async Task<ActionResult<ResponseViewModel>> Login([FromBody] LoginViewModel login) {
            var response = new ResponseViewModel() { OperationStatus = false };

            if (ModelState.IsValid) {
                var user = await _userService.Login(login.LoginName, login.Password);

                if (user != null) {
                    //var assignedPermissions = await _dataPermissionService.GetDataPermissionByUserId(user.UserId);

                    //if (!assignedPermissions.Any()) {
                    //    response.Message = "User Has No Data Permission To Login";
                    //    return BadRequest(response);
                    //}

                    var jwtToken = GenerateToken(user.UserId, user.LoginName);

                    //_jwtRefreshTokenService.Insert(new RefreshToken() {
                    //    RefreshTokenKey = jwtToken.RefreshToken,
                    //    RefreshTokenExpirationTime = jwtToken.RefreshTokenExpirationTimeInMinutes,
                    //    UserId = user.UserId,
                    //    CreatedDate = DateTime.Now
                    //}).GetAwaiter().GetResult();

                    //_loginLogService.Insert(new LoginLog() {
                    //    UserId = user.UserId,
                    //    LoginTime = DateTime.Now,
                    //    ServerName = Environment.MachineName,
                    //    SessionToken = jwtToken.RefreshToken
                    //}).GetAwaiter().GetResult();

                    response.Data = user;
                    response.AdditionalData = jwtToken;
                    response.Message = "Login Successfully";
                    response.OperationStatus = true;

                    return Ok(response);
                }
                else {
                    response.Message = "Incorrect Username or Password";
                    return BadRequest(response);
                }
            }
            else {
                response.Message = "Invalid Request";
                return BadRequest(response);
            }
        }
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<ActionResult<ResponseViewModel>> GetRefreshToken([FromBody] JWToken jWToken) {
            var response = new ResponseViewModel() { OperationStatus = false };

            if (ModelState.IsValid) {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                SecurityToken validatedSecurityToken;

                var tokenValidationParams = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["TokenAuthentication:SecretKey"])),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["TokenAuthentication:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["TokenAuthentication:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
                };

                ClaimsPrincipal claimsPrincipal = jwtSecurityTokenHandler
                    .ValidateToken(jWToken.Token, tokenValidationParams, out validatedSecurityToken);

                var userId = claimsPrincipal.Claims
                    .Where(x => x.Type == ClaimTypes.Sid)
                    .Select(x => x.Value).FirstOrDefault();

                var userName = claimsPrincipal.Claims
                    .Where(x => x.Type == ClaimTypes.Name)
                    .Select(x => x.Value).FirstOrDefault();

                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userName)) {
                    var refreshToken = _jwtRefreshTokenService.GetRefreshTokenByUserId(Conversion.ToInt(userId), jWToken.RefreshToken).GetAwaiter().GetResult();

                    //Validation to check Refresh token is expire or not.
                    if (refreshToken != null && DateTime.Now <= refreshToken.RefreshTokenExpirationTime) {
                        var token = GenerateToken(Conversion.ToInt64(userId), userName);

                        refreshToken.UpdatedDate = DateTime.Now;
                        refreshToken.RefreshTokenKey = token.RefreshToken;
                        refreshToken.RefreshTokenExpirationTime = token.RefreshTokenExpirationTimeInMinutes;

                        await _jwtRefreshTokenService.Update(refreshToken);

                        response.Data = token;
                        response.Message = "TokenUpdateSuccessfully";
                        response.OperationStatus = true;
                        return Ok(response);
                    }
                    else {
                        response.Message = "Invalid Access Token or RefreshToken";
                    }
                }
                else {
                    response.Message = "Invalid Access Token or RefreshToken";
                }
            }
            else {
                response.Message = "Invalid Request";
            }
            return BadRequest(response);
        }
        [HttpPost]
        [Route("Logout")]
        public async Task<ActionResult<ResponseViewModel>> Logout(Int64 userId, string sessionToken) {
            var responseViewModel = new ResponseViewModel() { OperationStatus = false };

            if (userId > 0 && !string.IsNullOrEmpty(sessionToken)) {
                responseViewModel.OperationStatus = await _loginLogService.UpdateBySessionTokenAndUserId(userId, sessionToken);
                responseViewModel.Message = "Information has been saved";
                return Ok(responseViewModel);
            }
            else {
                responseViewModel.Message = "Invalid Request";
                return BadRequest(responseViewModel);
            }
        }

        #region Private Methods
        private JWToken GenerateToken(Int64 userId, string userName) {
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
        private string GenerateRefreshTokenKey() {
            var refreshKey = _configuration["TokenAuthentication:JWTRefreshTokenKey"];
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Concat(refreshKey, Guid.NewGuid().ToString())));
        }

        #endregion
    }
}

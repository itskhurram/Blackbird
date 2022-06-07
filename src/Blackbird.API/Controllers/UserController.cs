using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;
using Blackbird.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blackbird.API.Controllers {
    public class UserController : BaseController {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }
        [HttpGet("getAll")]
        public async Task<IEnumerable<User>> Get() {
            return await _userService.GetAllUsers(true);
        }
        [HttpGet("getById")]
        public async Task<User> GetById(long userId) {
            return await _userService.GetById(userId);
        }
        [HttpPost("signup")]
        public async Task<ActionResult<ResponseViewModel>> Signup(User user) {
            var response = new ResponseViewModel() { OperationStatus = false };
            user.UserId =  await _userService.Signup(user);

            if (user != null) {
                //var assignedPermissions = await _dataPermissionService.GetDataPermissionByUserId(user.UserId);

                //if (!assignedPermissions.Any()) {
                //    response.Message = "User Has No Data Permission To Login";
                //    return BadRequest(response);
                //}

                var jwtToken = _userService.GenerateToken(user.UserId, user.LoginName);

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
        //[HttpPost("login")]
        //public async Task<User> Login(string loginName, string loginPassword) {
        //    return await _userService.Login(loginName, loginPassword);
        //}
    }
}

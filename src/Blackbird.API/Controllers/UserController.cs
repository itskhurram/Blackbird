using Blackbird.Application.Interfaces;
using Blackbird.Domain;
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
        public async Task<long> Signup(User user) {
            return await _userService.Signup(user);
        }
    }
}

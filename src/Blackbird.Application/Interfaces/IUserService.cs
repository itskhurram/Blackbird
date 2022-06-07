using Blackbird.Domain.Entities;
using Blackbird.Domain.Models;

namespace Blackbird.Application.Interfaces {
    public interface IUserService {
        public Task<IList<User>> GetAllUsers(bool? isActive = null);
        public Task<User> GetById(long userId);
        public Task<User> Login(string loginName, string loginPassword);
        public Task<long> Signup(User user);
        public JWToken GenerateToken(Int64 userId, string userName);
    }
}

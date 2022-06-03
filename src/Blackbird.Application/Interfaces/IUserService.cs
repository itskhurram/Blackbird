using Blackbird.Domain.Entities;

namespace Blackbird.Application.Interfaces {
    public interface IUserService {
        public Task<IList<User>> GetAllUsers(bool? isActive = null);
        public Task<User> GetById(long userId);
        public Task<User> Login(string loginName, string loginPassword);
        public Task<long> Signup(User user);
    }
}

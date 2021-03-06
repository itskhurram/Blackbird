using Blackbird.Domain.Entities;

namespace Blackbird.Domain.Interfaces {
    public interface IUserRepository {
        public Task<IList<User>> GetAllUsers(bool? isActive = null);
        public Task<User> GetById(long userId);
        public Task<User> Login(string loginName, string loginPassword);
        public Task<long> Signup(User user);
    }
}

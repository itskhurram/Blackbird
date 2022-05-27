using Blackbird.Application.Interfaces;
using Blackbird.Domain;

namespace Blackbird.Application.Services {
    public class UserService : IUserService {
        public Task<IList<User>> GetAllUsers(bool? isActive = null) {
            throw new NotImplementedException();
        }

        public Task<User> GetById(long userId) {
            throw new NotImplementedException();
        }

        public Task<User> Login(string loginName, string loginPassword) {
            throw new NotImplementedException();
        }
    }
}

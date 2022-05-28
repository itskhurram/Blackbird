using Blackbird.Application.Interfaces;
using Blackbird.Domain;
using Blackbird.Domain.Interfaces;

namespace Blackbird.Application.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public async Task<IList<User>> GetAllUsers(bool? isActive = null) {
            return await _userRepository.GetAllUsers(isActive);
        }

        public async Task<User> GetById(long userId) {
            return await _userRepository.GetById(userId);
        }

        public Task<User> Login(string loginName, string loginPassword) {
            throw new NotImplementedException();
        }

        public Task<User> Signup(User user) {
            throw new NotImplementedException();
        }
    }
}

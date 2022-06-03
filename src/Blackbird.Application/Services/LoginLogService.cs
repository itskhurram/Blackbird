using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;

namespace Blackbird.Application.Services {
    public class LoginLogService : ILoginLogService {
        public Task<bool> Insert(LoginLog loginLog) {
            throw new NotImplementedException();
        }
        public Task<bool> Update(LoginLog loginLog) {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateBySessionTokenAndUserId(long userId, string sessionToken) {
            throw new NotImplementedException();
        }
    }
}

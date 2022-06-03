using Blackbird.Domain.Entities;

namespace Blackbird.Application.Interfaces {
    public interface ILoginLogService {
        public Task<bool> Insert(LoginLog loginLog);
        public Task<bool> Update(LoginLog loginLog);
        public Task<bool> UpdateBySessionTokenAndUserId(long userId, string sessionToken);
    }
}

using Blackbird.Domain.Entities;

namespace Blackbird.Domain.Interfaces {
    public interface ILoginLogRepository {
        public Task<bool> Insert(LoginLog loginLog);
        public Task<bool> Update(LoginLog loginLog);
        public Task<bool> UpdateBySessionTokenAndUserId(long userId, string sessionToken);
    }
}

using Blackbird.Domain.Entities;
using Blackbird.Domain.Interfaces;
using Blackbird.Domain.Interfaces.Base;

namespace Blackbird.Infrastructure.Persistance.Repositories {
    public class LoginLogRepository : ILoginLogRepository {
        private readonly IBaseRepository _baseRepository;
        public LoginLogRepository(IBaseRepository baseRepository) {
            _baseRepository = baseRepository;
        }
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

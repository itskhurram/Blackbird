using Blackbird.Domain.Entities;
using Blackbird.Domain.Interfaces;

namespace Blackbird.Infrastructure.Persistance.Repositories {
    public class RefreshTokenRepository : IRefreshTokenRepository {
        public Task<bool> CheckRefreshTokenIsValid(long userId, string refreshToken) {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetRefreshTokenByUserId(long userId, string refreshTokenKey) {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(RefreshToken jWTRefreshToken) {
            throw new NotImplementedException();
        }

        public Task<bool> Update(RefreshToken jWTRefreshToken) {
            throw new NotImplementedException();
        }
    }
}

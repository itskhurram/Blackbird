using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;

namespace Blackbird.Application.Services {
    public class RefreshTokenService : IRefreshTokenService {
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

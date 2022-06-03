using Blackbird.Domain.Entities;

namespace Blackbird.Application.Interfaces {
    public interface IRefreshTokenService {
        Task<RefreshToken> GetRefreshTokenByUserId(long userId, string refreshTokenKey);
        Task<bool> Insert(RefreshToken jWTRefreshToken);
        Task<bool> Update(RefreshToken jWTRefreshToken);
        Task<bool> CheckRefreshTokenIsValid(long userId, string refreshToken);

    }
}

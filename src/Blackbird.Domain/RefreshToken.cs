using Blackbird.Domain.Base;
namespace Blackbird.Domain {
    public class RefreshToken : EntityBase {
        #region private declarations
        private int jwtRefreshTokenId;
        private long userId;
        private string refreshTokenKey;
        private DateTime refreshTokenExpirationTime;
        #endregion
        public Int32 JwtRefreshTokenId {
            get => jwtRefreshTokenId;
            set {
                jwtRefreshTokenId = value;
                EntityModified();
            }
        }
        public Int64 UserId {
            get => userId; set {
                userId = value;
                EntityModified();
            }
        }
        public string RefreshTokenKey {
            get => refreshTokenKey; set {
                refreshTokenKey = value;
                EntityModified();
            }
        }
        public DateTime RefreshTokenExpirationTime {
            get => refreshTokenExpirationTime; set {
                refreshTokenExpirationTime = value;
                EntityModified();
            }
        }
    }
}


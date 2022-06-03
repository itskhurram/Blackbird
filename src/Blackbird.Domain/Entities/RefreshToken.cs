using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities {
    public class RefreshToken : EntityBase {
        #region private declarations
        private int refreshTokenId;
        private long userId;
        private string refreshTokenKey;
        private DateTime refreshTokenExpirationTime;
        #endregion
        public int RefreshTokenId {
            get => refreshTokenId;
            set {
                refreshTokenId = value;
                EntityModified();
            }
        }
        public long UserId {
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


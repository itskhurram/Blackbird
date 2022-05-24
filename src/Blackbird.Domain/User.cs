using Blackbird.Domain.Base;

namespace Blackbird.Domain {
    public class User : EntityBase {
        #region private declarations
        private long userId;
        private string? loginName;
        private string? loginPassword;
        private string? firstName;
        private string? lastName;
        private decimal rating;
        #endregion

        public long UserId {
            get => userId; set {
                userId = value;
                EntityModified();
            }
        }
        public string LoginName {
            get => loginName; set {
                loginName = value; EntityModified();
            }
        }
        public string LoginPassword {
            get => loginPassword; set {
                loginPassword = value;
                EntityModified();
            }
        }
        public string FirstName {
            get => firstName; set {
                firstName = value;
                EntityModified();
            }
        }
        public string LastName {
            get => lastName; set {
                lastName = value;
                EntityModified();
            }
        }
        public decimal Rating {
            get => rating; set {
                rating = value;
                EntityModified();
            }
        }
    }
}

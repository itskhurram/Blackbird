using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities {
    public class User : EntityBase {
        #region private declarations
        private long userId;
        private string? cnic;
        private string? emailAddress;
        private string? phoneNumber;
        private string? loginPassword;
        private string? firstName;
        private string? lastName;
        private string? secondaryContactNumber;
        private string? userProfilePictureURL;
        private double rating;
        private short accounttypeid;
        #endregion

        public long UserId {
            get => userId; set {
                userId = value;
                EntityModified();
            }
        }
        public string CNIC
        {
            get => cnic; set {
                cnic = value; EntityModified();
            }
        }
        public string EmailAddress
        {
            get => emailAddress; set {
                emailAddress = value; EntityModified();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set {
                phoneNumber = value; EntityModified();
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
        public string SecondaryContactNumber
        {
            get => secondaryContactNumber; set
            {
                secondaryContactNumber = value; EntityModified();
            }
        }
        public string UserProfilePictureURL
        {
            get => userProfilePictureURL; set
            {
                userProfilePictureURL = value; EntityModified();
            }
        }
        public double Rating {
            get => rating; set {
                rating = value;
                EntityModified();
            }
        }
        public short AccountTypeId {
            get => accounttypeid; set {
                accounttypeid = value;
                EntityModified();
            }
        }
    }
}

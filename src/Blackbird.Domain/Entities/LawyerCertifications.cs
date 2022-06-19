using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities
{
    public class LawyerCertifications : EntityBase
    {
        #region private declarations
        private long lawyerCertificationId;
        private string? certificationDocProofURL;
        private string? certificationTitle;
        private string? certificationCompletionYear;
        private string? certificationInstitute;
        private long userId;
        #endregion

        public long LawyerCertificationId
        {
            get => lawyerCertificationId; set
            {
                lawyerCertificationId = value;
                EntityModified();
            }
        }
        public string CertificationDocProofURL
        {
            get => certificationDocProofURL; set
            {
                certificationDocProofURL= value; EntityModified();
            }
        }
        public string CertificationTitle
        {
            get => certificationTitle; set
            {
                certificationTitle = value; EntityModified();
            }
        }
        public string CertificationCompletionYear
        {
            get => certificationCompletionYear; set
            {
                certificationCompletionYear = value; EntityModified();
            }
        }
        public string CcertificationInstitute
        {
            get => certificationInstitute; set
            {
                certificationInstitute = value; EntityModified();
            }
        }
        public long UserId
        {
            get => userId; set
            {
                userId = value;
                EntityModified();
            }
        }
    }
}

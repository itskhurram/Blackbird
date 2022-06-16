using Blackbird.Domain.Base;


namespace Blackbird.Domain.Entities
{
    public class LawyerExperience : EntityBase
    {
        #region private declarations
        private long lawyerExperienceId;
        private string? caseName;
        private string? caseCourt;
        private string? caseDuration;
        private DateOnly? caseStartDate;
        private long userId;
        #endregion

        public long LawyerExperienceId
        {
            get => lawyerExperienceId; set
            {
                lawyerExperienceId = value;
                EntityModified();
            }
        }
        public string CaseName
        {
            get => caseName; set
            {
                caseName = value; EntityModified();
            }
        }
        public string CaseCourt
        {
            get => caseCourt; set
            {
                caseCourt = value; EntityModified();
            }
        }
        public string CaseDuration
        {
            get => caseDuration; set
            {
                caseDuration = value; EntityModified();
            }
        }
        public DateOnly CaseStartDate
        {
            get => (DateOnly)caseStartDate; set
            {
                caseStartDate = value; EntityModified();
            }
        }
        public long UserId
        {
            get => userId; set
            {
                userId = value; EntityModified();
            }
        }
    }
}

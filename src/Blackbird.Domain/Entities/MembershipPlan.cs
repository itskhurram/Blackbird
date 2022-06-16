using Blackbird.Domain.Base;


namespace Blackbird.Domain.Entities
{
    public class MembershipPlan : EntityBase
    {
        #region private declarations
        private long membershipPlanId;
        private string? membershipPlanName;
        private string? feature1;
        private string? feature2;
        private string? feature3;
        private string? feature4;
        #endregion

        public long MembershipPlanId
        {
            get => membershipPlanId; set
            {
                membershipPlanId = value;
                EntityModified();
            }
        }
        public string MembershipPlanName
        {
            get => membershipPlanName; set
            {
                membershipPlanName = value; EntityModified();
            }
        }
        public string Feature1
        {
            get => feature1; set
            {
                feature1 = value; EntityModified();
            }
        }
        public string Feature2
        {
            get => feature2; set
            {
                feature2 = value; EntityModified();
            }
        }
        public string Feature3
        {
            get => feature3; set
            {
                feature3 = value; EntityModified();
            }
        }
        public string Feature4
        {
            get => feature4; set
            {
                feature4 = value; EntityModified();
            }
        }
    }
}

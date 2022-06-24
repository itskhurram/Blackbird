using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities
{
    public class LawyerDashboardInfo : EntityBase
    {
        #region private declarations
        private long lawyerDashboardInfoId;
        private long userId;
        private long current_MembershipPlanID;
        private DateOnly current_MembershipPlan_Registered_On;
        private DateOnly current_MembershipPlan_Expires_On;
        private long total_Clients_View_Profile;
        private long total_Clients_Message_Through_Website;
        private long total_Clients_Message_Through_Whatsapp;
        private long total_Clients_Message_Through_Facebook;
        #endregion

        public long LawyerDashboardInfoId
        {
            get => lawyerDashboardInfoId; set
            {
                lawyerDashboardInfoId = value;
                EntityModified();
            }
        }
        public long UserId
        {
            get => userId; set
            {
                userId = value; EntityModified();
            }
        }
        public long Current_MembershipPlanID
        {
            get => current_MembershipPlanID; set
            {
                current_MembershipPlanID = value; EntityModified();
            }
        }
        public DateOnly Current_MembershipPlan_Registered_On
        {
            get => current_MembershipPlan_Registered_On; set
            {
                current_MembershipPlan_Registered_On = value; EntityModified();
            }
        }
        public DateOnly Current_MembershipPlan_Expires_On
        {
            get => current_MembershipPlan_Expires_On; set
            {
                current_MembershipPlan_Expires_On = value; EntityModified();
            }
        }
        public long Total_Clients_View_Profile
        {
            get => total_Clients_View_Profile; set
            {
                total_Clients_View_Profile = value; EntityModified();
            }
        }
        public long Total_Clients_Message_Through_Website
        {
            get => total_Clients_Message_Through_Website; set
            {
                total_Clients_Message_Through_Website = value; EntityModified();
            }
        }
        public long Total_Clients_Message_Through_Whatsapp
        {
            get => total_Clients_Message_Through_Whatsapp; set
            {
                total_Clients_Message_Through_Whatsapp = value; EntityModified();
            }
        }
        public long Total_Clients_Message_Through_Facebook
        {
            get => total_Clients_Message_Through_Facebook; set
            {
                total_Clients_Message_Through_Facebook = value; EntityModified();
            }
        }
    }
}

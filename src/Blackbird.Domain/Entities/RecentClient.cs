using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities
{
    public class RecentClient: EntityBase
    {
        #region private declarations
        private long recentClientId;
        private string? name;
        private string? caseTitle;
        private string? location;
        private string? status;
        private DateTime appointmentDateTime;
        private string message;
        #endregion

        public long RecentClientId
        {
            get => recentClientId; set
            {
                recentClientId = value;
                EntityModified();
            }
        }
        public string Name
        {
            get => name; set
            {
                name = value; EntityModified();
            }
        }
        public string CaseTitle
        {
            get => caseTitle; set
            {
                caseTitle = value; EntityModified();
            }
        }
        public string Location
        {
            get => location; set
            {
                location = value; EntityModified();
            }
        }
        public string Status
        {
            get => status; set
            {
                status = value; EntityModified();
            }
        }
        public DateTime AppointmentDateTime
        {
            get => appointmentDateTime; set
            {
                appointmentDateTime = value; EntityModified();
            }
        }
        public string Message
        {
            get => message; set
            {
                message = value; EntityModified();
            }
        }
    }
}

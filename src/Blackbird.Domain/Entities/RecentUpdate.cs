using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities
{
    public class RecentUpdate : EntityBase
    {
        #region private declarations
        private long recentUpdateId;
        private string? userName;
        private string? details;
        private long forUser_userId;
        private long fromUser_userId;
        #endregion

        public long RecentUpdateId
        {
            get => recentUpdateId; set
            {
                recentUpdateId = value;
                EntityModified();
            }
        }
        public string UserName
        {
            get => userName; set
            {
                userName = value; EntityModified();
            }
        }
        public string Details
        {
            get => details; set
            {
                details = value; EntityModified();
            }
        }
        public long ForUser_userId
        {
            get => forUser_userId; set
            {
                forUser_userId = value; EntityModified();
            }
        }
        public long FromUser_userId
        {
            get => fromUser_userId; set
            {
                fromUser_userId = value; EntityModified();
            }
        }
    }
}

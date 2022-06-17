using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities
{
    public class LawyerDashboardInfo : EntityBase
    {
        #region private declarations
        private long lawyersTopRecommendId;
        private long userId;
        private long categoryId; // if 0 then he is universally recommended, else in a particular category
        #endregion

        public long LawyersTopRecommendId
        {
            get => lawyersTopRecommendId; set
            {
                lawyersTopRecommendId = value;
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

    }
}

using Blackbird.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbird.Domain.Entities
{
    public class LawyersTopRecommend : EntityBase
    {
        #region private declarations
        private long lawyersTopRecommendId;
        private long userId;
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

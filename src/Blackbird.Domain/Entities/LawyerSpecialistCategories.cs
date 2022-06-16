using Blackbird.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbird.Domain.Entities
{
    public class LawyerSpecialistCategories : EntityBase
    {
        #region private declarations
        private long lawyerSpecialistCategoryId;
        private long userId;
        private long categoryId;
        #endregion

        public long LawyerSpecialistCategoryId
        {
            get => lawyerSpecialistCategoryId; set
            {
                lawyerSpecialistCategoryId = value;
                EntityModified();
            }
        }
        public long UserId
        {
            get => userId; set
            {
                userId= value; EntityModified();
            }
        }
        public long CategoryId
        {
            get => categoryId; set
            {
                categoryId = value; EntityModified();
            }
        }
    }
}

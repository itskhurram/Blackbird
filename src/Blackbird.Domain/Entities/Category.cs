using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities {
    public class Category : EntityBase {
        #region private declarations
        private long categoryId;
        private string? categoryName;
        #endregion

        public long CategoryId {
            get => categoryId; set {
                categoryId = value;
                EntityModified();
            }
        }
        public string CategoryName {
            get => categoryName; set {
                categoryName = value; EntityModified();
            }
        }
    }
}

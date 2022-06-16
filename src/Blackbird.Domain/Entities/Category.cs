using Blackbird.Domain.Base;

namespace Blackbird.Domain.Entities {
    public class Category : EntityBase {
        #region private declarations
        private long categoryId;
        private string? categoryName;
        private string? categoryDescription;
        private bool isParent;
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
        public string CategoryDescription
        {
            get => categoryDescription; set {
                categoryDescription = value; EntityModified();
            }
        }
        
        public bool IsParent
        {
            get => isParent; set {
                isParent = value; EntityModified();
            }
        }
    }
}

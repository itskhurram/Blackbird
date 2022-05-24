namespace Blackbird.Domain.Base {
    public class EntityBase {
        private bool isActive;
        private int createdBy;
        private DateTime createdDate;
        private int? updatedBy;
        private DateTime? updatedDate;

        public EntityBase() {
            RowState = EntityState.New;
        }

        public bool IsActive {
            get => isActive; set {
                isActive = value;
                EntityModified();
            }
        }
        public int CreatedBy {
            get => createdBy; set {
                createdBy = value;
                EntityModified();
            }
        }
        public DateTime CreatedDate {
            get => createdDate; set {
                createdDate = value;
                EntityModified();
            }
        }
        public int? UpdatedBy {
            get => updatedBy; set {
                updatedBy = value;
                EntityModified();
            }
        }
        public DateTime? UpdatedDate {
            get => updatedDate; set {
                updatedDate = value;
                EntityModified();
            }
        }
        public EntityState RowState { get; set; }
        public void AcceptChanges() {
            RowState = EntityState.Unchanged;
        }
        public void RejectChanges() {
            RowState = EntityState.Unchanged;
        }
        public void EntityModified() {
            if (RowState == EntityState.Unchanged) RowState = EntityState.Modified;
        }
        public bool IsValid() {
            return true;
        }
    }
    public enum EntityState {
        Unchanged = 0,
        New = 1,
        Modified = 2,
        Deleted = 3,
        Excluded = 4
    }
}

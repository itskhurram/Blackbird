namespace Blackbird.Domain.ViewModels {
    public class ResponseViewModel {
        #region Properties and Data Members
        public object Data { get; set; }
        public object AdditionalData { get; set; }
        public string Message { get; set; }
        public bool OperationStatus { get; set; }
        #endregion
    }
}

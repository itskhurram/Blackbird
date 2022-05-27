namespace Blackbird.Domain.Interfaces {
    public interface IAccountTypeRepository {
        Task<IList<AccountType>> GetAllAccountTypes(bool? IsActive = null);
    }
}

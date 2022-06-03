using Blackbird.Domain.Entities;

namespace Blackbird.Domain.Interfaces {
    public interface IAccountTypeRepository {
        Task<IList<AccountType>> GetAllAccountTypes(bool? isActive = null);
    }
}

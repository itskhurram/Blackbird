using Blackbird.Domain.Entities;

namespace Blackbird.Application.Interfaces {
    public interface IAccountTypeService {
        public Task<IList<AccountType>> GetAllAccountTypes(bool? isActive = null);

    }
}

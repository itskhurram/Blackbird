using Blackbird.Application.Interfaces;
using Blackbird.Domain.Entities;
using Blackbird.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbird.Application.Services {
    public class AccountTypeService : IAccountTypeService {
        private readonly IAccountTypeRepository _accountTypeRepository;
        public AccountTypeService(IAccountTypeRepository accountTypeRepository) {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<IList<AccountType>> GetAllAccountTypes(bool? isActive = null) {
            return await _accountTypeRepository.GetAllAccountTypes(isActive);
        }
    }
}

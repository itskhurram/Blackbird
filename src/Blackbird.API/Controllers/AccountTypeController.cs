using Blackbird.Application.Interfaces;
using Blackbird.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blackbird.API.Controllers {
    public class AccountTypeController : BaseController {
        private readonly IAccountTypeService _accountTypeService;
        public AccountTypeController(IAccountTypeService accountTypeService) {
            _accountTypeService = accountTypeService;
        }
        [HttpGet]
        public async Task<IEnumerable<AccountType>> Get() {
            return await _accountTypeService.GetAllAccountTypes(true);
        }
    }
}

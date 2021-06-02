using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
}

using Dapper;
using MISA.Core.Entities;
using MISA.Core.Enumerations;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        public ServiceResult Insert(string parentAccountNumber, Account account)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {

                serviceResult = CheckValidate(account);

                if (parentAccountNumber != null)
                {
                    Account isExistsParent = _accountRepository.GetByProperty("AccountNumber", parentAccountNumber);
                    if (isExistsParent == null)
                    {
                        serviceResult.ResultCode = (int)EnumServiceResult.Fail;
                        return serviceResult;
                    }
                }

                if (serviceResult.ResultCode != (int)EnumServiceResult.NotValid)
                {
                    serviceResult.Data = _accountRepository.Insert(parentAccountNumber, account);
                }
            }
            catch (Exception ex)
            {
                serviceResult.DevMessage.Add(ex.Message);
            }
            return serviceResult;
        }
    }
}

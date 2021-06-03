using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IAccountService : IBaseService<Account>
    {
        public ServiceResult Insert(string parentAccountNumber, Account account);
    }
}

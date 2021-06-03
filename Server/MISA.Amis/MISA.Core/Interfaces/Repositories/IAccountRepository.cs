using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        public int Insert (string parentAccountNumber, Account account);
    }
}

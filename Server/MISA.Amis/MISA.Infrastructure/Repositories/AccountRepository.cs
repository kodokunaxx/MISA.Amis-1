using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
    }
}

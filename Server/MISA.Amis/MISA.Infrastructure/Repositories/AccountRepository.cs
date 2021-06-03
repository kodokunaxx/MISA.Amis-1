using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {

        public int Insert(string parentAccountNumber, Account account)
        {

            string sqlCommand = "Proc_InsertAccount";
            DynamicParameters dynamicparameters = new DynamicParameters();

            foreach (PropertyInfo prop in account.GetType().GetProperties())
            {
                dynamicparameters.Add($"@{prop.Name}", prop.GetValue(account));
            }
            dynamicparameters.Add("@ParentAccountNumber", parentAccountNumber);

            int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicparameters, commandType: CommandType.StoredProcedure);

            return rowAffects;
        }
    }
}

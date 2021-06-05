using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class ReceiptPaymentRepository : BaseRepository<ReceiptPayment>, IReceiptPaymentRepository
    {
        public string GetLastestCode()
        {
            string sqlCommand = "Proc_GetLastestVoucherNumber";
            return _dbConnection.QueryFirstOrDefault<string>(sqlCommand, commandType: CommandType.StoredProcedure);
        }
    }
}

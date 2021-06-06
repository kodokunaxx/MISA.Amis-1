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
        public IEnumerable<ReceiptPayment> GetFilter(string Vouchernumber, string VendorName, string VendorCode, int PageIndex, int PageSize)
        {
            string sqlCommand = "Proc_GetReceiptPaymentFilter";
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Vouchernumber", Vouchernumber);
            dynamicParameters.Add("@VendorCode", VendorCode);
            dynamicParameters.Add("@VendorName", VendorName);
            dynamicParameters.Add("@PageIndex", PageIndex);
            dynamicParameters.Add("@PageSize", PageSize);

            return _dbConnection.Query<ReceiptPayment>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<ReceiptPayment> GetAll(int PageIndex, int PageSize)
        {
            string sqlCommand = "Proc_GetReceiptPaymentPaging";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageIndex", PageIndex);
            dynamicParameters.Add("@PageSize", PageSize);

            return _dbConnection.Query<ReceiptPayment>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public int GetCount()
        {
            try
            {
                string sqlCommand = "Proc_GetReceiptPaymentCount";

                int count = _dbConnection.QueryFirstOrDefault<int>(sqlCommand, commandType: CommandType.StoredProcedure);
                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int GetFilterCount(string Vouchernumber, string VendorName, string VendorCode)
        {
            try
            {
                string sqlCommand = "Proc_GetReceiptPaymentFilterCount";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Vouchernumber", Vouchernumber);
                dynamicParameters.Add("@VendorName", VendorName);
                dynamicParameters.Add("@VendorCode", VendorCode);

                int count = _dbConnection.QueryFirst<int>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}

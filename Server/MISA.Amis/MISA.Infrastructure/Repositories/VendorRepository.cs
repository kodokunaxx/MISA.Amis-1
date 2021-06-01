using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
    {
        public VendorRepository()
        {
        }

        public string GetLastestCode()
        {
            string sqlCommand = "Proc_GetLastestVendorCode";
            return _dbConnection.QueryFirstOrDefault<string>(sqlCommand, commandType: CommandType.StoredProcedure);
        }

        public Vendor GetByCode(string vendorCode)
        {
            string sqlCommand = "Proc_GetVendorByCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters

            return _dbConnection.QueryFirstOrDefault<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vendor> GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard, int PageIndex, int PageSize)
        {
            string sqlCommand = "Proc_GetVendorFilter";
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@VendorCode", VendorCode);
            dynamicParameters.Add("@VendorName", VendorName);
            dynamicParameters.Add("@Address", Address);
            dynamicParameters.Add("@Debt", Debt);
            dynamicParameters.Add("@TaxCode", TaxCode);
            dynamicParameters.Add("@PhoneNumber", PhoneNumber);
            dynamicParameters.Add("@IdCard", IdCard);
            dynamicParameters.Add("@PageIndex", PageIndex);
            dynamicParameters.Add("@PageSize", PageSize);

            return _dbConnection.Query<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vendor> GetAll(int PageIndex, int PageSize)
        {
            string sqlCommand = "Proc_GetVendorPaging";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageIndex", PageIndex);
            dynamicParameters.Add("@PageSize", PageSize);

            return _dbConnection.Query<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public int GetCount()
        {
            try
            {
                string sqlCommand = "Proc_GetVendorCount";

                int count = _dbConnection.QueryFirstOrDefault<int>(sqlCommand, commandType: CommandType.StoredProcedure);
                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int GetFilterCount(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard)
        {
            try
            {
                string sqlCommand = "Proc_GetVendorFilterCount";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@VendorCode", VendorCode);
                dynamicParameters.Add("@VendorName", VendorName);
                dynamicParameters.Add("@Address", Address);
                dynamicParameters.Add("@Debt", Debt);
                dynamicParameters.Add("@TaxCode", TaxCode);
                dynamicParameters.Add("@PhoneNumber", PhoneNumber);
                dynamicParameters.Add("@IdCard", IdCard);

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

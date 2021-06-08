using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using Npgsql;
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
            //string sqlCommand = "SELECT GetLastestVendorCode()";
            //return _dbConnection.QueryFirstOrDefault<string>(sqlCommand);
        }

        public Vendor GetByCode(string vendorCode)
        {
            string sqlCommand = "Proc_GetVendorByCode";
            //string sqlCommand = $"GetVendorByVendorCode('{vendorCode}')";

            DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters

            return _dbConnection.QueryFirstOrDefault<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            //return _dbConnection.QueryFirstOrDefault<Vendor>(sqlCommand);
        }

        public IEnumerable<Vendor> GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard, int PageIndex, int PageSize)
        {
            string sqlCommand = "Proc_GetVendorFilter";
            //string sqlCommand = $"SELECT * FROM GetVendorFilter('{VendorCode}', '{VendorName}', '{Address}', '{Debt}', '{TaxCode}', '{PhoneNumber}', '{IdCard}', {PageIndex},{PageSize})"; // postgres
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
            //return _dbConnection.Query<Vendor>(sqlCommand);
        }

        public IEnumerable<Vendor> GetAll(int PageIndex, int PageSize)
        {
            string sqlCommand = "Proc_GetVendorPaging";
            //string sqlCommand = $"Select * from GetVendorPaging({PageIndex}, {PageSize})";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageIndex", PageIndex);
            dynamicParameters.Add("@PageSize", PageSize);

            return _dbConnection.Query<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            //return _dbConnection.Query<Vendor>(sqlCommand); 
        }

        public int GetCount()
        {
            try
            {
                string sqlCommand = "Proc_GetVendorCount";
                //string sqlCommand = "SELECT GetVendorCount()";

                int count = _dbConnection.QueryFirstOrDefault<int>(sqlCommand, commandType: CommandType.StoredProcedure);
                //int count = _dbConnection.QueryFirstOrDefault<int>(sqlCommand);
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
                //string sqlCommand = $"SELECT GetVendorFilterCount('{VendorCode}', '{VendorName}', '{Address}', '{Debt}', '{TaxCode}', '{PhoneNumber}', '{IdCard}')";
                
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@VendorCode", VendorCode);
                dynamicParameters.Add("@VendorName", VendorName);
                dynamicParameters.Add("@Address", Address);
                dynamicParameters.Add("@Debt", Debt);
                dynamicParameters.Add("@TaxCode", TaxCode);
                dynamicParameters.Add("@PhoneNumber", PhoneNumber);
                dynamicParameters.Add("@IdCard", IdCard);

                int count = _dbConnection.QueryFirst<int>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                //int count = _dbConnection.QueryFirst<int>(sqlCommand);
                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

    }
}

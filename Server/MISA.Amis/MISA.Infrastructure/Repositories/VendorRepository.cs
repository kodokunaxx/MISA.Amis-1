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

        public Vendor GetByCode(string vendorCode)
        {
            string sqlCommand = "Proc_GetVendorByCode";
            DynamicParameters dynamicParameters = new DynamicParameters();

            return _dbConnection.QueryFirstOrDefault<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vendor> GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard)
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

            return _dbConnection.Query<Vendor>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}

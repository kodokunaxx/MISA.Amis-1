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

    }
}

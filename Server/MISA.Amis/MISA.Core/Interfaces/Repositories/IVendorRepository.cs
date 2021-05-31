using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    public interface IVendorRepository : IBaseRepository<Vendor>
    {
        public Vendor GetByCode(string vendorCode);
    }
}

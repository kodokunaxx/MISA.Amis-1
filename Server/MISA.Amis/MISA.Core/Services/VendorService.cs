using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class VendorService : BaseService<Vendor>, IVendorService
    {
        IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository) : base(vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
    }
}

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

        public ServiceResult GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _vendorRepository.GetFilter(VendorCode, VendorName, Address, Debt, TaxCode, PhoneNumber, IdCard);

            return serviceResult;
        }
    }
}

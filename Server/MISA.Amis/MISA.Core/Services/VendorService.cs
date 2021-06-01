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

        public ServiceResult GenerateNewCode()
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {

                string lastestCode = _vendorRepository.GetLastestCode();
                if( lastestCode == null)
                {
                    serviceResult.Data = "NCC00001";
                    return serviceResult;
                }
                string number = lastestCode.Substring(3);
                int firstIndex = 0;

                while( firstIndex <  number.Length && number[firstIndex] == '0')
                {
                    firstIndex++;
                }

                int currentNumberLength = number.Length - firstIndex;
                if( ((Int32.Parse(number) + 1) + "").Length > currentNumberLength && firstIndex > 0)
                {
                    firstIndex--;
                }

                serviceResult.Data = lastestCode.Substring(0, 3 + firstIndex) + (Int32.Parse(number) + 1);
            }
            catch (Exception ex)
            {
                serviceResult.DevMessage.Add(ex.Message);
            }

            return serviceResult;
        }

        public ServiceResult GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _vendorRepository.GetFilter(VendorCode, VendorName, Address, Debt, TaxCode, PhoneNumber, IdCard);

            return serviceResult;
        }
    }
}

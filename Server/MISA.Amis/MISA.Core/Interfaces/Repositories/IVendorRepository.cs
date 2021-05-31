using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    public interface IVendorRepository : IBaseRepository<Vendor>
    {
        public Vendor GetByCode(string vendorCode);

        /// <summary>
        /// Tìm kiếm qua keywords
        /// CreatedBy: nvcuong (31/05/2021)
        /// </summary>
        /// <param name="VendorCode"></param>
        /// <param name="VendorName"></param>
        /// <param name="Address"></param>
        /// <param name="Debt"></param>
        /// <param name="TaxCode"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="IdCard"></param>
        /// <returns></returns>
        public IEnumerable<Vendor> GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard);
    }
}

using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IVendorService : IBaseService<Vendor>
    {
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
        public ServiceResult GetFilter(string VendorCode, string VendorName, string Address, string Debt, string TaxCode, string PhoneNumber, string IdCard);

        /// <summary>
        /// Tạo ra mã NCC mới
        /// CreatedBy: nvcuong (31/05/2021)
        /// </summary>
        /// <returns>Mã NCC mới</returns>
        public ServiceResult GenerateNewCode();
    }
}

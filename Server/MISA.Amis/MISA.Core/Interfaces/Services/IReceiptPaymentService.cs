using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IReceiptPaymentService : IBaseService<ReceiptPayment>
    {
        /// <summary>
        /// Lấy ra tất cả các bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        public ServiceResult GetAll(int PageIndex, int PageSize);


        /// <summary>
        /// Tìm kiếm qua keywords
        /// CreatedBy: nvcuong (31/05/2021)
        /// </summary>
        /// <param name="VendorCode"></param>
        /// <param name="VendorName"></param>
        /// <param name="VoucherNumber"></param>
        /// <returns></returns>
        public ServiceResult GetFilter(string VoucherNumber, string VendorName, string VendorCode, int PageIndex, int PageSize);


        /// <summary>
        /// Tạo ra mã NCC mới
        /// CreatedBy: nvcuong (31/05/2021)
        /// </summary>
        /// <returns>Mã NCC mới</returns>
        public ServiceResult GenerateNewCode();
    }
}

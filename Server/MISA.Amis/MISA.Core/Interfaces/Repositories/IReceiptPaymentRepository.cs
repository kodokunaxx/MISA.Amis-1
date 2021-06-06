using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    public interface IReceiptPaymentRepository : IBaseRepository<ReceiptPayment>
    {
        /// <summary>
        /// Tạo ra mã NCC mới
        /// CreatedBy: nvcuong (31/05/2021)
        /// </summary>
        /// <returns>Mã NCC mới</returns>
        public string GetLastestCode();

        /// <summary>
        /// Lấy ra tất cả các bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        public IEnumerable<ReceiptPayment> GetAll(int PageIndex, int PageSize);

        /// <summary>
        /// Tìm kiếm qua keywords
        /// CreatedBy: nvcuong (31/05/2021)
        /// </summary>
        /// <param name="VendorCode"></param>
        /// <param name="VendorName"></param>
        /// <param name="VoucherNumber"></param>
        /// <returns></returns>
        public IEnumerable<ReceiptPayment> GetFilter(string VoucherNumber, string VendorName, string VendorCode, int PageIndex, int PageSize);

        public int GetCount();
        public int GetFilterCount(string VoucherNumber, string VendorName, string VendorCode);

    }
}

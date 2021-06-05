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
    }
}

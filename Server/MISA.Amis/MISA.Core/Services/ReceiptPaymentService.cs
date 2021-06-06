using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class ReceiptPaymentService : BaseService<ReceiptPayment>, IReceiptPaymentService
    {
        IReceiptPaymentRepository _receiptPaymentRepository;
        public ReceiptPaymentService(IReceiptPaymentRepository receiptPaymentRepository) : base(receiptPaymentRepository)
        {
            _receiptPaymentRepository = receiptPaymentRepository;
        }

        public ServiceResult GetAll(int PageIndex, int PageSize)
        {
            ServiceResult serviceResult = new ServiceResult();
            if (PageIndex <= 0) PageIndex = 1;
            if (PageSize <= 0) PageSize = 20;

            serviceResult.Data = _receiptPaymentRepository.GetAll(PageIndex, PageSize);
            serviceResult.Total = _receiptPaymentRepository.GetCount();

            return serviceResult;
        }

        public ServiceResult GetFilter(string VoucherNumber, string VendorName, string VendorCode, int PageIndex, int PageSize)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _receiptPaymentRepository.GetFilter(VoucherNumber, VendorName, VendorCode, PageIndex, PageSize);
            serviceResult.Total = _receiptPaymentRepository.GetFilterCount(VoucherNumber, VendorName, VendorCode);

            return serviceResult;
        }

        public ServiceResult GenerateNewCode()
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {

                string lastestCode = _receiptPaymentRepository.GetLastestCode();
                if (lastestCode == null)
                {
                    serviceResult.Data = "PC00001";
                    return serviceResult;
                }
                string number = lastestCode.Substring(2);
                int firstIndex = 0;

                while (firstIndex < number.Length && number[firstIndex] == '0')
                {
                    firstIndex++;
                }

                int currentNumberLength = number.Length - firstIndex;
                if (((Int32.Parse(number) + 1) + "").Length > currentNumberLength && firstIndex > 0)
                {
                    firstIndex--;
                }

                serviceResult.Data = lastestCode.Substring(0, 2 + firstIndex) + (Int32.Parse(number) + 1);
            }
            catch (Exception ex)
            {
                serviceResult.DevMessage.Add(ex.Message);
            }

            return serviceResult;
        }
    }
}

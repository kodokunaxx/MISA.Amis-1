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

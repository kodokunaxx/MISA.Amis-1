using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Amis.API.Controllers
{
    public class ReceiptPaymentController : BaseController<ReceiptPayment>
    {
        IReceiptPaymentService _receiptPaymentService;
        public ReceiptPaymentController(IReceiptPaymentService receiptPaymentService) : base(receiptPaymentService)
        {
            _receiptPaymentService = receiptPaymentService;
        }

        [HttpGet("paging")]
        public IActionResult Get([FromQuery] int PageIndex, [FromQuery] int PageSize)
        {
            ServiceResult serviceResult = _receiptPaymentService.GetAll(PageIndex, PageSize);

            return Ok(serviceResult);
        }

        [HttpGet("filter")]
        public IActionResult Get(string keywords, int PageIndex, int PageSize)
        {
            ServiceResult serviceResult = _receiptPaymentService.GetFilter(keywords, keywords, keywords, PageIndex, PageSize);
            return Ok(serviceResult);
        }

        [HttpGet("new-code")]
        public IActionResult Get()
        {
            ServiceResult serviceResult = _receiptPaymentService.GenerateNewCode();
            if (serviceResult.Data != null)
                return Ok(serviceResult);
            return NoContent();
        }
    }
}

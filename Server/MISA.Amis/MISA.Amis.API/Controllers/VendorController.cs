using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using MISA.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Amis.API.Controllers
{

    public class VendorController : BaseController<Vendor>
    {
        IVendorService _vendorService;
        public VendorController(IVendorService vendorService) : base(vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet("paging")]
        public IActionResult Get([FromQuery] int PageIndex, [FromQuery] int PageSize )
        {
            ServiceResult serviceResult = _vendorService.GetAll(PageIndex, PageSize);

            return Ok(serviceResult);
        }

        [HttpGet("filter")]
        public IActionResult Get(string keywords, int PageIndex, int PageSize)
        {
            ServiceResult serviceResult = _vendorService.GetFilter(keywords, keywords, keywords, keywords, keywords, keywords, keywords, PageIndex, PageSize);
            return Ok(serviceResult);
        }

        [HttpGet("new-code")]
        public IActionResult Get()
        {
            ServiceResult serviceResult = _vendorService.GenerateNewCode();
            if (serviceResult.Data != null)
                return Ok(serviceResult);
            return NoContent();
        }
    }
}

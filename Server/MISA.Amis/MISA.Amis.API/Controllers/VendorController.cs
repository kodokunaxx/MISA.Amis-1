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

        [HttpGet("filter")]
        public IActionResult Get(string keywords)
        {
            ServiceResult serviceResult = _vendorService.GetFilter(keywords, keywords, keywords, keywords, keywords, keywords, keywords);
            return Ok(serviceResult);
        }
    }
}

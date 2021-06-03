using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Enumerations;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Amis.API.Controllers
{

    public class AccountController : BaseController<Account>
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService) : base(accountService)
        {
            _accountService = accountService;

        }

        [HttpPost("{refer}")]
        public IActionResult Post(string refer, [FromBody] Account account)
        {
            ServiceResult serviceResult = _accountService.Insert(refer, account);
            if (serviceResult.ResultCode == (int)EnumServiceResult.NotValid)
            {
                return BadRequest(serviceResult);
            }
            return StatusCode(201, serviceResult);
        }
    }
}

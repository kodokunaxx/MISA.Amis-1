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

    public class AccountController : BaseController<Account>
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService) : base(accountService)
        { 
            _accountService = accountService;
        }
    }
}

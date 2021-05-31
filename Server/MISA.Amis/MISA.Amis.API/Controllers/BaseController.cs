using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Enumerations;
using MISA.Core.Interfaces.Services;
using MISA.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Amis.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {

        #region Declares
        IBaseService<T> _baseService;

        #endregion

        #region Constructors

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        #endregion

        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            ServiceResult serviceResult = _baseService.GetAll();

            return Ok(serviceResult);
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _baseService.GetById(id);
            return Ok(entity);
        }

        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] T enitty)
        {
            ServiceResult serviceResult = _baseService.Insert(enitty);
            if( serviceResult.ResultCode == (int)EnumServiceResult.NotValid)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, T entity)
        {
            ServiceResult serviceResult = _baseService.Update(id, entity);
            if (serviceResult.ResultCode == (int)EnumServiceResult.Success)
                return Ok(serviceResult);
            else if (serviceResult.ResultCode == (int)EnumServiceResult.NotValid)
                return BadRequest(serviceResult);

            return NoContent();
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            ServiceResult serviceResult = _baseService.Delete(id);
            if( (int) serviceResult.Data > 0)
            {
                return Ok(serviceResult);
            }
            return NoContent();
        }
    }
}

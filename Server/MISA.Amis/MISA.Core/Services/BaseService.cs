using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public ServiceResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAll()
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _baseRepository.GetAll();

            return serviceResult;
        }

        public ServiceResult GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(Guid id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}

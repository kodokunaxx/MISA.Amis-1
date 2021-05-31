using Dapper;
using MISA.Core.Entities;
using MISA.Core.Enumerations;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declares
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructors
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        public ServiceResult Delete(Guid id)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _baseRepository.Delete(id);
            return serviceResult;
        }

        public virtual ServiceResult GetAll()
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                serviceResult.Data = _baseRepository.GetAll();
            }
            catch (Exception ex)
            {
                serviceResult.DevMessage.Add(ex.Message);
            }
            return serviceResult;
        }

        public ServiceResult GetById(Guid id)
        {
            ServiceResult serviceResult = new ServiceResult();
            DynamicParameters dynamicParamaters = new DynamicParameters();

            dynamicParamaters.Add("@id", id);
            try
            {
                serviceResult.Data = _baseRepository.GetById(id);
            }
            catch (Exception ex)
            {
                serviceResult.DevMessage.Add(ex.Message);
            }

            return serviceResult;
        }

        public virtual ServiceResult Insert(T entity)
        {
            ServiceResult serviceResult = CheckValidate(entity);
            if (serviceResult.ResultCode != (int)EnumServiceResult.NotValid)
            {
                serviceResult.Data = _baseRepository.Insert(entity);
            }
            return serviceResult;
        }

        public virtual ServiceResult Update(Guid id, T entity)
        {
            ServiceResult serviceResult = new ServiceResult();
            T isExsitsEntity = _baseRepository.GetById(id);
            try
            {

                if (isExsitsEntity == null)
                {
                    serviceResult.ResultCode = (int)EnumServiceResult.Fail;

                }
                else
                {
                    serviceResult.Data = _baseRepository.Update(id, entity);
                }
            }
            catch (Exception ex)
            {
                serviceResult.ResultCode = (int)EnumServiceResult.NotValid;
                serviceResult.DevMessage.Add(ex.Message);
            }
            return serviceResult;
        }

        public ServiceResult CheckValidate(T entity)
        {
            ServiceResult serviceResult = new ServiceResult();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                string column = prop.Name;
                object value = prop.GetValue(entity) ?? "";

                if (prop.IsDefined(typeof(Required), false) && !CheckEmpty(value))
                {
                    serviceResult.DevMessage.Add($"{column} không được phép để trống");
                    serviceResult.ResultCode = (int)EnumServiceResult.NotValid;
                }
                if (prop.IsDefined(typeof(Duplication), false) && !CheckDuplicate(column, value))
                {
                    serviceResult.DevMessage.Add($"{column} '{value}' đã tồn tại trên hệ thống.");
                    serviceResult.ResultCode = (int)EnumServiceResult.NotValid;
                }
            }

            return serviceResult;
        }

        public bool CheckEmpty(object value)
        {
            if (string.IsNullOrEmpty((string)value) || string.IsNullOrWhiteSpace((string)value))
                return false;
            return true;
        }

        public bool CheckDuplicate(string column, object value)
        {
            if (string.IsNullOrEmpty((string)value) || string.IsNullOrWhiteSpace((string)value))
                return true;
            var isDuplicate = _baseRepository.GetByProperty(column, value);
            if (isDuplicate != null)
                return false;
            return true;
        }
    }
}

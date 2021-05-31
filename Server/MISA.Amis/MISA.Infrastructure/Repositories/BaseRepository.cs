using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using MySqlConnector;
using System.Reflection;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        #region Declares
        protected string _tableName;
        private string _connectionString;
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructors  
        public BaseRepository()
        {
            _tableName = typeof(T).Name;
            _connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database =  MF792_NVCUONG_AMIS;" +
                "User Id = dev;" +
                "Password = 12345678";
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        public virtual int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            var sqlCommand = $"Proc_Get{_tableName}s";

            return _dbConnection.Query<T>(sqlCommand, commandType: CommandType.StoredProcedure);
        }

        public T GetById(Guid id)
        {
            string sqlCommand = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", id.ToString());

            return _dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public virtual int Insert(T entity)
        {
            string sqlCommand = $"Proc_Insert{_tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            // Đọc các properties và thêm vào param
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                var value = prop.GetValue(entity) == "" ? null : prop.GetValue(entity);
                dynamicParameters.Add($"@{prop.Name}", value);
            }

            int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public virtual int Update(Guid id, T entity)
        {
            throw new NotImplementedException();
        }

        public T GetByProperty(string column, object value)
        {
            string sqlCommand = $"Proc_Get{_tableName}By{column}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{column}", value);

            return _dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}

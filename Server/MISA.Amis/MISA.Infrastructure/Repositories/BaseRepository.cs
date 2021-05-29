using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using MySqlConnector;

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

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            var sqlCommand = $"Proc_Get{_tableName}s";

            return _dbConnection.Query<T>(sqlCommand, commandType: CommandType.StoredProcedure);
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Guid id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}

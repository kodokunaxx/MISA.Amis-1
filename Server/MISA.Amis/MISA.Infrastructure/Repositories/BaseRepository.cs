using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using MySqlConnector;
using System.Reflection;
using Npgsql;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable
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
            //_connectionString = @"Server=localhost;Port=5432; User Id=postgres; Password=10041998Cc!;Database=mydb";
            _dbConnection = new MySqlConnection(_connectionString);
            //_dbConnection = new NpgsqlConnection(_connectionString);

        }
        #endregion

        public virtual int Delete(Guid id)
        {
            string sqlCommand = $"Proc_Delete{_tableName}ById";
            //string sqlCommand = $"SELECT * FROM Delete{_tableName}ById('{id.ToString()}')";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", id.ToString());

            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicParameters, transaction, commandType: CommandType.StoredProcedure);
                //int rowAffects = _dbConnection.Execute(sqlCommand);
                transaction.Commit();
                return rowAffects;
            }

        }

        public virtual IEnumerable<T> GetAll()
        {
            var sqlCommand = $"Proc_Get{_tableName}s";

            return _dbConnection.Query<T>(sqlCommand, commandType: CommandType.StoredProcedure);
        }

        public T GetById(Guid id)
        {
            string sqlCommand = $"Proc_Get{_tableName}ById";
            //string sqlCommand = $"SELECT * FROM Get{_tableName}ById('{id.ToString()}')";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{_tableName}Id", id.ToString());

            return _dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            //return _dbConnection.QueryFirstOrDefault<T>(sqlCommand);
        }

        public virtual int Insert(T entity)
        {
            string sqlCommand = $"Proc_Insert{_tableName}";
            //string sqlCommand = $"InsertVendor(";
            DynamicParameters dynamicParameters = new DynamicParameters();

            // Đọc các properties và thêm vào param
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                var value = prop.GetValue(entity) == "" ? null : prop.GetValue(entity);
                dynamicParameters.Add($"@{prop.Name}", value);
            }

            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicParameters, transaction, commandType: CommandType.StoredProcedure);
                //int rowAffects = -_dbConnection.Execute(sqlCommand);
                transaction.Commit();
                return rowAffects;
            }
        }

        public virtual int Update(Guid id, T entity)
        {
            string sqlCommand = $"Proc_Update{_tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                dynamicParameters.Add($"@{prop.Name}", prop.GetValue(entity));
            }
            dynamicParameters.Add($"@{_tableName}Id", id.ToString());

            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicParameters, transaction, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                return rowAffects;
            }
        }

        public T GetByProperty(string column, object value)
        {
            string sqlCommand = $"Proc_Get{_tableName}By{column}";
            //string sqlCommand = $"SELECT * FROM Get{_tableName}By{column}('{value}')";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{column}", value);

            return _dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            //return _dbConnection.QueryFirstOrDefault<T>(sqlCommand);
        }

        /// <summary>
        /// Đóng connection
        /// </summary>
        ///  CreatedBy: nvcuong (31/05/2021)
        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
        }
    }
}

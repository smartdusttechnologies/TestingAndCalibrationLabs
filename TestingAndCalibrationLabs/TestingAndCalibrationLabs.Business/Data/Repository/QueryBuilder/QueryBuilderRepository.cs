using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.QueryBuilder
{
    public class QueryBuilderRepository : IQueryBuilderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public QueryBuilderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// This method will Return the List of TableName
        /// </summary>
        /// <returns></returns>
        public List<QueryBuilderModel> GetTableName()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<QueryBuilderModel>("SELECT name as tableName FROM Sys.Tables").ToList();
        }

        /// <summary>
        /// This method will return the columnName of a table 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<QueryBuilderColNames> GetColoumsNames(string tableName) {

            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"SELECT COLUMN_NAME as coloumnName FROM INFORMATION_SCHEMA.COLUMNS 
                              WHERE TABLE_NAME =@tableName ORDER BY ORDINAL_POSITION";
            return db.Query<QueryBuilderColNames>(query, new { tableName }).ToList();
        }

        /// <summary>
        /// This method will save the Json To DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int QuerySaver(JsonSaveModel model)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"INSERT INTO DashboardJSON (Name,JSON,IsDeleted) VALUES (@Template,@JSON,0)";
             db.Execute(query, model);
            return 1;
        }
    }
}

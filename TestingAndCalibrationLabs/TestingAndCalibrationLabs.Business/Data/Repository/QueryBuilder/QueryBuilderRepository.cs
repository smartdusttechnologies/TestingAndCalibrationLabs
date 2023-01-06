using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        public List<QueryBuilderModel> GetTableName()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<QueryBuilderModel>("SELECT name as tableName FROM Sys.Tables").ToList();
        }

        public List<QueryBuilderColNames> GetColoumsNames(string tableName) {

            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"SELECT COLUMN_NAME as coloumnName FROM INFORMATION_SCHEMA.COLUMNS 
                              WHERE TABLE_NAME =@tableName ORDER BY ORDINAL_POSITION";
            return db.Query<QueryBuilderColNames>(query, new { tableName }).ToList();
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly List<string> _columnName;
        #region Public Methods
        public GenericRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _tableName = GenericUtils.GetDbTableName<T>();
            _columnName = GenericUtils.GetDbColumnName<T>();
        }

        public bool Delete(int id)
        {
            string query = string.Format("update [{0}] Set IsDeleted = @IsDeleted Where Id = @Id and  Id=@id", _tableName);
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { IsDeleted = true, Id = id });
            return true;
        }

        public List<T> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<T>(string.Format("Select * From [{0}] where IsDeleted=0", _tableName)).ToList();
        }

        public List<T> Get<FType>(string columnName, FType value)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = string.Format("Select * From [{0}] where {1} = {2} and IsDeleted=0", _tableName, columnName, value);
            return db.Query<T>(query).ToList();
        }

        public T Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<T>(string.Format("Select top 1 * From [{0}] where Id=@id and IsDeleted=0", _tableName), new { id }).FirstOrDefault();
        }

        public T Get(string name)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<T>(string.Format("Select top 1 * From [{0}] where Name=@name and IsDeleted=0", _tableName), new { name }).FirstOrDefault();
        }

        public int Insert(T model)
        {
            var query = GenerateInsertQuery();
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, model);
        }

        /// <summary>
        /// Inserting data to list
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public int InsertCollection(List<T> model)
        {
            var query = GenerateInsertQuery();
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, model);
        }

        public int Update(T model)
        {
            var query = GenerateUpdateQuery();
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, model);
        }
        #endregion

        #region Private Methods
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            //var properties = GenerateListOfProperties(typeof(T).GetProperties());
            _columnName.ForEach(colName => { insertQuery.Append($"{colName},"); });
            //properties.ForEach(prop => { if (prop.ToLower() != "id") { insertQuery.Append($"[{prop}],"); } });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");
            _columnName.ForEach(colName => {  insertQuery.Append($"@{colName},");  });
           // properties.ForEach(prop => { if (prop.ToLower() != "id") { insertQuery.Append($"@{prop},"); } });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            //var properties = GenerateListOfProperties(typeof(T).GetProperties());

            _columnName.ForEach(property =>
            {
                    updateQuery.Append($"{property}=@{property},");
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
        #endregion
    }
}

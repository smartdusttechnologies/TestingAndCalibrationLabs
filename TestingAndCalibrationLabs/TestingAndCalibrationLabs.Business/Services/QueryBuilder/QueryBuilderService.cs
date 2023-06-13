using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;

namespace TestingAndCalibrationLabs.Business.Services.QueryBuilder
{
    public class QueryBuilderService : IQueryBuilderService
    {

        private readonly IQueryBuilderRepository _querybuilderRepository;
        private readonly ILogger _logger;
        public QueryBuilderService(IQueryBuilderRepository querybuilderRepository, ILogger logger)
        {
            _querybuilderRepository = querybuilderRepository;
            _logger = logger;
        }

        public List<QueryBuilderModel> GetTableNames()
        {
            return _querybuilderRepository.GetTableName();
        }

        public QueryRecordModel GetColoumsNames(List<QueryBuilderModel> tableNames)
        {
            Dictionary<QueryBuilderModel, List<QueryBuilderColNames>> queryBuilderData = new Dictionary<QueryBuilderModel, List<QueryBuilderColNames>>();
            foreach (QueryBuilderModel table in tableNames)
            {
                queryBuilderData.Add(table, _querybuilderRepository.GetColoumsNames(table.tableName));
            }
            return new QueryRecordModel { FieldValues = queryBuilderData };
        }
        public int  UiToJsonQueryBuilder(List<UiQueryGenerator> person)
        {
            var QueryJson = "{ 'head': {  'tables': [      {       'type': 'select' ,   'tableName': " + '"' + person[0].TableName + '"' + ",    'column': [";

            var column = "";

            foreach (var row in person)
            {
                for (var item2 = 0; item2 < row.ColumnName.Count; item2++)
                {
                    column = column + "{'columnName': " + '"' + row.ColumnName[item2].Name + '"' + ", 'As': " + '"' + row.ColumnName[item2].Title + '"' + "},";

                }
            }
            column = column.Remove(column.Length - 1, 1); ;
            column = column + "]";
            var QueryJsonEnd = " } ] } }";
            QueryJson = QueryJson + column + QueryJsonEnd;



            //var jsonString = JSON.stringify(datainfo);
            //////  const listOfArrays = datainfo.map(obj => [...obj.values]);
            ////  
            var data = SqlConverter.JsonToSql(QueryJson);
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
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
    }
}

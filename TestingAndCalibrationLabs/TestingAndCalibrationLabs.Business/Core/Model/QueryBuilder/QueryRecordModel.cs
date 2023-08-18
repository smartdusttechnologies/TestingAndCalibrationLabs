using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public class QueryRecordModel :Entity
    {
        /// <summary>
        /// it will store the Table and its column in the form of key value pair format
        /// </summary>
        public Dictionary<QueryBuilderModel, List<Core.Model.QueryBuilder.QueryBuilderColNames>> FieldValues { get; set; }
    }
}

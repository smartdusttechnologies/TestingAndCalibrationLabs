using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public class QueryRecordModel :Entity
    {
        public Dictionary<QueryBuilderModel, List<Core.Model.QueryBuilder.QueryBuilderColNames>> FieldValues { get; set; }
    }
}

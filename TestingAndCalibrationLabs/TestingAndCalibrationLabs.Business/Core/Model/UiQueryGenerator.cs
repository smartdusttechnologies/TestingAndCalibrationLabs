using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UiQueryGenerator
    {
        public string TableName { get; set; }
        public List<UiQueryBuilder> ColumnName { get; set; }
    }
}

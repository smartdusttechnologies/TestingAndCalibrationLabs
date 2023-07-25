using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public  class ConditionModel
    {
        public string value { get; set; }
        public string Where { get; set; }
        public string operators { get; set; }
        public string TableName { get; set; }
        public string OperatorType { get; set; }
    }
}

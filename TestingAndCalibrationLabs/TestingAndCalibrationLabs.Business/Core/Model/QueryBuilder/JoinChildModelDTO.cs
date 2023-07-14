using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public class JoinChildModelDTO
    {
        public string Columns { get; set; }
        public string Operator { get; set; }
        public string Column2 { get; set; }
        public string Condition { get; set; }
    }
}

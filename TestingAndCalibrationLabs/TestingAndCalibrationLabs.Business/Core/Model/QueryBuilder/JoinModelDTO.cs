using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public class JoinModelDTO
    {
        public string JoinType { get; set; }
        public string TableChoice { get; set; }
        public string TableFrom { get; set; }
        public List<JoinChildModelDTO> JoinInfo { get; set; }
    }
}

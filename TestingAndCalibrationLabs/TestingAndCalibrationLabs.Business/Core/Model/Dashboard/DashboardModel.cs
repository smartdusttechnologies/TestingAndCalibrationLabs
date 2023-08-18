using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.Dashboard
{
    public  class DashboardModel
    {
        /// <summary>
        /// It is a key and list of ValuePair For Dashboard Template
        /// </summary>
        public Dictionary<string, List<object>> Dictionary { get; set; }
    }
}

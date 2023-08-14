using System.Collections.Generic;
using System;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class SalesModel
    {

        // Sales Graph
        public List<object> Month { get; set; }
        //public List<int> salesData1 { get; set; }
        //public List<int> SalesData2 { get; set; }

        public List<SalesComponentDataModel> salesData { get; set; }

        //donut graph

        public List<string> SalesName { get; set; }
        public List<int> DataSet { get; set; }


    }
}

using System.Collections.Generic;
using System;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class SalesModel
    {
       
            // Sales Graph
            public List<String> Month { get; set; }
            public List<int> salesData1 { get; set; }
            public List<int> SalesData2 { get; set; }

            //donut graph

            public List<String> SalesName { get; set; }
            public List<int> DataSet { get; set; }
       
    }
}

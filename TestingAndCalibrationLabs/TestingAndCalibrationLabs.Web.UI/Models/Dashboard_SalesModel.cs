using System.Collections.Generic;
using System;

namespace TestingAndCalibrationLabs.Web.UI.Models
{/// <summary>
/// salesModel will store the data of SalesGraph data and Donut graph template
/// </summary>
    public class SalesModel
    {
       
            // Sales Graph
            public List<String> Month { get; set; }
            public List<int> SalesData1 { get; set; }
            public List<int> SalesData2 { get; set; }

            //donut graph

            public List<String> SalesName { get; set; }
            public List<int> DataSet { get; set; }
       
    }
}

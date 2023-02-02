using System.Collections.Generic;
using System;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class SalesModel
    {

        // Sales Graph
       
        public string  Label { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string pointColor { get; set; }
        public string pointStrokeColor { get; set; }
        public string pointHighlightStroke { get; set; }

        public string pointRadius { get; set; }

        public List<int> data { get; set; }
       

     
    }
}

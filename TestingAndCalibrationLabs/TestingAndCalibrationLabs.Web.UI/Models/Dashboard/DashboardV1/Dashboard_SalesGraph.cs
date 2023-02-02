
using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    /// <summary>
    /// This Class consist the properties of the line Graph 
    /// </summary>
    public class Dashboard_SalesGraph
    {
        
        public List<int> data { get; set; }

        public string Label { get; set; }
        public string fill { get; set; }
        public int borderWidth { get; set; }
        public int lineTension { get; set; }
        public string spanGaps { get; set; }
        public string borderColor { get; set; }
        public int pointRadius { get; set; }
        public int pointHoverRadius { get; set; }
        public string pointBackgroundColor { get; set; }

        public string pointColor { get; set; }


       
                          
                           

    }
}

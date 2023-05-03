using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class LineGraph
    {
        public List<string> QuarterData { get; set; }
        public List<Dashboard_SalesGraph> LineGraphData { get; set; }
        public int Gapdata { get; set; }
    }
}

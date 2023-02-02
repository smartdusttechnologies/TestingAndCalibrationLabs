using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class AreaGraph
    {
        public List<string> Month { get; set; }
        public List<SalesModel> AreaData { get; set; }
      public List<DonutGraph> DonutData { get; set; }

    }
}

using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It consist The property for the Cartogram Graph
    /// </summary>
    public class UsVisitor
    {
        public List<int> vistorslist { get; set; }
        public List<int> ReferalNo { get; set; }
        public List<int> organiclist { get; set; }

        public int VisitorsAvg { get;set;}
        public string ReferalPercent { get; set; }
        public string OrganicPercentage { get; set; }
    }
}

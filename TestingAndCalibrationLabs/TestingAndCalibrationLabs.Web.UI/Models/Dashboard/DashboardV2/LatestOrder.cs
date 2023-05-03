using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It Consist the Latest Order Property
    /// </summary>
    public class LatestOrder
    {
        public List<string> Orderid { get; set; }
        public List<string> item { get; set; }
        public List<string> Status { get; set; }
        public List<string> Popularity { get; set; }

        public List<string> BadgeName { get; set; }
    }
}

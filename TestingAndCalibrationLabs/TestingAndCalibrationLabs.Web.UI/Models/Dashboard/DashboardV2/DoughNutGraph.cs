using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class DoughNutGraph
    {
        public List<string> BrowserName { get; set; }
        public List<string> DounutAlertType { get; set; }
        public List<BrowserUsage> DounutData { get; set; }
    }
}

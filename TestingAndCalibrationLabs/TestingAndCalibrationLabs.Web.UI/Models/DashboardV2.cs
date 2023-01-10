using Microsoft.AspNetCore.Builder;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class DashboardV2
    {
        public DashboardV2Box Box { get; set; }
        public RecapModel RecapModel { get; set; }
        public UsVisitor map { get; set; }
        public BrowserUsage Usage { get; set; }
        public LatestOrder Order { get; set; }
        public RecentProduct Detail { get; set; }
    }
}

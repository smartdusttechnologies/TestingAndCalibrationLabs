using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It consist the property for New Members Data
    /// </summary>
    public class LatestMember
    {
        public List<string> ImageLink { get; set; }
        public List<string> Name { get; set; }
        public List<string> Date { get; set; }
    }
}

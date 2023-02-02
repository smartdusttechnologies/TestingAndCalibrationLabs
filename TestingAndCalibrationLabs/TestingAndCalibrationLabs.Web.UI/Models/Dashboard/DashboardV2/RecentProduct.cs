using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It consist the Property for the Recent Product details 
    /// </summary>
    public class RecentProduct
    {
        public List<string> price { get; set; }
        public List<string> Name { get; set; }
        public List<string> ProductDetails { get; set; }
        public List<string> ProductImg { get; set; }

    }
}

using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class UsVisitor
    {
        /// <summary>
        /// To store the Visitor List
        /// </summary>
        public List<int> Vistorslist { get; set; }
        /// <summary>
        /// To store the Numbers of Referaal
        /// </summary>
        public List<int> ReferalNo { get; set; }
        /// <summary>
        /// To store the organic Value
        /// </summary>
        public List<int> Organiclist { get; set; }
        /// <summary>
        /// To store the Visitor average Who visited
        /// </summary>

        public int VisitorsAvg { get;set;}
        /// <summary>
        /// To store the percentage of referral
        /// </summary>
        public string ReferalPercent { get; set; }
        /// <summary>
        /// To store the Organic Percent
        /// </summary>
        public string OrganicPercentage { get; set; }
    }
}

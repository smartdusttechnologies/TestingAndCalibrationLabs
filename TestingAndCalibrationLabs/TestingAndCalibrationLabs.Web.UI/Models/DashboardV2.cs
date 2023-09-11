
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class DashboardV2
    {
        /// <summary>
        /// To store Value for Small Box Template
        /// </summary>
        public DashboardV2Box Box { get; set; }
        /// <summary>
        /// To store the Data for RecapGraph Template
        /// </summary>
        public RecapModel RecapModel { get; set; }
        /// <summary>
        /// To Store info for Map
        /// </summary>
        public UsVisitor Map { get; set; }
        /// <summary>
        /// To store the Data for BrowserUsage Template
        /// </summary>
        public BrowserUsage Usage { get; set; }
        /// <summary>
        /// To store the Data for ORDERS Template
        /// </summary>
        public LatestOrder Order { get; set; }
        /// <summary>
        /// To store the Detail for RecentProduct Template
        /// </summary>
        public RecentProduct Detail { get; set; }
        /// <summary>
        /// To store the LatestMember Detail Template
        /// </summary>
        
        public LatestMember Member { get; set; }
        /// <summary>
        /// To store The Data for ChatBox Template
        /// </summary>
        public List<ChatModel> ChatData { get; set; }
    }
}

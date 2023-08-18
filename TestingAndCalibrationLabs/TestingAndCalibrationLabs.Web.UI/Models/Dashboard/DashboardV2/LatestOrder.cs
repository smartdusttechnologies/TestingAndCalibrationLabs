using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class LatestOrder
    {
        /// <summary>
        /// To Store the Order id for the Order
        /// </summary>
        public List<string> Orderid { get; set; }
        /// <summary>
        /// To store the item Detail of LatestOrder Template
        /// </summary>
        public List<string> Item { get; set; }
        /// <summary>
        /// To store the status for the Latest Order
        /// </summary>
        public List<string> Status { get; set; }
        /// <summary>
        /// To store the popularity of the Order
        /// </summary>
        public List<string> Popularity { get; set; }
        /// <summary>
        /// To store the BadgeName of the order
        /// </summary>
        public List<string> BadgeName { get; set; }
    }
}

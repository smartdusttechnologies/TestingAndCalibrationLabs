using System;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class DashboardV2Box
    {
        /// <summary>
        /// For V2 box info
        /// </summary>
        public int Traffic { get; set; }
        public int Likes { get; set; }
        public int Sales { get; set; }
        public int NewMember { get; set; }

        /// <summary>
        /// For Box info
        /// </summary>
        public int Inventory { get; set; }
        public int mention { get; set; }
        public int Downloads { get; set; }
        public int Messages { get; set; }
    }
}

using System;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class DashboardV2Box
    {
        /// <summary>
        /// For V2 box Traffic info
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        ///To store the V2Box Likes
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        ///To store the Sales detail
        /// </summary>
        public int Sales { get; set; }
        /// <summary>
        ///To store the NewMember detail
        /// </summary>
        public int NewMember { get; set; }

        

        /// <summary>
        /// To store the Inventory Detail
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// To store the Mention Detail
        /// </summary>
        public int Mention { get; set; }
        /// <summary>
        /// To store the detail of Downloads
        /// </summary>
        public int Downloads { get; set; }
        /// <summary>
        /// To store the detail of Message
        /// </summary>
        public int Messages { get; set; }
    }
}

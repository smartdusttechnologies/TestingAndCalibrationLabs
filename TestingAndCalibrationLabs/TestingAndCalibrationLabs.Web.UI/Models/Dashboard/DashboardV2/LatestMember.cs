using System.Collections.Generic;
using System.Security.Cryptography;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class LatestMember
    {
        /// <summary>
        /// To store the List of Image
        /// </summary>
        public List<string> ImageLink { get; set; }
        /// <summary>
        /// To store list of Name
        /// </summary>
        public List<string> Name { get; set; }
        /// <summary>
        /// To store date for Member Join
        /// </summary>
        public List<string> Date { get; set; }
    }
}

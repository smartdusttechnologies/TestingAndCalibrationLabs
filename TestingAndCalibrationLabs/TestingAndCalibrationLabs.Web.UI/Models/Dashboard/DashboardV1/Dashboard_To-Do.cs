using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class Dashboard_To_Do
    {
        /// <summary>
        /// To store the Todo detail
        /// </summary>
        public List<string> ToDo { get; set; }
        /// <summary>
        /// To store the Time of  Todo 
        /// </summary>
        public List<string> Time { get; set; }
        /// <summary>
        /// To save the status of todo
        /// </summary>
        public List<string> Status { get; set; }
    }
}

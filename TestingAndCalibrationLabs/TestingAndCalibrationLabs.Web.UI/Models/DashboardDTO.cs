using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class DashboardDTO
    {   /// <summary>
        /// It is a key and value   list   of all table data 
        /// </summary>
        public Dictionary<string, List<object>> Dictionary { get; set; }
        
    }
}
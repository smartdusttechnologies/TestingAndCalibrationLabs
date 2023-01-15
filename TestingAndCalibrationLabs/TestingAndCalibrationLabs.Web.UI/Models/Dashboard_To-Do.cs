using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// This class will store the Todo List and its timing
    /// </summary>
    public class Dashboard_To_Do
    {
        public List<string> ToDo { get; set; }
        public List<string> Time { get; set; }

        public List<string> Status{get;set; }
    }
}

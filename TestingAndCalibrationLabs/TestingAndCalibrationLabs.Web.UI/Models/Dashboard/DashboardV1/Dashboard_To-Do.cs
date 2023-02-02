﻿using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    /// <summary>
    /// It consist the properties Todo List Data
    /// </summary>
    public class Dashboard_To_Do
    {
        public List<string> ToDo { get; set; }
        public List<string> Time { get; set; }
        public List<string> Status { get; set; }
    }
}

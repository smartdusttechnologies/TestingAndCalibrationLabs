﻿using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    /// <summary>
    /// It consist the Property for the DonutChart
    /// </summary>
    public class DonutGraph
    {
        public List<string> SalesName { get; set; }
        public List<int> DataSet { get; set; }
        public List<string> Background { get; set; }
    }
}

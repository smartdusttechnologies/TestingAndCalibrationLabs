using System;
using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// SalesGraph Model store the data which will show on salesGraph tiles
    /// </summary>
    public class Dashboard_SalesGraph
    {
        public List<string> QuarterData { get; set; }
        public List<int> Data  { get; set; }

    }
}

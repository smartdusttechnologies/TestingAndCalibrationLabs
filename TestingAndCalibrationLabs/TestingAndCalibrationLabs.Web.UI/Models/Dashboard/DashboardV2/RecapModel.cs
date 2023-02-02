using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It consist the property for the Area Chart
    /// </summary>
    public class RecapModel
    {
        public string Label { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string pointColor { get; set; }
        public string pointStrokeColor { get; set; }
        public string pointHighlightStroke { get; set; }

        public string pointRadius { get; set; }

        public List<int> data { get; set; }
    }
}

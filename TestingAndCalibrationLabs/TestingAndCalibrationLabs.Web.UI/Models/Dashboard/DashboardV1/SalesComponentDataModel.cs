using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class SalesComponentDataModel
    {

        public string label { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string pointRadius { get; set; }

        public string pointColor { get; set; }
        public string pointStrokeColor { get; set ; }
        public string pointHighlightFill { get; set; }
        public string pointHighlightStroke { get; set; }
        public List<object> Data { get; set; }
    
    }
}

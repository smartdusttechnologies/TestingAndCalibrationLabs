using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class SalesComponentDataModel
    {
        /// <summary>
        /// To store the Label Value
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// To store the backgroundColour Detail
        /// </summary>
        public string backgroundColor { get; set; }
        /// <summary>
        /// To store the borderColor Detail
        /// </summary>
        public string borderColor { get; set; }
        /// <summary>
        /// To store the pointRadius Detail
        /// </summary>
        public string pointRadius { get; set; }

        /// <summary>
        /// To store the pointColor Detail
        /// </summary>
        public string pointColor { get; set; }
        /// <summary>
        /// To store the pointStrokeColor Detail
        /// </summary>
        public string pointStrokeColor { get; set ; }
        /// <summary>
        /// To store the pointHighlightFill Detail
        /// </summary>
        public string pointHighlightFill { get; set; }
        /// <summary>
        /// To store the pointHighlightStroke Detail
        /// </summary>
        public string pointHighlightStroke { get; set; }
        /// <summary>
        /// To store the Data to show On Template
        /// </summary>
        public List<object> Data { get; set; }
    
    }
}

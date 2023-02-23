using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Common
{
    public class GridDTO
    {
        /// <summary>
        /// It Contains The List of Grid Columns
        /// </summary>
        public List<string> Columns { get; set; }
        /// <summary>
        /// It Contains The List of row Values
        /// </summary>
        public List<GridRow> Values { get; set; }
        
    }
}

using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class JoinModel
    {
        /// <summary>
        /// To store JOIN type value For QueryBuilder
        /// </summary>
        public string JoinType { get; set; }
        /// <summary>
        /// To store TableChoice value For QueryBuilder
        /// </summary>
        public string TableChoice { get; set; }
        /// <summary>
        /// To store TableFrom value For QueryBuilder
        /// </summary>
        public string TableFrom { get; set; }
        /// <summary>
        /// To store JoinInfo  value For QueryBuilder
        /// </summary>
        public List<JoinChildModel> JoinInfo { get; set; }

    }
}

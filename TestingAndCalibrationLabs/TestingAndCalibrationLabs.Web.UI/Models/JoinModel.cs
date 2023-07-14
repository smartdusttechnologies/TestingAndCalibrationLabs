using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class JoinModel
    {
        public string JoinType { get; set; }
        public string TableChoice { get; set; }
        public string TableFrom { get; set; }
        public List<JoinChildModel> JoinInfo { get; set; }

    }
}

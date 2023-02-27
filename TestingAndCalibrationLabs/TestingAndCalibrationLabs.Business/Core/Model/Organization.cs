using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{   /// <summary>
    /// It Conatains The Properties for Organization
    /// </summary>
    ///
    [DbTable("Organization")]
    public class Organization : Entity
    {    /// <summary>
         /// It Contains The Name of  OrgCode
         /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// It Contains The Name of OrgName
        /// </summary>
        public string OrgName { get; set; }
    }
}

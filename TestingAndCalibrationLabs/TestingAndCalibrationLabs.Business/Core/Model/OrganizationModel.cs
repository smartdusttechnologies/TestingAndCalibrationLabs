using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Organization
    /// </summary>
    [DbTable("Organization")]
    public class OrganizationModel : Entity
    {
        /// <summary>
        /// It Contains  OrgCode for Organization
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// It Contains OrgName for Organization 
        /// </summary>
        public string OrgName { get; set; }
    }
}

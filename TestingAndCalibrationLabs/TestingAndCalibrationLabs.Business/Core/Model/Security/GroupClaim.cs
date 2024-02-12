using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of GroupClaim
    /// </summary>
    public class GroupClaim : Entity
    {
        /// <summary>
        /// It Contains CustomClaimType
        /// </summary>
        public CustomClaimType ClaimType { get; set; }
        /// <summary>
        /// It Contains ClaimValue
        /// </summary>
        public string ClaimValue { get; set; }
    }
}


using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of UserClaim
    /// </summary>
    public class UserClaim : Entity
    {
        /// <summary>
        /// It Contains Custom Claim Type
        /// </summary>
        public CustomClaimType ClaimType { get; set; }
        /// <summary>
        /// It Contains Claim Value
        /// </summary>
        public string ClaimValue { get; set; }
    }
}

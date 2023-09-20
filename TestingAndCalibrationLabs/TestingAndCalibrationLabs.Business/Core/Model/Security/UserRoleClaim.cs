using TestingAndCalibrationLabs.Business.Common;
namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Class to get the user role with claims.
    /// </summary>
    public class UserRoleClaim : Entity
    {
        public CustomClaimType ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}

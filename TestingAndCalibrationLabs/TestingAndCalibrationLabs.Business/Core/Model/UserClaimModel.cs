using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UserClaim")]
    public class UserClaimModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of UserClaim
        /// </summary>/// 
        public int Id { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains UserId of the UserClaim.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// It Contains UserName of the UserClaim.
        /// </summary>
        public string UserName { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains PermissionId of the UserClaim.
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// It Contains PermissionName of the UserClaim.
        /// </summary>
        public string PermissionName { get; set; }
        [DbColumn]
        /// <summary>
        ///It Contains ClaimTypeId of the UserClaim.
        /// </summary>
        public int ClaimTypeId { get; set; }
        /// <summary>
        /// It Contains ClaimTypeName of the UserClaim.
        /// </summary>
        public string ClaimTypeName { get; set; }
    }
}

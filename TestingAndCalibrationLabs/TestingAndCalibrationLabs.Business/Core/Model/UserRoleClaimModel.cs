using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UserRoleClaim")]
    public class UserRoleClaimModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of UserRoleClaim
        /// </summary>/// 
        public int Id { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains RoleId of the UserRoleClaim.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// It Contains RoleName of the UserRoleClaim.
        /// </summary>
        public string RoleName { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains PermissionId of the UserRoleClaim.
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// It Contains PermissionName of the UserRoleClaim.
        /// </summary>
        public string PermissionName { get; set; }
        [DbColumn]
        /// <summary>
        ///It Contains ClaimTypeId of the UserRoleClaim.
        /// </summary>
        public int ClaimTypeId { get; set; }
        /// <summary>
        /// It Contains ClaimTypeName of the UserRoleClaim.
        /// </summary>
        public string ClaimTypeName { get; set; }
    }
}

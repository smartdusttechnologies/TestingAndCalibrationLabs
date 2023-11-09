using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("RoleClaim")]
    public class RoleClaimModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of RoleClaim
        /// </summary>/// 
        public int Id { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains RoleId of the RoleClaim.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// It Contains RoleName of the RoleClaim.
        /// </summary>
        public string RoleName { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains PermissionId of the RoleClaim.
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// It Contains PermissionName of the RoleClaim.
        /// </summary>
        public string PermissionName { get; set; }
        [DbColumn]
        /// <summary>
        ///It Contains ClaimTypeId of the RoleClaim.
        /// </summary>
        public int ClaimTypeId { get; set; }
        /// <summary>
        /// It Contains ClaimTypeName of the RoleClaim.
        /// </summary>
        public string ClaimTypeName { get; set; }
    }
}

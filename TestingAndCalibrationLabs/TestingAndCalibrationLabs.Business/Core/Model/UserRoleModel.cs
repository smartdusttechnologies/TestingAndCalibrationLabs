using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UserRole")]
    /// <summary>
    /// User Role.
    /// </summary>
    public class UserRoleModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of UserRole
        /// </summary>/// 
        public int Id { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains UserId of User Role
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// It Contains User Name of the UserRole.
        /// </summary>
        public string UserName { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains RoleId of the User Role.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// It Contains RoleName of the User Role.
        /// </summary>
        public string RoleName { get; set; }
    }
}

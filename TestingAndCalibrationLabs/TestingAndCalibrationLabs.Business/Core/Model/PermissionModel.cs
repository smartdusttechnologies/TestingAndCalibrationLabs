using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Permission")]
    /// <summary>
    /// Permission.
    /// </summary>
    public class PermissionModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of Permission
        /// </summary>/// 
        public int Id { get; set; }
        /// <summary>
        /// It Contains the name of the Permission.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        ///It Contains PermissionModuleTypeId of the Permission.
        /// </summary>
        public int PermissionModuleTypeId { get; set; }
        /// <summary>
        /// It Contains PermissionModuleTypeName of the Permission.
        /// </summary>
        public string PermissionModuleTypeName { get; set; }
        /// <summary>
        ///It Contains PermissionTypeId of the Permission.
        /// </summary>
        public int PermissionTypeId { get; set; }
        /// <summary>
        /// It Contains PermissionTypeName of the Permission.
        /// </summary>
        public string PermissionTypeName { get; set; }

    }
}

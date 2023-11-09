using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("SubPermissionModuleType")]
    /// <summary>
    /// SubPermissionModuleTypeModel.
    /// </summary>
    public class SubPermissionModuleTypeModel 
    {
        [DbColumn]
        /// <summary>
        /// It contains id of SubPermissionModuleType
        /// </summary>/// 
        public int Id { get; set; }
        /// <summary>
        /// It Contains the name of the SubPermissionModuleType.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        ///It Contains PermissionModuleTypeId of the SubPermissionModuleType.
        /// </summary>
        public int PermissionModuleTypeId { get; set; }
        /// <summary>
        /// It Contains PermissionModuleTypeName of the SubPermissionModuleType.
        /// </summary>
        public string PermissionModuleTypeName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("PermissionModuleType")]
    /// <summary>
    /// Permission Module Type Model.
    /// </summary>
    public class PermissionModuleTypeModel : Entity
    {
        [DbColumn]

        /// <summary>
        /// It Contains The Id of The Permission Module Type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It Contains The Name of The Permission Module Type
        /// </summary>///

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}

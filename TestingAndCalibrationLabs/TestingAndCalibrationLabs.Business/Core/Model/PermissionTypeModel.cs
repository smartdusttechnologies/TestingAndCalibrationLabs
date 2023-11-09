using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("PermissionType")]
    /// <summary>
    /// Permission Type Model.
    /// </summary>
    public class PermissionTypeModel : Entity
    {
        [DbColumn]

        /// <summary>
        /// It Contains The Id of The Permission Type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It Contains The Name of The Permission Type
        /// </summary>///

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        /// <summary>
        /// It Contains The value of The Permission Type
        /// </summary>

        [DbColumn]

        [Required(ErrorMessage = "Please Enter your Value")]
        public string Value { get; set; }

    }
}
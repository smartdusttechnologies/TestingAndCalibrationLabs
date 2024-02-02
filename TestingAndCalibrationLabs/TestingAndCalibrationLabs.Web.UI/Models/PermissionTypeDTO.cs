using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class PermissionTypeDTO
    {
        /// <summary>
        /// It Contains The Id of The Permission Type.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Permission Type.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Value of The Permission Type.
        /// </summary>  
        [Required(ErrorMessage = "Please Enter your Value")]
        public string Value { get; set; }
    }
}
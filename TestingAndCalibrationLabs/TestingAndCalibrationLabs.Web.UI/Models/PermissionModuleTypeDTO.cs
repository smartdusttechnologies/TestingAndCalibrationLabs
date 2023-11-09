using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class PermissionModuleTypeDTO
    {
        /// <summary>
        /// It Contains The Id of The Permission Module Type.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Permission Module Type.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}

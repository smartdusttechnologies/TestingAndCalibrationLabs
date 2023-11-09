using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class RoleDTO
    {
        /// <summary>
        /// It Contains The Id of The Role.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Role.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Level of The Role.
        /// </summary>  
        [Required(ErrorMessage = "Please Enter your Level")]
        public string Level { get; set; }
    }
}

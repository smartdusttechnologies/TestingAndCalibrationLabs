using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Application
    /// </summary>
    public class ApplicationDTO
    {
        /// <summary>
        /// It Contains The Id of Application
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of Application
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        /// <summary>
        /// It Contains The Description of Application
        /// </summary>
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{    /// <summary>
     /// It Conatains The Properties for Module
     /// </summary>
    public class ModuleDTO
    {   /// <summary>
        /// It Contains The Id of Module
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of Module
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Id of Application
        /// </summary>
        [Required(ErrorMessage = "Please choose Application Name")]
        public int ApplicationId { get; set; }
        /// <summary>
        /// It Contains The Name of Application
        /// </summary>
        public string ApplicationName { get; set; }
    }
}

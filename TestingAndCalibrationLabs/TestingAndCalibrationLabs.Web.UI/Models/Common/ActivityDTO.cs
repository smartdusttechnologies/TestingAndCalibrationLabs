using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for  Activity
    /// </summary>
    public class ActivityDTO
    {
        /// <summary>
        /// It Contains The Id of  Activity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of  Activity
        /// </summary>
        [Required(ErrorMessage = "Please Enter  Name")]
        public string Name { get; set; }
    }
}

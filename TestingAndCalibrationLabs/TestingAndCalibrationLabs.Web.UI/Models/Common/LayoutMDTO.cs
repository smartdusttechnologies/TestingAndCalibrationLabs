using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of Layout
    /// </summary>
    public class LayoutMDTO
    {
        /// <summary>
        /// It Contains Id For Layout
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains Name For Layout
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}

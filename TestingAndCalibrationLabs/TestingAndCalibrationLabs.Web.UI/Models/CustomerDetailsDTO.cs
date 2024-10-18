using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of Layout
    /// </summary>
    public class CustomerDetailsDTO
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

        [Required(ErrorMessage = "Please Enter your Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter your Mobile")]
        public string Mobile { get; set; }
    }
}


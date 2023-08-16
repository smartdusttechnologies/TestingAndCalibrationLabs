
using System.ComponentModel.DataAnnotations;


namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ChangePasswordDTO
    {
        /// <summary>
        /// It Contains Old Password
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// It Contains New Password 
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// It Contains Confirm Password 
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// It Contains The Use Id to existing User 
        /// </summary>
        public int UserId { get; set; } 
    }
}
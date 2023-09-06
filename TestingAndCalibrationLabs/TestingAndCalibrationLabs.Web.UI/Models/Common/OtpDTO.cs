using System;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class OtpDTO
    {
        /// <summary>
        /// Used For Email
        /// </summary>
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        /// <summary>
        /// It Contain UserId
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// it is used for otp
        /// </summary>
        public string OTP { get; set; }
        /// <summary>
        /// used for get date
        /// </summary>
        public DateTime CreatedDate { get; }
        /// <summary>
        /// used for set date 
        /// </summary>
        public OtpDTO()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
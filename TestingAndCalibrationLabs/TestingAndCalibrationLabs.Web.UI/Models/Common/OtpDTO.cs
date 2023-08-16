using System;
using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class OtpDTO
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        public int UserId { get; set; }
        public string OTP { get; set; }
        public DateTime CreatedDate { get;  }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public OtpDTO()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ForgotPasswordDTO
    {

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        public int Id { get; set; }

        public string OTP { get; set; }

        public DateAndTime CreatedDate { get; set; }

        public int UserId { get; set; }


        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }


        public string EmailTemplate { get; set; }

        public string OTPTemplate { get; set; }

        public string HtmlMsg { get; set; }





    }

}




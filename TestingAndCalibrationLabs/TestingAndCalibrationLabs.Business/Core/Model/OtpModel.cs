using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class OtpModel : Entity
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public string OTP { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EmailValidationStatus { get; set; }
        //public string NewPassword { get; set; }
        //public string ConfirmPassword { get; set; }
        //public string PasswordHash { get; set; }
        //public string PasswordSalt { get; set; }
        //public DateTime ChangeDate { get; set; }
    }
}

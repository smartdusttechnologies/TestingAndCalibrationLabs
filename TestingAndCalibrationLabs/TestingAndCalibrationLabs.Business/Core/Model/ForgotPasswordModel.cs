using Microsoft.VisualBasic;
using System;
using System.Numerics;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class ForgotPasswordModel : Entity
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public string OTP { get; set; }
        public DateTime CreatedDate { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
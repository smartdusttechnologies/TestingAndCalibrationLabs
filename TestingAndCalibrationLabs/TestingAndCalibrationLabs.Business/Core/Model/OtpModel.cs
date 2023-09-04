using System;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class OtpModel : Entity
    {
        public string Email { get; set; }
        public int userId { get; set; }
        public string OTP { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
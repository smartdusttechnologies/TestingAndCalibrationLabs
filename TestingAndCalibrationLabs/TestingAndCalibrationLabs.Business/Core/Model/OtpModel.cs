using System;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("User")]
    public class OtpModel : Entity
    {
        /// <summary>
        /// Used for Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Used For Email.
        /// </summary>
        public string Email { get; set; }
        public bool IsCall { get; set; }
        public string MobileNumber { get; set; }
        /// <summary>
        /// It Contain UserId 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// It Is used For OTP
        /// </summary>
        public string OTP { get; set; }
        /// <summary>
        /// It Is used for created date
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class LoginRequest : Entity
    {
        public string UserName { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public DateTime LoginDate { get; set; }
        public string PasswordHash { get; set; }
        public int Status { get; set; }
    }
}

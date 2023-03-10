using System;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class LoginRequest : Entity
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// IpAddrsss
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// Browser
        /// </summary>
        public string Browser { get; set; }
        /// <summary>
        /// Device Code
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// Device Name
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// Login Date
        /// </summary>
        public DateTime LoginDate { get; set; }
        /// <summary>
        /// PasswordHash
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// Hash
        /// </summary>
        public int Status { get; set; }

       

    }
}

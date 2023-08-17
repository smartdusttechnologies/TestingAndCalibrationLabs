using System;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UserDTO
    {
        /// <summary>
        /// UserName for Registration
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Email for Registration
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password for Registration
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Reenter Password for Registration
        /// </summary>
        [DataType(DataType.Password)]
        public string ReEnterPassword { get; set; }

        /// <summary>
        /// FirstName for Registration
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Mobile Number.
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// IsdCode.
        /// </summary>
        public string ISDCode { get; set; }
        /// <summary>
        /// TwoFactor is enabled or not.
        /// </summary>
        public bool TwoFactor { get; set; }
        /// <summary>
        /// Account locked or not.
        /// </summary>
        public bool Locked { get; set; }
        /// <summary>
        /// Is Active.
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Email Validation Status
        /// </summary>
        public int EmailValidationStatus { get; set; }
        /// <summary>
        /// Mobile Validation Status
        /// </summary>
        public int MobileValidationStatus { get; set; }
        /// <summary>
        /// Organization Id.
        /// </summary>
        public string Organizations { get; set; }

        /// <summary>
        /// Admin Level.
        /// </summary>
        public int AdminLevel { get; set; }

        /// <summary>
        /// Admin Level.
        /// </summary>
       
    }
}

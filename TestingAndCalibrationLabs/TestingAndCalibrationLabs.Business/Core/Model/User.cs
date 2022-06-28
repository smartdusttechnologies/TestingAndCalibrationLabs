using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class User : Entity
    {

        /// <summary>
        /// User Name.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// First Name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email Address.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Mobile.
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
        public int OrgId { get; set; }
        /// <summary>
        /// Admin Level.
        /// </summary>
        public int AdminLevel { get; set; }
    }
}

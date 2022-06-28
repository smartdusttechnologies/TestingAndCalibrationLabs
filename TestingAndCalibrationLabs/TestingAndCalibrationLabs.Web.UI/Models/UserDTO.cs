using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UserDTO
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ReEnterPassword { get; set; }

        public string FirstName { get; set; }
        /// <summary>
        /// Last Name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email Address.
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
        public int OrgnizationId { get; set; }

        /// <summary>
        /// Admin Level.
        /// </summary>
        public int AdminLevel { get; set; }

        
    }
}

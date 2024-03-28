namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ExternalLogin
    {
        /// <summary>
        /// User Name For External Login.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// First Name For External Login.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name For External Login.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email Address For External Login.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Mobile For External Login.
        /// </summary>
        public string? Mobile { get; set; }
        /// <summary>
        /// Country For External Login.
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// IsdCode For External Login.
        /// </summary>
        public string? ISDCode { get; set; }
        /// <summary>
        /// TwoFactor is enabled or not For External Login.
        /// </summary>
        public bool? TwoFactor { get; set; }
        /// <summary>
        /// Account locked or not For External Login.
        /// </summary>
        public bool? Locked { get; set; }
        /// <summary>
        /// Is Active For External Login.
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Email Validation Status For External Login.
        /// </summary>
        public int? EmailValidationStatus { get; set; }
        /// <summary>
        /// Mobile Validation Status For External Login.
        /// </summary>
        public int? MobileValidationStatus { get; set; }
        /// <summary>
        /// Organization Id For External Login.
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// Admin Level For External Login.
        /// </summary>
        public string? Organizations { get; set; }
        /// <summary>
        /// Used at the time of insert in DB For External Login.
        /// </summary>
        public int? AdminLevel { get; set; }
        /// <summary>
        /// For Password For External Login.
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// For ReEnterPassword For External Login.
        /// </summary>
        public string? ReEnterPassword { get; set; }
        /// <summary>
        /// It Contain User Id  For External Login.
        /// </summary>
        public int? userId { get; set; }       
    }
}

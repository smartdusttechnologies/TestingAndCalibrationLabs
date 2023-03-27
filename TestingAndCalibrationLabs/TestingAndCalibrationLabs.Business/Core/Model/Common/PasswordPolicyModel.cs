using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for PasswordPolicy
    /// </summary>
    [DbTable("PasswordPolicy")]
    public class PasswordPolicyModel : Entity
    {
        /// <summary>
        /// It Contains The MinCaps Of The PasswordPolicy
        /// </summary>
        public string MinCaps { get; set; }
        /// <summary>
        /// It Contains The MinSmallChars Of The PasswordPolicy
        /// </summary>
        public string MinSmallChars { get; set; }
        /// <summary>
        /// It Contains The MinSpecialChars Of The PasswordPolicy
        /// </summary>
        public string MinSpecialChars { get; set; }
        /// <summary>
        /// It Contains The MinNumber Of The PasswordPolicy
        /// </summary>
        public string MinNumber { get; set; }
        /// <summary>
        /// It Contains The MinLength Of The PasswordPolicy
        /// </summary>
        public string MinLength { get; set; }
        /// <summary>
        /// It Contains The AllowUserName Of The PasswordPolicy
        /// </summary>
        public string AllowUserName { get; set; }
        /// <summary>
        /// It Contains The DisAllPastPassword Of The PasswordPolicy
        /// </summary>
        public string DisAllPastPassword { get; set; }
        /// <summary>
        /// It Contains The DisAllowedChars Of The PasswordPolicy
        /// </summary>
        public string DisAllowedChars { get; set; }
        /// <summary>
        /// It Contains The ChangeIntervalDays Of The PasswordPolicy
        /// </summary>
        public string ChangeIntervalDays { get; set; }
        /// <summary>
        /// It Contains The OrgId Of The PasswordPolicy
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// It Contains The OrgCode Of The PasswordPolicy
        /// </summary>
        public string OrganizationOrgCode { get; set; }
        /// <summary>
        /// It Contains The OrgName Of The PasswordPolicy
        /// </summary>
        public string OrganizationOrgName { get; set; }

    }
}
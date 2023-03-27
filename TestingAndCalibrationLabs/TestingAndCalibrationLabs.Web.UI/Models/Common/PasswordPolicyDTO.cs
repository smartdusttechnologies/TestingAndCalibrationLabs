using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of PasswordPolicy
    /// </summary>
    public class PasswordPolicyDTO
    {
        /// <summary>
        /// It Contains Id For PasswordPolicy
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains MinCaps For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter MinCaps")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string MinCaps { get; set; }
        /// <summary>
        /// It Contains MinSmallChars For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter MinSmallChars")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string MinSmallChars { get; set; }
        /// <summary>
        /// It Contains MinSpecialChars For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter MinSpecialChars")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string MinSpecialChars { get; set; }
        /// <summary>
        /// It Contains MinNumber For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter MinNumber")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string MinNumber { get; set; }
        /// <summary>
        /// It Contains MinLength For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter MinLength")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string MinLength { get; set; }
        /// <summary>
        /// It Contains AllowUserName For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter AllowUserName")]
        public string AllowUserName { get; set; }
        /// <summary>
        /// It Contains DisAllPastPassword For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter DisAllPastPassword")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string DisAllPastPassword { get; set; }
        /// <summary>
        /// It Contains DisAllowedChars For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter DisAllowedChars")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string DisAllowedChars { get; set; }
        /// <summary>
        /// It Contains ChangeIntervalDays For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please Enter ChangeIntervalDays")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater Than 0 In Orders")]
        public string ChangeIntervalDays { get; set; }
        /// <summary>
        /// It Contains OrgId For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please choose OrganizationOrgName ")]
        public int OrgId { get; set; }
        /// <summary>
        /// It Contains OrgCode For PasswordPolicy
        /// </summary>
        [Required(ErrorMessage = "Please choose  OrganizationOrgCode")]

        public string OrganizationOrgCode { get; set; }
        /// <summary>
        /// It Contains OrgName For PasswordPolicy
        /// </summary>
        public string OrganizationOrgName { get; set; }


    }
}

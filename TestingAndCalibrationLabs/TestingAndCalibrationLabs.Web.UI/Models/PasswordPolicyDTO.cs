using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class PasswordPolicyDTO
    {
        // The ID of the password policy
        public int Id { get; set; }
        // Minimum number of uppercase characters required in the password
        [Required(ErrorMessage = "Please Enter MinCaps")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in MinCpas")]
        public int MinCaps { get; set; }
        // Minimum number of lowercase characters required in the password
        [Required(ErrorMessage = "Please Enter MinSmallChars")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in MinSmallChars")]
        public int MinSmallChars { get; set; }
        // Minimum number of special characters required in the password
        [Required(ErrorMessage = "Please Enter MinSpecialChars")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in MinSpecialChars")]
        public int MinSpecialChars { get; set; }
        // Minimum number of numeric digits required in the password
        [Required(ErrorMessage = "Please Enter MinNumber")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in MinNumber")]
        public int MinNumber { get; set; }
        // Minimum length requirement for the password
        [Required(ErrorMessage = "Please Enter MinLength")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in MinLength")]
        public int MinLength { get; set; }
        // Whether to allow the username to be part of the password
        [Required(ErrorMessage = "Please Enter AllowUserName")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in AllowUserName")]
        public int AllowUserName { get; set; }
        // Number of past passwords to disallow for reuse
        [Required(ErrorMessage = "Please Enter DisAllPastPassword")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in DisAllPastPassword")]
        public int DisAllPastPassword { get; set; }
        // Number of disallowed characters in the password
        [Required(ErrorMessage = "Please Enter DisAllowedChars")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in DisAllowedChars")]
        public int DisAllowedChars { get; set; }
        // Number of days after which the password must be changed
        [Required(ErrorMessage = "Please Enter ChangeIntervalDays")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in ChangeIntervalDays")]
        public int ChangeIntervalDays { get; set; }
        // ID of the organization associated with the password policy
        public int OrgId { get; set; }
        public string OrgName { get; set; }
    }
}
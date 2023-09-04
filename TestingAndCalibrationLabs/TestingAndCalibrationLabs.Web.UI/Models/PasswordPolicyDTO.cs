namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class PasswordPolicyDTO
    {
        // The ID of the password policy
        public int Id { get; set; }
        // Minimum number of uppercase characters required in the password
        public int MinCaps { get; set; }
        // Minimum number of lowercase characters required in the password
        public int MinSmallChars { get; set; }
        // Minimum number of special characters required in the password
        public int MinSpecialChars { get; set; }
        // Minimum number of numeric digits required in the password
        public int MinNumber { get; set; }
        // Minimum length requirement for the password
        public int MinLength { get; set; }
        // Whether to allow the username to be part of the password
        public int AllowUserName { get; set; }
        // Number of past passwords to disallow for reuse
        public int DisAllPastPassword { get; set; }
        // Number of disallowed characters in the password
        public int DisAllowedChars { get; set; }
        // Number of days after which the password must be changed
        public int ChangeIntervalDays { get; set; }
        // ID of the organization associated with the password policy
        public int OrgId { get; set; }
    }
}
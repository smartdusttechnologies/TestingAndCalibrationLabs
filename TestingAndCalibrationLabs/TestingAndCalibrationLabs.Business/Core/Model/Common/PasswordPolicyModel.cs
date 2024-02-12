using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    // This class represents the model for a password policy configuration.
    // It holds various properties that define the rules and settings for passwords.
    [DbTable("PasswordPolicy")]
    public class PasswordPolicyModel
    {
        [DbColumn]
        // The unique identifier for the password policy.
        public int Id { get; set; }
        [DbColumn]
        // The minimum number of uppercase letters required in a password.
        public int MinCaps { get; set; }
        [DbColumn]
        // The minimum number of lowercase letters required in a password.
        public int MinSmallChars { get; set; }
        [DbColumn]
        // The minimum number of special characters required in a password.
        public int MinSpecialChars { get; set; }
        [DbColumn]
        // The minimum number of numeric digits required in a password.
        public int MinNumber { get; set; }
        [DbColumn]
        // The minimum Length of numeric digits required in a password.
        public int MinLength { get; set; }
        [DbColumn]
        // Indicates whether the password is allowed to contain the username.
        public int AllowUserName { get; set; }
        [DbColumn]
        // Indicates whether reusing past passwords is not allowed.
        public int DisAllPastPassword { get; set; }
        [DbColumn]
        // Indicates whether specific disallowed characters are not allowed in passwords.
        public int DisAllowedChars { get; set; }
        [DbColumn]
        // The interval in days after which the password must be changed.
        public int ChangeIntervalDays { get; set; }
        [DbColumn]
        // The organization identifier associated with the password policy.
        public int OrgId { get; set; }

        [DbColumn]
        public string OrgName { get; set; }
    }
}

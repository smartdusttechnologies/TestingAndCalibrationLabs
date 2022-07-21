

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class SecurityParameter : Entity
    {
        public int MinCaps { get; set; }
        public int MinSmallChars { get; set; }
        public int MinSpecialChars { get; set; }
        public int MinNumber { get; set; }
        public int MinLength { get; set; }
        public bool AllowUserName { get; set; }
        public int DisAllPastPassword { get; set; }
        public string DisAllowedChars { get; set; }
        public int ChangeIntervalDays { get; set; }
        public int OrgId { get; set; }
    }
}

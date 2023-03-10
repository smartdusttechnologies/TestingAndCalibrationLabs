using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class ChangePasswordModel : Entity
    {
        
        public string OldPassword { get; set; }

        
        public string NewPassword { get; set; }

       
        public string ConfirmPassword { get; set; }

      // public string User { get; set; }

        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}

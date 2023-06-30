
using System.ComponentModel.DataAnnotations;


namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ChangePasswordDTO
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}

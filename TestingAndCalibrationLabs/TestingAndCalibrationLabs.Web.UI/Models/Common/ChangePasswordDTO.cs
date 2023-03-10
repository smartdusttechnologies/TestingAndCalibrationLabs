
using System.ComponentModel.DataAnnotations;


namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ChangePasswordDTO
    {
       // [Required ,DataType(DataType.Password)]
        public string OldPassword { get; set; }

       // [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        //[Required, DataType(DataType.Password)]
       // [Compare("NewPassword",ErrorMessage ="Confirm new pssword doest not match")]
        public string ConfirmPassword { get; set; }

       
    }
}

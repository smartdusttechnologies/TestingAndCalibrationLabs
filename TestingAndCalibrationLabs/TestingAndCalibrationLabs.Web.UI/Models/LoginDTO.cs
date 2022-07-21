using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class LoginDTO
    {
        /// <summary>
        /// UserName for Login
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password For Login
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

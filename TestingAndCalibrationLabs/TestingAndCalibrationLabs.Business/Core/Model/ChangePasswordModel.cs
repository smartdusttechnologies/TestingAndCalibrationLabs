using System.ComponentModel.DataAnnotations;
namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class ChangePasswordModel
    {
        /// <summary>
        /// It Contains The OldPassword
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// It Contains The NewPassword
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        ///  It Contains The ConfirmPassword
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// It Contains The Use Id to existing User 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        ///  It Contains The PasswordHash
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// It Contains The  PasswordSalt 
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        ///  It Contains The User Name.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        ///  It Contains The Organization Id.
        /// </summary>
        public int OrgId { get; set; }
    }
}
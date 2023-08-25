using System.ComponentModel.DataAnnotations;
namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class ChangePasswordModel
    {
        /// <summary>
        /// OldPassword
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// NewPassword
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// ConfirmPassword
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// PasswordHash
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// PasswordSalt
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        /// User Name.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Organization Id.
        /// </summary>
        public int OrgId { get; set; }
    }
}
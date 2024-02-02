using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UserClaimDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter UserName")]
        /// <summary>
        /// User Id reference from User.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Select Permission Name")]
        /// <summary>
        /// Permission Id reference from Permission.
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// Permission Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Permission Name")]
        public string PermissionName { get; set; }

        [Required(ErrorMessage = "Please Select Claim Type Name")]
        /// <summary>
        /// Claim Type Id reference from Claim Type.
        /// </summary>
        public int ClaimTypeId { get; set; }
        /// <summary>
        /// Claim Type Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Claim Type Name")]
        public string ClaimTypeName { get; set; }
    }
}

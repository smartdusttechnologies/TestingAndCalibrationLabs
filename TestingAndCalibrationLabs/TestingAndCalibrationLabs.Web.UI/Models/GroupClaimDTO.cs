using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class GroupClaimDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Group Id reference from Group.
        /// </summary>
        [Required(ErrorMessage = "Please Enter GroupName")]
        public int GroupId { get; set; }
        /// <summary>
        /// Group Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Group Name")]
        public string GroupName { get; set; }
        /// <summary>
        /// Claim Type Id reference from Claim Type.
        /// </summary>
        [Required(ErrorMessage = "Please Select Claim Type Name")]
        public int ClaimTypeId { get; set; }
        /// <summary>
        /// Claim Type Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Claim Type Name")]
        public string ClaimTypeName { get; set; }

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
    }
}

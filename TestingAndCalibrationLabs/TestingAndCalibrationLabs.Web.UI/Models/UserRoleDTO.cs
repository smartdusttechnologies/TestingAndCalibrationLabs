using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UserRoleDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Id reference from User Role.
        /// </summary>
        [Required(ErrorMessage = "Please Select User Name")]
        public int UserId { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Select Role Name")]
        /// <summary>
        /// Role Id reference from User Role.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Role Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Role Name")]
        public string RoleName { get; set; }
    }
}

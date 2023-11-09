using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UserGroupDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Group Id reference from User Group.
        /// </summary>
        [Required(ErrorMessage = "Please Select Group Name")]
        /// <summary>
        /// Group Id reference from User Group.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Group Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Group Name")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Please Select User Name")]
        /// <summary>
        /// User Id reference from User Group.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }
    }
}

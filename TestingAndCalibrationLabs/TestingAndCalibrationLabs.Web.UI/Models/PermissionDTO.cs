using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class PermissionDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains the name of the Permission.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// Permission Module Type Id reference from Permission Module Type.
        /// </summary>
        [Required(ErrorMessage = "Please Select Permission Module Type Name")]
        public int PermissionModuleTypeId { get; set; }
        /// <summary>
        /// Permission Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Permission Type Name")]
        public string PermissionModuleTypeName { get; set; }

        [Required(ErrorMessage = "Please Select Permission Type Name")]
        /// <summary>
        /// Permission Type Id reference from Permission type.
        /// </summary>
        public int PermissionTypeId { get; set; }
        /// <summary>
        /// Permission Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Permission Module Type Name")]
        public string PermissionTypeName { get; set; }
    }
}

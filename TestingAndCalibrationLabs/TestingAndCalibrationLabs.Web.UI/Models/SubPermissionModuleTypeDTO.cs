using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class SubPermissionModuleTypeDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains the name of the SubPermissionModuleType.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// Permission Module Type Id reference from Permission Module type.
        /// </summary>
        [Required(ErrorMessage = "Please Select Permission Module Type Name")]
        public int PermissionModuleTypeId { get; set; }
        /// <summary>
        /// SubPermissionModuleType Name
        /// </summary>
         //[Required(ErrorMessage = "Please Enter Permission Module Type Name")]
        public string PermissionModuleTypeName { get; set; }
    }
}

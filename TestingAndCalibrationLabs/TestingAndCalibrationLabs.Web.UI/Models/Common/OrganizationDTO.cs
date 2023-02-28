using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{   /// <summary>
    /// It Conatains The Properties for Organization
    /// </summary>
    public class OrganizationDTO
    {    /// <summary>
         /// It Contains The Id of Organization
         /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The OrgCode of Organization
        /// </summary>
        [Required(ErrorMessage = "Please Enter orgCode")]   
        public string OrgCode { get; set; }
        /// <summary>
        /// It Contains The OrgName of Organization
        /// </summary>
        [Required(ErrorMessage = "Please Enter orgName")]
        public string OrgName { get; set; }
    }
}

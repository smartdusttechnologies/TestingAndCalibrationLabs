using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of Organization
    /// </summary>
    public class OrganizationDTO
    {
        /// <summary>
        /// It Contains Id For Organization
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains OrgCode For Organization
        /// </summary>
        [Required(ErrorMessage = "Please Enter OrgCode")]
        public string OrgCode { get; set; }
        /// <summary>
        /// It Contains OrgName For Organization
        /// </summary>
        [Required(ErrorMessage = "Please Enter OrgName")]
        public string OrgName { get; set; }

    }
}

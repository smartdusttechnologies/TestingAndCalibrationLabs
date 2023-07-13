using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of Lookup Category
    /// </summary>
    public class LookupCategoryDTO
    {
        /// <summary>
        /// It Contains Id For Lookup Category
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains Name For Lookup Category
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]

        public string Name { get; set; }

    }
}

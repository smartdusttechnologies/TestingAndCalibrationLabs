using System;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties For Lookup
    /// </summary>
    public class LookupDTO
    {
        /// <summary>
        /// It Contains Id For Lookup
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains Name For Lookup
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains Id For Lookup Category
        /// </summary>
        [Required(ErrorMessage = "Please choose LookupCategory Name")]

        public int LookupCategoryId { get; set; }
        public int LookupId { get; set; }

        public int ParentId { get; set; }
       // public string Category { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Ui Navigation Category
    /// </summary>
    public class UiNavigationCategoryDTO
    {
        /// <summary>
        /// It Contains The Id of The Ui Navigation Category
        /// </summary>
         
        public int Id { get; set; }

        /// <summary>
        /// It Contains The Name Of The Ui Navigation Category
        /// </summary> 
        [Required(ErrorMessage = "Please Enter Navigation Name")]
        public string Name { get; set; } 
    }
}

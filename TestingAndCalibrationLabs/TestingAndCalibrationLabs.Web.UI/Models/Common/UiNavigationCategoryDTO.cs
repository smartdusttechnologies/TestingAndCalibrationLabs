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
        /// <summary>
        /// It Contains The Id of The Ui Navigation Category
        /// </summary>

        [Required(ErrorMessage = "Please Enter Orders")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter  Number Greater than 0 in Orders")]
        public string Orders { get; set; }

        /// <summary>
        /// IconName in which icon will show
        /// </summary>
        public string IconName { get; set; }
        /// <summary>
        /// It will take the place to show the Icon 
        /// </summary>

        public int NavigationTypeId { get; set; }
    }
}

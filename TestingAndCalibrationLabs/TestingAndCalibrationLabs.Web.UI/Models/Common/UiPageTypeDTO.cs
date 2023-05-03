using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Type 
    /// </summary>
    public class UiPageTypeDTO
    {
        #region Public Properties
        /// <summary>
        /// It Contains The Id of The Ui Page Type
        /// </summary>
        public int Id { get; set; }
       
        /// <summary>
        /// It Contains The Name Of The Ui Page Type
        /// </summary> 
        [Required(ErrorMessage = "Please Enter Page Name")]
        
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Url Of The Ui Page Type
        /// </summary> 
        [Required(ErrorMessage = "Please Enter Url")]
        public string Url { get; set; }
        /// <summary>
        /// It Contains The Id Of The Ui Navigation Category
        /// </summary> 
        [Required(ErrorMessage = "Please Select Navigation Category")]
        public int UiNavigationCategoryId { get; set; }
        /// <summary>
        /// It Contains The Name Of The Ui Navigation Category
        /// </summary> 
        public string UiNavigationCategoryName { get; set; }
        /// <summary>
        /// It Contains The Url With Ui Page Type Id
        /// </summary>
        public string FormatedUrl { get; set; }
        /// <summary>
        /// It Contains The Orders With Ui Navigation Category
        /// </summary>
        public string Orders { get; set; }
        #endregion
    }
}

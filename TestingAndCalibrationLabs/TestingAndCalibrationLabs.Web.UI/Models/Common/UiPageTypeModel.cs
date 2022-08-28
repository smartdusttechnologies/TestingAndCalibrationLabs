using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Type 
    /// </summary>
    public class UiPageTypeModel
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
        #endregion
    }
}

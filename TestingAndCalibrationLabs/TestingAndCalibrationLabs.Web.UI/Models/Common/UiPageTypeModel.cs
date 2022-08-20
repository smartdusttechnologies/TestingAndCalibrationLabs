using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class UiPageTypeModel
    {
        #region Public Properties
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        #endregion
    }
}

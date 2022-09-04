using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Ui Control Type
    /// </summary>
    public class UiControlTypeModel
    {
        /// <summary>
        /// It Contains The Id of The Ui Control Type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Control Type
        /// </summary>
        [Required(ErrorMessage = "Please Enter Control Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains The DisplayName of The Ui Control Type
        /// </summary>  
        [Required(ErrorMessage = "Please Enter your Display Name")]
        public string DisplayName { get; set; }
    }
}

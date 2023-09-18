using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of ModuleLayout
    /// </summary>
    public class ModuleLayoutDTO
    {
        /// <summary>
        /// It Contains Id For ModuleLayout
        /// </summary>
        public int Id {  get; set; }
        /// <summary>
        /// It Contains Name For ModuleLayout
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains ModuleId For ModuleLayout
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains Name For Module
        /// </summary>
        [Required(ErrorMessage = "Please Enter ModuleName")]
        public string ModuleName { get; set; }
        /// <summary>
        /// It Contains LayoutId For ModuleLayout
        /// </summary>
        public int LayoutId { get; set; }
        /// <summary>
        /// It Contains Name For Layout
        /// </summary>
        [Required(ErrorMessage = "Please Enter LayoutName")]
        public string LayoutName { get; set; }      

    }
}

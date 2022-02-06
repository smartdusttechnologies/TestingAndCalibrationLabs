using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models.Sample
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class SampleModel
    {
        #region Public Properties
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        #endregion
    }
}
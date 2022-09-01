using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class DataTypeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter DataType name")]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for  Data Type
    /// </summary>
    public class DataTypeDTO
    {
        /// <summary>
        /// It Contains The Id of The Data Type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Data Type
        /// </summary>
        [Required(ErrorMessage = "Please Enter Data Type Name")]
        public string Name { get; set; }
    }
}

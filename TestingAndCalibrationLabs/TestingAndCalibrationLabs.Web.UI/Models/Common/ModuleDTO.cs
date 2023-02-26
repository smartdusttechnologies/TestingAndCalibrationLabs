using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ModuleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please choose Application Name")]
        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }

    }
}

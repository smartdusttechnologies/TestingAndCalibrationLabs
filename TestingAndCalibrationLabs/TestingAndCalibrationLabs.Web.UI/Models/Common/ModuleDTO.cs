using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ModuleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Page Name")]
        public string Name { get; set; }
        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }

    }
}

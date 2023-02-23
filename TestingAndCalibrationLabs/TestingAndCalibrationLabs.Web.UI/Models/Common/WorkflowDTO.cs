using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Page Name")]
        public string Name { get; set; }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
    }
}

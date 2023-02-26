using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Choose Module Name")]
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }
    }
}

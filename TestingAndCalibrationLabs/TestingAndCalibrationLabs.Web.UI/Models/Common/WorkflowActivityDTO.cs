using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowActivityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]      
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Choose ActivityName")]
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        [Required(ErrorMessage = "Please Choose WorkflowStageName")]
        public int WorkflowStageId { get; set; }

        
        public string WorkflowStageName { get; set; }
    }
}

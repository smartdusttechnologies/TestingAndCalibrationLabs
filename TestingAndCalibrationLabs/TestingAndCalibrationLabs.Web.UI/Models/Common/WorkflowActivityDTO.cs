using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowActivityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int WorkflowStageId { get; set; }
        public string WorkflowStageName { get; set; }
    }
}

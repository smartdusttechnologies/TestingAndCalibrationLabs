using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowStageDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Choose UiPageTypeName")]
        public int UiPageTypeId { get; set; }

        public string UiPageTypeName { get; set; }

        [Required(ErrorMessage = "Please Choose WorkflowName")]
        public int WorkflowId { get; set; }

        public string WorkflowName { get; set; }

        [Required(ErrorMessage = "Please Enter Orders ")]
        public int Orders { get; set; }
    }
}

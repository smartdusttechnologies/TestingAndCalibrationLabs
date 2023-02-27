using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{   /// <summary>
    /// It Conatains The Properties for WorkflowStage
    /// </summary>
    public class WorkflowStageDTO
    {    /// <summary>
         /// It Contains The Id of WorkflowStage
         /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of WorkflowStage
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        /// <summary>
        /// It Contains Id Name of UiPageType
        /// </summary>
        [Required(ErrorMessage = "Please Choose UiPageTypeName")]
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of UiPageType
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains The Id of Workflow
        /// </summary>
        [Required(ErrorMessage = "Please Choose WorkflowName")]
        public int WorkflowId { get; set; }
        /// <summary>
        /// It Contains The Name of Workflow
        /// </summary>
        public string WorkflowName { get; set; }
        /// <summary>
        /// It Contains The Orders of WorkflowStage
        /// </summary>
        [Required(ErrorMessage = "Please Enter Orders ")]
        public int Orders { get; set; }
    }
}

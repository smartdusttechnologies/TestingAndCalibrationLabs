using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{    /// <summary>
     /// It Conatains The Properties for WorkflowActivity
     /// </summary>
    public class WorkflowActivityDTO
    {     /// <summary>
          /// It Contains The Id of WorkflowActivity
          /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of WorkflowActivity
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]      
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Id of Activity
        /// </summary>
        [Required(ErrorMessage = "Please Choose ActivityName")]
        public int ActivityId { get; set; }
        /// <summary>
        /// It Contains The Name of Activity
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// It Contains The Id of WorkflowStage
        /// </summary>
        [Required(ErrorMessage = "Please Choose WorkflowStageName")]
        public int WorkflowStageId { get; set; }
        /// <summary>
        /// It Contains The Name of WorkflowStage
        /// </summary>
        public string WorkflowStageName { get; set; }
    }
}

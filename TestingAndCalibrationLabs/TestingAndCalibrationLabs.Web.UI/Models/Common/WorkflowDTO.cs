using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{    /// <summary>
     /// It Conatains The Properties for Workflow
     /// </summary>
    public class WorkflowDTO
    {    /// <summary>
         /// It Contains The Id of Workflow
         /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        /// <summary>
        /// It Contains The Name of Workflow
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Id of Module
        /// </summary>
        [Required(ErrorMessage = "Please Choose Module Name")]
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains The Name of Module
        /// </summary>
        public string ModuleName { get; set; }
    }
}

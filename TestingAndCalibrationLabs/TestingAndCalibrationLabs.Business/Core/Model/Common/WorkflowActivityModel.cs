using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains properties Of WorkflowActivity
    /// </summary>
    [DbTable("WorkflowActivity")]
    public class WorkflowActivityModel : Entity
    {
        /// <summary>
        /// It Contains Name Of WorkflowActivity
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains Id Of Acitivity
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// It Contains Name Of Acitivity
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// It contains Id Of WorkflowStage
        /// </summary>
        public int WorkflowStageId { get; set; }
        /// <summary>
        /// It Contains Name Of WorkflowStage
        /// </summary>
        public string WorkflowStageName { get; set; }
    }
}

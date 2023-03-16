using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of WorfklowStage
    /// </summary>
    [DbTable("Module")]
    public class WorkflowStageModel : Entity
    {
        /// <summary>
        /// It Contains Name Of WorkflowStage
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains Id Of UiPageType
        /// </summary>
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains Id Of Workflow
        /// </summary>
        public int WorkflowId { get; set; }
        /// <summary>
        /// It Contians Order Of WorkflowStage
        /// </summary>
        public int Orders { get; set; }
        /// <summary>
        /// It Contains Name Of Module
        /// </summary>
        public string ModuleName { get; set; }
    }
}

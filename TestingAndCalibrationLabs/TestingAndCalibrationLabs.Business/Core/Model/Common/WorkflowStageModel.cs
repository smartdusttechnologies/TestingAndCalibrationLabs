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
        /// It Contains Name Of UiPageType
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains Id Of Workflow
        /// </summary>
        public int WorkflowId { get; set; }
        /// <summary>
        /// It Contains Name Of Workflow
        /// </summary>
        public string WorkflowName { get; set; }
        /// <summary>
        /// It Contains Orders Of WorkflowStage
        /// </summary>
        public int Orders { get; set; }



    }
}

using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains properties Of AcitivtyMetadata
    /// </summary>
    [DbTable("ActivityMetadata")]
    public class ActivityMetadataModel : Entity
    {
        /// <summary>
        /// It Contains Name Of ActivityMetadata
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains Value Of ActivityMetadata
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// It Contains Id Of ActivityMetadataType
        /// </summary>
        public int ActivityMetadataTypeId { get; set; }
        /// <summary>
        /// It Contains Id Of Activity
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// It Contains Id Of WorkflowStage
        /// </summary>
        public int WorkflowStageId { get; set; }
        /// <summary>
        /// It Contains Id Of UiPageMetadata
        /// </summary>
        public int UiPageMetadataId { get; set; }

    }
}

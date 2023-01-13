using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("ActivityMetadata")]
    public class ActivityMetadataModel : Entity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int ActivityMetadataTypeId { get; set; }
        public int ActivityId { get; set; }
        public int WorkflowStageId { get; set; }
        public int UiPageMetadataId { get; set; }

    }
}

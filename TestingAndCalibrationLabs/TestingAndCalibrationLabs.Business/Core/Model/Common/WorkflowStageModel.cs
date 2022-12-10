using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Module")]
    public class WorkflowStageModel : Entity
    {
        public string Name { get; set; }
        public int UiPageTypeId { get; set; }
        public int WorkflowId { get; set; }
        public int Orders { get; set; }
    }
}

using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Workflow")]
    public class WorkflowModel : Entity
    {
        public string Name { get; set; }
        public int ModuleId { get; set; }
    }
}

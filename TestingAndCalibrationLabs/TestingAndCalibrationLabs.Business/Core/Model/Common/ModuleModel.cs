using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Module")]
    public class ModuleModel : Entity
    {
        public string Name { get; set; }
        public int ApplicationId { get; set; }
    }
}

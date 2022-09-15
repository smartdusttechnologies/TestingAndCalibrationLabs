using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Lookup")]
    public class LookupModel : Entity
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
}

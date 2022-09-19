using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("LookupCategory")]
    public class LookupCategoryModel : Entity
    {
        public string Name { get; set; }
    }
}

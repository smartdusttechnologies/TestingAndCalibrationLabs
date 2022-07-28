using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model.Common
{
    [DbTable("UiPageType")]
    public class UiPageTypeModel : Entity
    {
        public string Name { get; set; }
    }
}

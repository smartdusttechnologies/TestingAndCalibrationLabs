using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTableAttribute("UiControlType")]
    public class UiControlTypeModel : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}

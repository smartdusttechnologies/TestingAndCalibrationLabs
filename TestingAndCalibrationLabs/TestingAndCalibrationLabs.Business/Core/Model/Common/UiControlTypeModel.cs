using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Declaring properties  here
    /// </summary>
    [DbTableAttribute("UiControlType")]
    public class UiControlTypeModel : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}

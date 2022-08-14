using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model.Common
{
    /// <summary>
    /// Declaring properties for  Fetch Name and DisplayName
    /// </summary>
    [DbTableAttribute("UiControlType")]
    public class UiControlTypeModel : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}

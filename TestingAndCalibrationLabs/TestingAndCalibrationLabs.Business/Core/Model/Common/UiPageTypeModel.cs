using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model.Common
{
    /// <summary>
    /// Declaring properties for operations
    /// </summary>
    [DbTable("UiPageType")]
    public class UiPageTypeModel : Entity
    {
        public string Name { get; set; }
    }
}

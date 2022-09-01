using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UiNavigationCategory")]
    public class UiNavigationCategoryModel : Entity
    {
        public string Name { get; set; }    
    }
}

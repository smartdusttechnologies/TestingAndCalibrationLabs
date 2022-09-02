using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Type
    /// </summary>
    [DbTable("UiPageType")]
    public class UiPageTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name For The Ui Page Type
        /// </summary>
        public string Name { get; set; }
        public string Url { get; set; } 
        public int UiNavigationCategoryId { get; set; }
        public string UiNavigationCategoryName { get; set; }
    }
    
}

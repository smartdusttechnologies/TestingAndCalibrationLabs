using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Navigation Category 
    /// </summary>
    [DbTable("UiNavigationCategory")]
    public class UiNavigationCategoryModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Ui Navigation Category
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Orders of The Ui Navigation Category
        /// </summary>
        public string Orders { get; set; }
           
    }
}

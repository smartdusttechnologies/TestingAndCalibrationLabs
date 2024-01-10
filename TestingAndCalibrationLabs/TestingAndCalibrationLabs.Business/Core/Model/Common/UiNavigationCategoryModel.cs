using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties for Ui Navigation Category 
    /// </summary>
    [DbTable("UiNavigationCategory")]
    public class UiNavigationCategoryModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Ui Navigation Category
        /// </summary>
        [DbColumn("Name")]
        public string Name { get; set; }

        /// <summary>
        /// It Contains The Orders of The Ui Navigation Category
        /// </summary>
        [DbColumn("Orders")]
        public string Orders { get; set; }

        /// <summary>
        /// IconName in which icon will show
        /// </summary>
        [DbColumn("IconName")]
        public string IconName { get; set; }

        /// <summary>
        /// It will take the place to show the Icon 
        /// </summary>
        [DbColumn("NavigationTypeId")]
        public int NavigationTypeId { get; set; }
    }
}

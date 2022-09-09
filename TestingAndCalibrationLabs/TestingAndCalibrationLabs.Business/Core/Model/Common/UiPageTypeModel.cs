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
        /// <summary>
        /// It Contains The Url For The Ui Page Type
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// It Contains The Id For The Ui Navigation Category
        /// </summary>
        public int UiNavigationCategoryId { get; set; }
        /// <summary>
        /// It Contains The Name For The Ui Navigation Category
        /// </summary>
        public string UiNavigationCategoryName { get; set; }
        /// <summary>
        /// It Contains The Url With Ui Page Type Id
        /// </summary>
        public string FormatedUrl { get; set; }
        /// <summary>
        /// It Contains The Orders With Ui Navigation Category
        /// </summary>
        public string Orders { get; set; }
    }

}

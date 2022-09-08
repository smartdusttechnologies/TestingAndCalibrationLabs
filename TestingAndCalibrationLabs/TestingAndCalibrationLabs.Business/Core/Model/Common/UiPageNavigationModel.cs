using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Navigation 
    /// </summary>
    public class UiPageNavigationModel : Entity
    {
        /// <summary>
        /// It Contains The Id of The Ui Navigation Category 
        /// </summary>
        public int UiNavigationCategoryId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Navigation Category 
        /// </summary>
        public string UiNavigationCategoryName { get; set; }
        /// <summary>
        /// It Contains The Url of The Ui Page Type 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// It Contains The Url Which Is laterly Converted To FormatedUrl Using String.Format
        /// </summary>
        public string FormatedUrl { get; set; }
    }
}

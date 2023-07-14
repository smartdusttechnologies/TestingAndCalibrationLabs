using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
        [DbTable("UiPageNavigation")]
    /// <summary>
    /// Ui Page Navigation Model.
    /// </summary>
    public class UiPageNavigationModel : Entity
    {
        /// <summary>
        /// Configured Url of page.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Ui Page module id refer to ui page type
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// Module  Name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Ui Navigation Category Id.
        /// </summary>
        public int UiNavigationCategoryId { get; set; }

        /// <summary>
        /// Ui Navigation Category Name.
        /// </summary>
        public string UiNavigationCategoryName { get; set; }

        /// <summary>
        /// Formated url of ui page with page identifier.
        /// </summary>
        public string FormatedUrl { get; set; }

        //TODO: the orders field should be int, it seems.
        /// <summary>
        /// Order is uinavigationcategory use.
        /// </summary>
        public string Orders { get; set; }
    }
}

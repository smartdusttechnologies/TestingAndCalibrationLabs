namespace TestingAndCalibrationLabs.Business.Core.Model
{
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
        /// Ui Page Type Id reference from Ui page type.
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// Ui Page Type Name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Ui Navigation Category Id reference from UiNavigationCategory.
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
        /// Order in which navigation item will appear.
        /// </summary>
        public string Orders { get; set; }
    }
}

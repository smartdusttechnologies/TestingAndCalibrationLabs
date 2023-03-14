namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageNavigationDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        //TODO: Do we need the url property in UI side model as well? remove if not needed.
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

        //TODO: the orders field should be int and should be singular, it seems.
        /// <summary>
        /// Order in which navigation item will appear.
        /// </summary>
        public string Orders { get; set; }
    }
}

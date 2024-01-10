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
        /// It contains id of module
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
        /// Order in which navigation item will appear.
        /// </summary>


        public string Orders { get; set; }
        /// <summary>
        /// IconName in which icon will show
        /// </summary>


        public string IconName { get; set; }

        /// <summary>
        /// it will store the uipageNavigation  Icon
        /// </summary>


        public string UiPageNavigationCategoryIcon { get; set; }

        /// <summary>
        /// It will store the Type of the Navigation
        /// </summary>

        public int NavigationType { get; set; }


    }
}
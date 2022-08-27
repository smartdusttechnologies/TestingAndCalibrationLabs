namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageValidationModel
    {
        /// <summary>
        /// Declaring Public Properties
        /// </summary>
        public int Id { get; set; }
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int UiPageMetadataId { get; set; }
        public string UiPageMetadataName { get; set; }
        public int UiPageValidationTypeId { get; set; }
        public string UiPageValidationTypeName { get; set; }

    }
}

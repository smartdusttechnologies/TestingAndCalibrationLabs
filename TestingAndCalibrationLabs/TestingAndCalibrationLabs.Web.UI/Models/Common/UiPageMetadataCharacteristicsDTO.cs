namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties For Ui Page Metadata Characteristics
    /// </summary>
    public class UiPageMetadataCharacteristicsDTO
    {
        /// <summary>
        /// It Contains Id For Ui Page Metadata Characterics
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains Id For Ui Page Metadata
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains Id For Lookup
        /// </summary>
        public int LookupId { get; set; }
        /// <summary>
        /// It Contains Name For Lookup
        /// </summary>
        public string LookupName { get; set; }
        public int LookupCategoryId { get; set; }
        public string LookupCategoryName { get; set; }
        public string UiControlDisplayName { get; set; }

    }
}

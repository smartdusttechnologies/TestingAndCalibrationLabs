using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties Of Ui Page Metadata Characteristics
    /// </summary>
    [DbTable("UiPageMetadataCharacteristics")]
    public class UiPageMetadataCharacteristicsModel : Entity
    {
        /// <summary>
        /// It Contains The UiPageMetadataId Of The UiPageMetadataCharacteristics
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains The UiControlDisplayName Of The UiPageMetadataCharacteristics
        /// </summary>
        public string UiControlDisplayName { get; set; }
        /// <summary>
        /// It Contains The LookupId Of The UiPageMetadataCharacteristics
        /// </summary>
        public int LookupId { get; set; }
        /// <summary>
        /// It Contains Name For Lookup
        /// </summary>
        public string LookupName { get; set; }
        /// <summary>
        /// It Contains LookupCategoryId For UiPageMetadataCharacteristics
        /// </summary>
        public string LookupCategoryId { get; set; }
        /// <summary>
        /// It Contains Name For LookupCategory
        /// </summary>
        public string LookupCategoryName { get; set; }

    }
}

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
        /// It Contains The Id Of The Ui Page Metadata
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains The Id Of The Lookup 
        /// </summary>
        public int LookupId { get; set; }
        /// <summary>
        /// It Contains The Name Of The Lookup
        /// </summary>
        public string LookupName { get; set; }
    }
}
